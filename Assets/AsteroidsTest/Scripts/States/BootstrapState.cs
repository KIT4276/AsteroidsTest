using AsteroidsTest.Enemies.Asteroids.Asteroid;
using AsteroidsTest.Enemies.UFO;
using AsteroidsTest.Factories;
using AsteroidsTest.Progress;
using AsteroidsTest.Save.Data;
using AsteroidsTest.Services;
using AsteroidsTest.Ship;
using AsteroidsTest.Weapon.Bullet;
using System;
using UnityEngine;

namespace AsteroidsTest.States
{
    public class BootstrapState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly UIFactory _uiFactory;
        private readonly BulletsFactory _bulletsFactory;
        private readonly AsteroidsFactory _asteroidsFactory;
        private readonly UFOFactory _uFOFactory;
        private readonly ISavedProgress[] _savedProgress;
        private readonly ProgressReadersHolder _progressReadersHolder;

        public event Action Bootstrap;

        public BootstrapState(StateMachine stateMachine, ISceneLoader sceneLoader, ProgressReadersHolder progressReadersHolder,
            UIFactory uiFactory, BulletsFactory bulletsFactory, AsteroidsFactory asteroidsFactory, UFOFactory uFOFactory,
            ISavedProgress[] savedProgress)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _bulletsFactory = bulletsFactory;
            _asteroidsFactory = asteroidsFactory;
            _uFOFactory = uFOFactory;
            _savedProgress = savedProgress;
            _progressReadersHolder = progressReadersHolder;
        }

        public void Enter()
        {
            RestartFactories();
            //Debug.Log(_savedProgress.Length);
            foreach (var item in _savedProgress)
                item.Restart();

            _progressReadersHolder.ClearAll();
            _sceneLoader.LoadBootstrapScene(onLoaded: EnterLoadLevel);
            Bootstrap?.Invoke();
        }

        public void Exit() { }

        private void RestartFactories()
        {
            _bulletsFactory.Restart();
            _asteroidsFactory.Restart();
            _uFOFactory.Restart();
        }

        private void EnterLoadLevel() =>
            InstallStartMenu();

        private void InstallStartMenu() =>
            _uiFactory.CreateStartMenu().OnStarted += ContinueLoad;

        private void ContinueLoad() =>
            _stateMachine.Enter<LoadProgressState>();
    }
}
