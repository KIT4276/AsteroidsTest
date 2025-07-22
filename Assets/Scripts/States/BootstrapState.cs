using AsteroidsTest.Enemies.Asteroids.Asteroid;
using AsteroidsTest.Enemies.UFO;
using AsteroidsTest.Factories;
using AsteroidsTest.Services;
using AsteroidsTest.Weapon.Bullet;

namespace AsteroidsTest.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "BootstrapScene";

        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UIFactory _uiFactory;
        private readonly BulletsFactory _bulletsFactory;
        private readonly AsteroidsFactory _asteroidsFactory;
        private readonly UFOFactory _uFOFactory;

        public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader,
            UIFactory uiFactory, BulletsFactory bulletsFactory, AsteroidsFactory asteroidsFactory, UFOFactory uFOFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _bulletsFactory = bulletsFactory;
            _asteroidsFactory = asteroidsFactory;
            _uFOFactory = uFOFactory;
        }

        public void Enter()
        {
            RestartFactories();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void RestartFactories()
        {
            _bulletsFactory.Restart();
            _asteroidsFactory.Restart();
            _uFOFactory.Restart();
        }

        public void Exit() { }

        private void EnterLoadLevel()
        {
            InstallStartMenu();
        }

        private void InstallStartMenu() =>
            _uiFactory.CreateStartMenu().OnStarted += ContinueLoad;


        private void ContinueLoad()
        {
            _stateMachine.Enter<LoadProgressState>();
        }
    }
}
