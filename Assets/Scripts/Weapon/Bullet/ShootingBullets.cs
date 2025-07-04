using AsteroidsTest.Input;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Weapon.Bullet
{
    public class ShootingBullets : MonoBehaviour
    {
        [SerializeField] private Transform _gunBarrel;
    
        private BulletsFactory _bulletsFactory;
        private BaceInputHandler _inputHandler;
    
        [Inject]
        private void Initialize(BaceInputHandler inputHandler, BulletsFactory bulletsFactory)
        {
            _bulletsFactory = bulletsFactory;
            _inputHandler = inputHandler;
    
            inputHandler.BulletFireAction += BulletFire;
        }
    
        private void BulletFire()
        {
            _bulletsFactory.Spawn(_gunBarrel);
        }
    
        private void OnDestroy()
        {
            _inputHandler.BulletFireAction -= BulletFire;
        }
    }
}
