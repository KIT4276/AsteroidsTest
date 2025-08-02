using AsteroidsTest.Assets;
using AsteroidsTest.Factories;
using AsteroidsTest.Input;
using AsteroidsTest.Progress;
using AsteroidsTest.Save;
using AsteroidsTest.Services;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace AsteroidsTest.Installers
{
    public class InfrastructureInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private GameObject _entryPointPrefab;
        [SerializeField] private GameObject _playerInputPrefab;

        public override void InstallBindings()
        {
            InstallInput();

            this.gameObject.SetActive(true);
            Container.BindInterfacesAndSelfTo<ICoroutineRunner>().FromInstance(this).AsSingle();

            InstallSceneLoader();
            InstallFactories();
            InstallServices();

            InstallEntryPoint();
        }

        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<AssetsProvider>()
                .AsSingle();
            Container.Bind<ProgressService>()
                .AsSingle();
            Container.Bind<SaveLoadService>()
                .AsSingle();
            Container.Bind<ProgressReadersHolder>()
                .AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<StateFactory>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<UIFactory>()
                .AsSingle();
        }

        private void InstallSceneLoader()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader>()
                .AsSingle();
        }

        private void InstallInput()
        {
            Container.Bind<PlayerInput>().
                FromComponentInNewPrefab(_playerInputPrefab)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<BaseInputHandler>()
                .AsSingle();
        }

        private void InstallEntryPoint()
        {
            Container.Bind<EntryPoint>()
                .FromComponentInNewPrefab(_entryPointPrefab)
                .AsSingle()
                .NonLazy();
        }
    }
}