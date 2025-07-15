using AsteroidsTest.Progress;
using AsteroidsTest.Save;
using AsteroidsTest.Save.Data;

namespace AsteroidsTest.States
{
    public class LoadProgressState : IState
    {
        private const string Main = "GameScene";

        private readonly StateMachine _gameStateMachine;
        private readonly SaveLoadService _saveLoadService;
        private readonly ProgressService _progressService;

        public LoadProgressState(StateMachine gameStateMachine, ProgressService progressService,
            SaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
             _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(Main);
        }

        public void Exit() { }

        private void LoadProgressOrInitNew() =>
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress();
        }
    }
}
