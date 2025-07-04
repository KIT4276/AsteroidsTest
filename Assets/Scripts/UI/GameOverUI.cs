using TMPro;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private TMP_Text _points;

        private EnemiesDefeatPoints _enemiesDefeatPoints;
        private GameOver _gameOver;

        [Inject]
        private void PseudoConstruct(GameOver gameOver, EnemiesDefeatPoints enemiesDefeatPoints)
        {
            _enemiesDefeatPoints = enemiesDefeatPoints;
            _gameOver = gameOver;
            _gameOver.GameOverAction += OnGameOver;
        }

        private void Start()
        {
            _mainPanel.SetActive(true);
            _gameOverPanel.SetActive(false);
        }

        private void OnGameOver()
        {
            _gameOverPanel.SetActive(true);
            _mainPanel.SetActive(false);
            _points.text = "SCORE: " + _enemiesDefeatPoints.CurrentPoints.ToString();
        }

        private void OnDestroy()
        {
            _gameOver.GameOverAction -= OnGameOver;
        }
    }
}
