using UnityEngine;
using Zenject;

public class GameplayIntaller : MonoInstaller, ICoroutineRunner
{
    [SerializeField] private GameStaticData _gameStaticData;
    [SerializeField] private Transform _asteroidsSpawnPoint;

    public override void InstallBindings()
    {
        InstallFragmentsFactory();
        InstallAsteroidsFactory();
    }

    private void InstallFragmentsFactory()
    {
        Container.Bind<FragmentsFactory>().
            FromNew().
            AsSingle().
            WithArguments(_gameStaticData).
            NonLazy();
    }

    private void InstallAsteroidsFactory()
    {
        Container.Bind<AsteroidsFactory>().
            FromNew().
            AsSingle().
            WithArguments(_gameStaticData, _asteroidsSpawnPoint, this).
            NonLazy();
    }
}