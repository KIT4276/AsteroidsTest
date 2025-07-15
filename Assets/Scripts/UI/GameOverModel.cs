using R3;
using UnityEditor;
using AsteroidsTest.Pause;
using AsteroidsTest.Services;

namespace AsteroidsTest.UI
{
    public class GameOverModel
    {
        private ReactiveProperty<int> _points = new();
        private ReactiveProperty<bool> _isGameOver = new();

        public Observable<int> Points => _points.AsObservable();
        public Observable<bool> IsGameOver => _isGameOver.AsObservable();

        private readonly Pauser _pauser;
        private EnemiesDefeatPoints _enemiesDefeatPoints;
        private SceneLoader _sceneLoader;

        public GameOverModel(Pauser pauser, EnemiesDefeatPoints enemiesDefeatPoints, SceneLoader sceneLoader)
        {
            _pauser = pauser;
            _enemiesDefeatPoints = enemiesDefeatPoints;

            _isGameOver.Value = false;
            _sceneLoader = sceneLoader;
        }

        public void GameOver()
        {
            _pauser.Pause();
            _isGameOver.Value = true;
            _points.Value = _enemiesDefeatPoints.CurrentPoints;
        }

        public void StartNewGame()
        {
            _isGameOver.Value = false;

            //_sceneLoader.LoadGameScene();
            //TODO LoadGameScene throw state machine
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
