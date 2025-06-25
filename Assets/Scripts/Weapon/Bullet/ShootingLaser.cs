using System;
using System.Collections;
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
    [Space]
    [SerializeField] private int _numberOfShots = 5;
    [SerializeField] private float _oneShotRecoveryTime = 15;

    private IInputHandler _inputHandler;
    private float _timer;
    public int ShotsLeft { get; private set; }

    [Inject]
    private void Initialize(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
        inputHandler.LaserFireAction += LaserFire;

        ShotsLeft = _numberOfShots;
        _timer = _oneShotRecoveryTime;
    }

    private void LaserFire()
    {
        if (ShotsLeft > 0)
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

            if (_shootingLaserRenderer != null)
            {
                StartCoroutine(_shootingLaserRenderer
                    .LaserEffect(_gunBarrel.position, _gunBarrel.position + _gunBarrel.up * _distance, _laserThickness));
            }
            ShotsLeft--;
            
            if (ShotsLeft < 0)
            {
                ShotsLeft = 0;
            }

            StartCoroutine(RecoveryRoutine());
        }
    }

    private IEnumerator RecoveryRoutine()
    {
        yield return new WaitForSeconds(_oneShotRecoveryTime);

        ShotsLeft++;
        
        if (ShotsLeft > _numberOfShots)
        {
            ShotsLeft = _numberOfShots;
        }
    }

    private void OnDestroy()
    {
        _inputHandler.LaserFireAction -= LaserFire;
    }
}
