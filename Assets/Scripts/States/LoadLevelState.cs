using AsteroidsTest.Factories;
using AsteroidsTest.Progress;
using AsteroidsTest.Save.Data;
using AsteroidsTest.Services;

namespace AsteroidsTest.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UIFactory _uIFactory;

        public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader, UIFactory uIFactory, ProgressReadersHolder progressReadersHolder)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uIFactory = uIFactory;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() { }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {

            //TODO
        }

        private void InitGameWorld()
        {
            _uIFactory.CreateMainUI();

           
        }
    }
}
