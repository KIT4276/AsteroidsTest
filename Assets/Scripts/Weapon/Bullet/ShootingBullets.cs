using UnityEngine;
using Zenject;

public class ShootingBullets : MonoBehaviour
{
    [SerializeField] private Transform _gunBarrel;

    private BulletsFactory _bulletsFactory;
    private IInputHandler _inputHandler;

    [Inject]
    private void Initialize(IInputHandler inputHandler, BulletsFactory bulletsFactory)
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
