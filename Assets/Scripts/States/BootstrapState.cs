using AsteroidsTest.Factories;
using AsteroidsTest.Services;

namespace AsteroidsTest.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "BootstrapScene";

        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UIFactory _uiFactory;

        public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader,
            UIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter() =>
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);

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
