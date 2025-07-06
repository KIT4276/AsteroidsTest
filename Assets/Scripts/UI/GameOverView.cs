using TMPro;
using UnityEngine;
using R3;
using Zenject;

namespace AsteroidsTest.UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private TMP_Text _points;

        private GameOverViewModel _gameOverViewModel;

        [Inject]
        public void Construct(GameOverModel gameOverModel)
        {
            _gameOverViewModel = new(gameOverModel);

            _gameOverViewModel.GameOver += OnGameOver;
            _gameOverViewModel.StartGame += OnGameStarted;
            _gameOverViewModel.Score.Subscribe(OnScoreChanged);

            _gameOverViewModel.InitState();
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
    }
}
