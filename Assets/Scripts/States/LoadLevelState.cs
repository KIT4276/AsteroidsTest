using AsteroidsTest.Services;

namespace AsteroidsTest.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
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
            //foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            //    progressReader.LoadProgress(_progressService.Progress);

            //TODO
        }

        private void InitGameWorld()
        {
            //How can I start spawning enemies from here?!
        }
    }
}
