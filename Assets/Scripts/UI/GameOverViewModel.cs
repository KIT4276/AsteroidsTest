using R3;
using System;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.UI
{
    public class GameOverViewModel : IInitializable, IDisposable
    {
        private ReactiveProperty<string> _score = new();

        public Observable<string> Score => _score.AsObservable();

        private IDisposable _gameOverSub;
        private IDisposable _pointsSub;
       // private IDisposable _stopGameSub;

        private GameOverModel _gameOverModel;

        public event Action GameOver;
        public event Action StartGame;
        public event Action GameStoprd;

        public GameOverViewModel(GameOverModel gameOverModel)
        {
            _gameOverModel = gameOverModel;
        }

        public void Initialize()
        {
            _gameOverSub = _gameOverModel.IsGameOver.Subscribe(OnGameOverChanged);
            _pointsSub = _gameOverModel.Points.Subscribe(OnPointsChange);
            //_stopGameSub = _gameOverModel.IsGameStoped.Subscribe(OnGameStoped);
            _gameOverModel.GameStoprd += OnGameStoped;
            _gameOverModel.GameResume += OnGameContinued;
        }

        private void OnGameContinued()
        {
            StartGame?.Invoke();
        }

        public void StopGame()
        {
            _gameOverModel.StopGame();
        }

        public void ContinueGame()
        {
            _gameOverModel.ContinueGame();
        }

        private void OnGameStoped()
        {
            GameStoprd?.Invoke();
        }

        public void StartNewGame() =>
            _gameOverModel.StartNewGame();

        public void QuitGame() =>
            _gameOverModel.QuitGame();

        private void OnPointsChange(int points)
        {
            _score.Value = "SCORE: " + points;
        }

        private void OnGameOverChanged(bool isGameOver)
        {
            if (isGameOver)
            {
                GameOver?.Invoke();
            }
            else
            {
                StartGame?.Invoke();
            }
        }

        public void Dispose()
        {
            _gameOverSub?.Dispose();
            _pointsSub?.Dispose();
            _gameOverModel.GameStoprd -= OnGameStoped;
        }

    }
}
