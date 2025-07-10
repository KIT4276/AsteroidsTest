using R3;
using UnityEditor;
using AsteroidsTest.Pause;

namespace AsteroidsTest.UI
{
    public class GameOverModel
    {
        public ReactiveProperty<int> Points { get; private set; }
        public ReactiveProperty<bool> IsGameOver { get; private set; }

        private readonly Pauser _pauser;
        private EnemiesDefeatPoints _enemiesDefeatPoints;
        private SceneLoader _sceneLoader;

        public GameOverModel(Pauser pauser, EnemiesDefeatPoints enemiesDefeatPoints, SceneLoader sceneLoader)
        {
            _pauser = pauser;
            _enemiesDefeatPoints = enemiesDefeatPoints;

            Points = new();
            IsGameOver = new();

            IsGameOver.Value = false;
            _sceneLoader = sceneLoader;
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

            _sceneLoader.LoadGameScene();
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
