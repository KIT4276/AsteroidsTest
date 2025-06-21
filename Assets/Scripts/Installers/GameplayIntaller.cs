using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GameplayIntaller : MonoInstaller, ICoroutineRunner
{
    [SerializeField] private PlayerInput _playerInput;
    [Space]
    [SerializeField] private GameStaticData _gameStaticData;
    [SerializeField] private Transform _asteroidsSpawnPoint;
    [SerializeField] private ShipCollision _ship;

    public override void InstallBindings()
    {
        InstallShip();

        InstallGameStaticData();

        InstallInput();

        InstallFragmentsFactory();
        InstallAsteroidsFactory();
       // InstallUFOFactory();

        InstallBulletsFactory();
    }

    private void InstallUFOFactory()
    {
        Container.Bind<UFOFactory>().
            FromNew().
            AsSingle().
            WithArguments(_asteroidsSpawnPoint, this).
            NonLazy();
    }

    private void InstallShip()
    {
        Container.Bind<ShipCollision>().
            FromInstance(_ship).
            AsSingle();
    }

    private void InstallGameStaticData()
    {
        Container.Bind<GameStaticData>().
            FromInstance(_gameStaticData).
            AsSingle();
    }

    private void InstallInput()
    {
        Container.BindInterfacesAndSelfTo<PCInputHandler>().
            FromNew().
            AsSingle().
            WithArguments(_playerInput);
    }

    private void InstallBulletsFactory()
    {
        Container.Bind<BulletsFactory>().
             FromNew().
             AsSingle();
    }

    private void InstallFragmentsFactory()
    {
        Container.Bind<FragmentsFactory>().
            FromNew().
            AsSingle().
            NonLazy();
    }

    private void InstallAsteroidsFactory()
    {
        Container.Bind<AsteroidsFactory>().
            FromNew().
            AsSingle().
            WithArguments(_asteroidsSpawnPoint, this).
            NonLazy();
    }
}