using AsteroidsTest.Progress;
using AsteroidsTest.Save;
using AsteroidsTest.Save.Data;
using AsteroidsTest.Ship;

namespace AsteroidsTest.States
{
    public class LoadProgressState : IState
    {
        private readonly StateMachine _gameStateMachine;
        private readonly SaveLoadService _saveLoadService;
        private readonly ProgressService _progressService;
        private readonly ISavedProgressReader[] _progressReaders;
        private readonly ProgressReadersHolder _progressReadersHolder;

        public LoadProgressState(StateMachine gameStateMachine, ProgressService progressService, ISavedProgressReader[] progressReaders, ProgressReadersHolder progressReadersHolder,
            SaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _progressReaders = progressReaders;
            _progressReadersHolder = progressReadersHolder;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            RegisterProgressReaders();
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit() { }

        private void RegisterProgressReaders()
        {
            foreach (var progressReader in _progressReaders)
                _progressReadersHolder.Register(progressReader);
        }

        private void LoadProgressOrInitNew() =>
            _progressService.Progress = _saveLoadService.LoadProgress();
    }
}
