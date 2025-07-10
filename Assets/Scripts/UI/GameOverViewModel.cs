using R3;
using System;

namespace AsteroidsTest.UI
{
    public class GameOverViewModel
    {
        public ReactiveProperty<string> Score { get; private set; }

        private GameOverModel _gameOverModel;

        public event Action GameOver;
        public event Action StartGame;

        public GameOverViewModel(GameOverModel gameOverModel)
        {
            Score = new();
            _gameOverModel = gameOverModel;

        }

        public void InitState()
        {
            _gameOverModel.IsGameOver.Subscribe(OnGameOverChanged);
            _gameOverModel.Points.Subscribe(OnPointsChange);

            OnGameOverChanged(_gameOverModel.IsGameOver.Value);
            OnPointsChange(_gameOverModel.Points.Value);
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
    }
}
