using TMPro;
using UnityEngine;
using R3;
using System;

namespace AsteroidsTest.UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private TMP_Text _points;

        private IDisposable _scoreSub;

        private GameOverViewModel _gameOverViewModel;

        public void Initialize(GameOverViewModel gameOverViewModel)
        {
            _gameOverViewModel = gameOverViewModel;

            _gameOverViewModel.GameOver += OnGameOver;
            _gameOverViewModel.StartGame += OnGameStarted;
            _scoreSub = _gameOverViewModel.Score.Subscribe(OnScoreChanged);

            OnGameStarted();
        }

        public void NewGame()
        {
            _gameOverViewModel.StartNewGame();
        }

        public void Quit()
        {
            _gameOverViewModel.QuitGame();
        }

        private void OnScoreChanged(string score)
        {
            _points.text = score;
        }

        private void OnGameStarted()
        {
            _mainPanel.SetActive(true);
            _gameOverPanel.SetActive(false);
        }

        private void OnGameOver()
        {
            _gameOverPanel.SetActive(true);
            _mainPanel.SetActive(false);
        }

        private void OnDisable()
        {
            _gameOverViewModel.GameOver -= OnGameOver;
            _gameOverViewModel.StartGame -= OnGameStarted;
            _scoreSub?.Dispose();
        }
    }
}
