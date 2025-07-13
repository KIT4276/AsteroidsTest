using R3;
using System;
using Zenject;

namespace AsteroidsTest.UI
{
    public class GameOverViewModel : IInitializable, IDisposable
    {
        public ReactiveProperty<string> Score { get; private set; }

        private IDisposable _gameOverSub;
        private IDisposable _pointsSub;

        private GameOverModel _gameOverModel;

        public event Action GameOver;
        public event Action StartGame;

        public GameOverViewModel(GameOverModel gameOverModel)
        {
            Score = new();
            _gameOverModel = gameOverModel;
        }

        public void Initialize()
        {
            _gameOverSub = _gameOverModel.IsGameOver.Subscribe(OnGameOverChanged);
            _pointsSub = _gameOverModel.Points.Subscribe(OnPointsChange);
        }

        public void StartNewGame() =>
            _gameOverModel.StartNewGame();

        public void QuitGame() =>
            _gameOverModel.QuitGame();

        private void OnPointsChange(int points)
        {
            Score.Value = "SCORE: " + points;
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
        }
    }
}
