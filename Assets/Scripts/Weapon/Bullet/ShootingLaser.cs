using UnityEngine;
using Zenject;

public class ShootingLaser : MonoBehaviour
{
    [SerializeField] private ShootingLaserRenderer _shootingLaserRenderer;
    [SerializeField] private Transform _gunBarrel;
    [Space]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distance = 100;
    [SerializeField] private float _laserThickness = 0.5f;

    private IInputHandler _inputHandler;

    [Inject]
    private void Initialize(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
        inputHandler.LaserFireAction += LaserFire;
    }

    private void LaserFire()
    {
        RaycastHit2D[] hits = Physics2D
            .CircleCastAll(_gunBarrel.position, _laserThickness, _gunBarrel.up, _distance, _layerMask);

        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeBulletDamage();
            }
        }

        StartCoroutine(_shootingLaserRenderer
            .LaserEffect(_gunBarrel.position, _gunBarrel.position + _gunBarrel.up* _distance, _laserThickness));
    }

    private void OnDestroy()
    {
        _inputHandler.LaserFireAction -= LaserFire;
    }
}
