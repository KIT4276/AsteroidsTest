using AsteroidsTest.Enemies;
using AsteroidsTest.Enemies.Asteroids.Asteroid;
using AsteroidsTest.Enemies.Asteroids.Fragment;
using AsteroidsTest.Enemies.UFO;
using AsteroidsTest.Pause;
using AsteroidsTest.Services;
using AsteroidsTest.Ship;
using AsteroidsTest.SOScripts;
using AsteroidsTest.UI;
using AsteroidsTest.Weapon.Bullet;
using AsteroidsTest.Weapon.Laser;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Installers
{
    public class GameplayIntaller : MonoInstaller
    {
        [SerializeField] private GameStaticData _gameStaticData;
        [SerializeField] private DefeatPointsData _defeatPointsData;
        [SerializeField] private GameObject _UFOSpawnPointPrefab;
        [SerializeField] private GameObject _astersSpawnPointPewfab;

        [SerializeField] private GameObject _shipPrefab;
        [SerializeField] private GameObject _mainUIPrefab;

        private ShipCollision _ship;

        public override void InstallBindings()
        {
            InstallPause();
            InstallBigEnemySpawner();

            InstallGameOver();
            InstallTargetDefeatPoints();
            InstallData();
            InstallFactories();

            InstallShip();
        }

        private void InstallBigEnemySpawner()
        {
            Container.BindInterfacesAndSelfTo<BigEnemySpawner>().
                AsSingle().
                NonLazy();
        }

        private void InstallPause()
        {
            Container.Bind<Pauser>().
                 AsSingle();
        }

        private void InstallGameOver()
        {
            Container.Bind<GameOverModel>().
                AsSingle();

            Container.BindInterfacesAndSelfTo<GameOverViewModel>().
                 AsSingle();
        }

        private void InstallTargetDefeatPoints()
        {
            Container.Bind<EnemiesDefeatPoints>().
                AsSingle();
        }

        private void InstallShip()
        {
            InstallModels();
            InstallViewModels();

            Container.Bind<ShipCollision>()
                .FromComponentInNewPrefab(_shipPrefab)
                .AsSingle()
                .NonLazy();

            Container.Bind<ShipStateUpdater>()
                .FromComponentOnRoot()
                .AsSingle()
                .WhenInjectedInto<ShipCollision>(); 

            Container.Bind<ShootingLaser>()
               .FromComponentOnRoot() 
                .AsSingle()
                .WhenInjectedInto<ShipCollision>();

            Container.Bind<ShootingBullets>()
                .FromComponentOnRoot() 
                .AsSingle()
                .WhenInjectedInto<ShipCollision>();
        }

        private void InstallViewModels()
        {
            Container.BindInterfacesAndSelfTo<LaserViewModel>().
                    AsSingle();
            Container.BindInterfacesAndSelfTo<ShipStateViewModel>().
                            AsSingle();
        }

        private void InstallModels()
        {
            Container.Bind<LaserModel>().
                AsSingle();

            Container.Bind<ShipStateModel>().
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

        private void InstallFactories()
        {
            InstallFragmentsFactory();
            InstallAsteroidsFactory();
            InstallUFOFactory();
            InstallBulletsFactory();
        }

        private void InstallUFOFactory()
        {
            //var point = Container.InstantiatePrefabForComponent<EnemiesSpawnPoint>(_UFOSpawnPointPrefab);
            var point = GameObject.Instantiate(_UFOSpawnPointPrefab);

            Container.BindInterfacesAndSelfTo<UFOFactory>().
                AsSingle().
                WithArguments(point.GetComponent<Transform>());
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
            //var point = Container.InstantiatePrefabForComponent<EnemiesSpawnPoint>(_astersSpawnPointPewfab);
            var point = GameObject.Instantiate(_astersSpawnPointPewfab);

            Container.BindInterfacesAndSelfTo<AsteroidsFactory>().
                AsSingle().
                WithArguments(point.GetComponent<Transform>());
        }
    }
}
