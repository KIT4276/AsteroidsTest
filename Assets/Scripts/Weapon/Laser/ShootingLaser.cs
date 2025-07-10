using AsteroidsTest.Input;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Weapon.Laser
{
    public class ShootingLaser : MonoBehaviour
    {
        [SerializeField] private ShootingLaserRenderer _shootingLaserRenderer;
        [SerializeField] private Transform _gunBarrel;
        [Space]
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _distance = 100;
        [SerializeField] private float _laserThickness = 0.5f;

        private LaserModel _laserModel;
        private BaseInputHandler _inputHandler;

        [Inject]
        private void Construct(BaseInputHandler inputHandler, LaserModel laserModel)
        {
            _laserModel = laserModel;
            _inputHandler = inputHandler;

            inputHandler.LaserFireAction += LaserFire;
        }

        private void LaserFire()
        {
            if (_laserModel.TryFire())
            {
                RaycastHit2D[] hits = Physics2D
                    .CircleCastAll(_gunBarrel.position, _laserThickness, _gunBarrel.up, _distance, _layerMask);
    
                foreach (var hit in hits)
                {
                    if (hit.collider != null && hit.collider.TryGetComponent<IDamageable>(out var damageable))
                    {
                        damageable.TakeDamage();
                    }
                }
    
                if (_shootingLaserRenderer != null)
                {
                    StartCoroutine(_shootingLaserRenderer
                        .LaserEffect(_gunBarrel.position, _gunBarrel.position + _gunBarrel.up * _distance, _laserThickness));
                }
            }
        }

        private void Update() => 
            _laserModel.UpdateTimer(Time.deltaTime);

        private void OnDestroy() => 
            _inputHandler.LaserFireAction -= LaserFire;
    }
}
