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
        [SerializeField] private GameObject _stopGamePanel;

        private IDisposable _scoreSub;

        private GameOverViewModel _gameOverViewModel;

        public void Initialize(GameOverViewModel gameOverViewModel)
        {
            _gameOverViewModel = gameOverViewModel;

            _gameOverViewModel.GameOver += OnGameOver;
            _gameOverViewModel.StartGame += OnGameStarted;
            _scoreSub = _gameOverViewModel.Score.Subscribe(OnScoreChanged);
            _gameOverViewModel.GameStoprd += OnGameStoped;

            OnGameStarted();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                StopGame();
            }
        }

        private void OnGameStoped()
        {
            _gameOverPanel.SetActive(true);
            _stopGamePanel.SetActive(true);
        }

        private void StopGame()
        {
            _gameOverViewModel.StopGame();
        }

        public void ContinueGame()
        {
            _gameOverViewModel.ContinueGame();
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
            _stopGamePanel.SetActive(false);
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
            _gameOverViewModel.GameStoprd -= OnGameStoped;
        }
    }
}
