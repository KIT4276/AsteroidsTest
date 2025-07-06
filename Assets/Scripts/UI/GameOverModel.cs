using UnityEngine;
using R3;
using UnityEditor;
using UnityEngine.SceneManagement;
using AsteroidsTest.Pause;

namespace AsteroidsTest.UI
{
    public class GameOverModel
    {
        public ReactiveProperty<int> Points { get; private set; }
        public ReactiveProperty<bool> IsGameOver { get; private set; }

        private readonly Pauser _pauser;
        private EnemiesDefeatPoints _enemiesDefeatPoints;

        public GameOverModel(Pauser pauser, EnemiesDefeatPoints enemiesDefeatPoints)
        {
            _pauser = pauser;
            _enemiesDefeatPoints = enemiesDefeatPoints;

            Points = new();
            IsGameOver = new();

            IsGameOver.Value = false;
        }

        public void GameOver()
        {
            _pauser.Pause();
            IsGameOver.Value = true;
            Points.Value = _enemiesDefeatPoints.CurrentPoints;
        }

        public void StartNewGame()
        {
            IsGameOver.Value = false;

            SceneManager.LoadScene(0);
            Time.timeScale = 1;
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
