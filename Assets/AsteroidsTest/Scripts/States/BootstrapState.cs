using AsteroidsTest.Enemies.Asteroids.Asteroid;
using AsteroidsTest.Enemies.UFO;
using AsteroidsTest.Factories;
using AsteroidsTest.Progress;
using AsteroidsTest.Services;
using AsteroidsTest.Weapon.Bullet;

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
        private readonly ProgressReadersHolder _progressReadersHolder;

        public BootstrapState(StateMachine stateMachine, ISceneLoader sceneLoader, ProgressReadersHolder progressReadersHolder,
            UIFactory uiFactory, BulletsFactory bulletsFactory, AsteroidsFactory asteroidsFactory, UFOFactory uFOFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _bulletsFactory = bulletsFactory;
            _asteroidsFactory = asteroidsFactory;
            _uFOFactory = uFOFactory;
            _progressReadersHolder = progressReadersHolder;
        }

        public void Enter()
        {
            RestartFactories();
            _progressReadersHolder.ClearAll();
            _sceneLoader.LoadBootstrapScene(onLoaded: EnterLoadLevel);
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

        private void ContinueLoad()
        {
            _stateMachine.Enter<LoadProgressState>();
        }
    }
}
