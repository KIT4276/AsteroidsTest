using AsteroidsTest.Input;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Weapon.Bullet
{
    public class ShootingBullets : MonoBehaviour
    {
        [SerializeField] private Transform _gunBarrel;

        private BulletsFactory _bulletsFactory;
        private BaseInputHandler _inputHandler;
        private bool _initialized = false;

        [Inject]
        private void Construct(BaseInputHandler inputHandler, BulletsFactory bulletsFactory)
        {
            if (_initialized) return;

            _bulletsFactory = bulletsFactory;
            _inputHandler = inputHandler;

            if (_inputHandler != null)
            {
                _inputHandler.BulletFireAction += BulletFire;
            }

            _initialized = true;
        }

        private void BulletFire()
        {
            if (!_initialized || _gunBarrel == null) return;

            _bulletsFactory?.Spawn(_gunBarrel);
        }

        private void OnDestroy()
        {
            if (!_initialized) return;

            if (_inputHandler != null && !ReferenceEquals(_inputHandler, null))
            {
                _inputHandler.BulletFireAction -= BulletFire;
            }
        }
    }
}
