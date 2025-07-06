using AsteroidsTest.Enemies.Asteroids.Asteroid;
using AsteroidsTest.Enemies.Asteroids.Fragment;
using AsteroidsTest.Enemies.UFO;
using AsteroidsTest.Input;
using AsteroidsTest.Pause;
using AsteroidsTest.Ship;
using AsteroidsTest.SOScripts;
using AsteroidsTest.UI;
using AsteroidsTest.Weapon.Bullet;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace AsteroidsTest.Installers
{
    public class GameplayIntaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private GameStaticData _gameStaticData;
        [SerializeField] private DefeatPointsData _defeatPointsData;
        [SerializeField] private Transform _bigEnemiesSpawnPoint;
        [SerializeField] private ShipCollision _ship;
        [SerializeField] private GameObject _playerInputPrefab;
        [SerializeField] private ShipStateUpdater _updater;

        public override void InstallBindings()
        {
            InstallInput();
            InstallPause();
    
            InstallGameOver();
            InstallTargetDefeatPoints();
            InstallShip();
            InstallData();
            InstallFactories();
        }
    
        private void InstallPause()
        {
            Container.Bind<Pauser>().
                 AsSingle().
                 NonLazy();
        }
    
        private void InstallGameOver()
        {
            Container.Bind<GameOverModel>().
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
            Container.Bind<LaserModel>().
                AsSingle();

            Container.Bind<ShipCollision>().
                FromInstance(_ship).
                AsSingle();

            Container.Bind<ShipStateModel>().
                AsSingle();

            Container.Bind<ShipStateUpdater>().
                FromInstance(_updater).
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
    
            Container.BindInterfacesAndSelfTo<BaceInputHandler>().
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
            Container.BindInterfacesAndSelfTo<UFOFactory>().
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
            Container.BindInterfacesAndSelfTo<FragmentsFactory>().
                AsSingle();
        }
    
        private void InstallAsteroidsFactory()
        {
            Container.BindInterfacesAndSelfTo<AsteroidsFactory>().           
                AsSingle().
                WithArguments(_bigEnemiesSpawnPoint, this).
                NonLazy();
        }
    }
}
