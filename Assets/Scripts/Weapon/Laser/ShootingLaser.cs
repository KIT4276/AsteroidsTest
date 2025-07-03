using System;
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

    private BaceInputHandler _inputHandler;
    private bool _isRunning = false;

    public float OneShotRecoveryTime { get => _oneShotRecoveryTime; }
    public float Timer { get; private set; }
    public int ShotsLeft { get; private set; }

    public event Action NumberOfShotsChange;

    [Inject]
    private void Initialize(BaceInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
        inputHandler.LaserFireAction += LaserFire;

        ShotsLeft = _numberOfShots;
        Timer = 0;
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
                    damageable.TakeDamage();
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

            NumberOfShotsChange?.Invoke();
        }
    }

    private void Update()
    {
        if (!_isRunning && ShotsLeft < _numberOfShots)
        {
            _isRunning = true;
            Timer = 0;
        }

        if (_isRunning)
        {
            RecoveryTimer();
        }
    }

    private void RecoveryTimer()
    {
        Timer += Time.deltaTime;

        if (Timer >= _oneShotRecoveryTime)
        {
            _isRunning = false;

            RecoverShots();
        }
    }

    private void RecoverShots()
    {
        ShotsLeft++;
        
        if (ShotsLeft > _numberOfShots)
        {
            ShotsLeft = _numberOfShots;
        }
        NumberOfShotsChange?.Invoke();
    }

    private void OnDestroy()
    {
        _inputHandler.LaserFireAction -= LaserFire;
    }
}
