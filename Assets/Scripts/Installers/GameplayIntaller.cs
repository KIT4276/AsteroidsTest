using AsteroidsTest.Enemies.Asteroids.Asteroid;
using AsteroidsTest.Enemies.Asteroids.Fragment;
using AsteroidsTest.Enemies.UFO;
using AsteroidsTest.Input;
using AsteroidsTest.Pause;
using AsteroidsTest.Services;
using AsteroidsTest.Ship;
using AsteroidsTest.SOScripts;
using AsteroidsTest.UI;
using AsteroidsTest.Weapon.Bullet;
using AsteroidsTest.Weapon.Laser;
using System;
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

            InstallGameOver();
            InstallTargetDefeatPoints();
            InstallData();
            InstallFactories();
            InstallShip();

            InstallMainUI();
        }

        private void InstallMainUI()
        {
            var ui = Container.InstantiatePrefabForComponent<GameOverView>(_mainUIPrefab);

            Container.Bind<GameOverView>().FromInstance(ui).AsSingle();
            Container.Bind<ShipStateView>().FromInstance(ui.GetComponent<ShipStateView>()).AsSingle();
            Container.Bind<LaserView>().FromInstance(ui.GetComponent<LaserView>()).AsSingle();
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

            _ship = Container.InstantiatePrefabForComponent<ShipCollision>(_shipPrefab);
            // GameObject ship = Instantiate(_shipPrefab, Vector3.zero, Quaternion.identity);
            Container.Bind<ShipCollision>().
                FromInstance(_ship.GetComponent<ShipCollision>()).
                AsSingle();

            Container.Bind<ShipStateUpdater>().
                FromInstance(_ship.GetComponent<ShipStateUpdater>()).
                AsSingle();

            Container.Bind<ShootingLaser>().FromInstance(_ship.GetComponent<ShootingLaser>()).AsSingle();
            Container.Bind<ShootingBullets>().FromInstance(_ship.GetComponent<ShootingBullets>()).AsSingle();
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
            Container.BindInterfacesAndSelfTo<UFOFactory>().
                AsSingle().
                WithArguments(GameObject.Instantiate(_UFOSpawnPointPrefab.GetComponent<Transform>()));
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
                WithArguments(GameObject.Instantiate(_astersSpawnPointPewfab).GetComponent<Transform>());
        }
    }
}
