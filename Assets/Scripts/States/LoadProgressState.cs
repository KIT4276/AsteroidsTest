using AsteroidsTest.SOScripts;

namespace AsteroidsTest.States
{
    public class LoadProgressState : IState
    {
        private const string Main = "GameScene";

        private readonly StateMachine _gameStateMachine;
        private readonly IPersistantProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly GameStaticData _gameStaticData;

        public LoadProgressState(StateMachine gameStateMachine, IPersistantProgressService progressService,
            ISaveLoadService saveLoadService, GameStaticData gameStaticData)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
             _saveLoadService = saveLoadService;

            _gameStaticData = gameStaticData;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositionOnLevel.Level);
        }

        public void Exit() { }

        private void LoadProgressOrInitNew() =>
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress(initialLevel: Main);

            progress.PlayerState.MaxHP = _gameStaticData.MaxHP;
            progress.PlayerStats.Damage = _gameStaticData.Damage;
            progress.PlayerStats.DamageRadius = _gameStaticData.DamageRadius;

            progress.PlayerState.ResetHP();

            return progress;
        }
    }
}
