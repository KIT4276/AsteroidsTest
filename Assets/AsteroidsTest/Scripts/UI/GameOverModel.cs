using R3;
using UnityEditor;
using AsteroidsTest.Pause;
using AsteroidsTest.Services;
using AsteroidsTest.States;
using System;

namespace AsteroidsTest.UI
{
    public class GameOverModel
    {
        private ReactiveProperty<int> _points = new();
        private ReactiveProperty<bool> _isGameOver = new();

        private readonly Pauser _pauser;
        private readonly EnemiesDefeatPoints _enemiesDefeatPoints;
        private readonly StateMachine _stateMachine;

        public Observable<int> Points => _points.AsObservable();
        public Observable<bool> IsGameOver => _isGameOver.AsObservable();

        public event Action GameStoprd;
        public event Action GameResume;

        public GameOverModel(Pauser pauser, EnemiesDefeatPoints enemiesDefeatPoints,  StateMachine  stateMachine)
        {
            _pauser = pauser;
            _enemiesDefeatPoints = enemiesDefeatPoints;

            _isGameOver.Value = false;
            _stateMachine = stateMachine;
        }

        public void StopGame()
        {
            _pauser.Pause();
            _stateMachine.Enter<SaveProgressState>();
            _points.Value = _enemiesDefeatPoints.CurrentPoints;

            GameStoprd?.Invoke();
        }

        public void ContinueGame()
        {
            _pauser.Resume();
            GameResume?.Invoke();
        }

        public void GameOver()
        {
            _pauser.Pause();
            _isGameOver.Value = true;
            _points.Value = _enemiesDefeatPoints.CurrentPoints;
        }

        public void StartNewGame()
        {
            _isGameOver.Value = false;
            _stateMachine.Enter<BootstrapState>();
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
