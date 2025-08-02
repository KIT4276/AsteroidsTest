using AsteroidsTest.Factories;
using AsteroidsTest.Progress;
using AsteroidsTest.Services;

namespace AsteroidsTest.States
{
    public class LoadLevelState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly UIFactory _uIFactory;

        public LoadLevelState(StateMachine stateMachine, ISceneLoader sceneLoader, UIFactory uIFactory, ProgressReadersHolder progressReadersHolder)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uIFactory = uIFactory;
        }

        public void Enter()
        {
            _sceneLoader.LoadMainGameScene(OnLoaded);
        }

        public void Exit() { }

        private void OnLoaded()
        {
            _uIFactory.CreateMainUI();

            _stateMachine.Enter<GameLoopState>();
        }
    }
}
