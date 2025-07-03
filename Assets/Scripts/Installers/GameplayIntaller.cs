using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GameplayIntaller : MonoInstaller, ICoroutineRunner
{
    [SerializeField] private GameStaticData _gameStaticData;
    [SerializeField] private DefeatPointsData _defeatPointsData;
    [SerializeField] private Transform _bigEnemiesSpawnPoint;
    [SerializeField] private ShipCollision _ship;
    [SerializeField] private GameObject _playerInputPrefab;

    public override void InstallBindings()
    {
        InstallInput();
        
        InstallGameOver();
        InstallTargetDefeatPoints();
        InstallShip();
        InstallData();
        InstallFactories();
    }

    private void InstallGameOver()
    {
        Container.Bind<GameOver>().
            AsSingle().
            NonLazy();
    }

    private void InstallTargetDefeatPoints()
    {
        Container.Bind<EnemiesDefeatPoints>().
            AsSingle();
    }

    private void InstallShip()
    {
        Container.Bind<ShipCollision>().
            FromInstance(_ship).
            AsSingle();
    }

    private void InstallData()
    {
        Container.Bind<GameStaticData>().
            FromInstance(_gameStaticData).
            AsSingle();

        Container.Bind<DefeatPointsData>().
           FromInstance(_defeatPointsData).
           AsSingle();
    }

    private void InstallInput()
    {
        Container.Bind<PlayerInput>().
            FromComponentInNewPrefab(_playerInputPrefab).AsSingle();

        Container.BindInterfacesAndSelfTo<PCInputHandler>().
            AsSingle().
            NonLazy();
    }

    private void InstallFactories()
    {
        InstallFragmentsFactory();
        InstallAsteroidsFactory();
        InstallUFOFactory();
        InstallBulletsFactory();
    }

    private void InstallUFOFactory()
    {
        Container.Bind<UFOFactory>().
            AsSingle().
            WithArguments(_bigEnemiesSpawnPoint, this).
            NonLazy();
    }

    private void InstallBulletsFactory()
    {
        Container.Bind<BulletsFactory>().
             AsSingle();
    }

    private void InstallFragmentsFactory()
    {
        Container.Bind<FragmentsFactory>().
            AsSingle();
    }

    private void InstallAsteroidsFactory()
    {
        Container.Bind<AsteroidsFactory>().           
            AsSingle().
            WithArguments(_bigEnemiesSpawnPoint, this).
            NonLazy();
    }
}