using R3;
using System;
using Zenject;

namespace AsteroidsTest.UI
{
    public class GameOverViewModel : IInitializable, IDisposable
    {
        private ReactiveProperty<string> _score = new();

        public Observable<string> Score => _score.AsObservable();

        private IDisposable _gameOverSub;
        private IDisposable _pointsSub;

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
            _gameOverModel.GameStoprd += OnGameStoped;
            _gameOverModel.GameResume += OnGameContinued;
        }

        public void StopGame()
        {
            _gameOverModel.StopGame();
        }

        public void ContinueGame()
        {
            _gameOverModel.ContinueGame();
        }

        public void StartNewGame() =>
            _gameOverModel.StartNewGame();

        public void QuitGame() =>
            _gameOverModel.QuitGame();

        public void Dispose()
        {
            _gameOverSub?.Dispose();
            _pointsSub?.Dispose();
            _gameOverModel.GameStoprd -= OnGameStoped;
        }


        private void OnGameContinued()
        {
            StartGame?.Invoke();
        }

        private void OnGameStoped()
        {
            GameStoprd?.Invoke();
        }
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
    }
}
