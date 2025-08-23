using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AsteroidsTest.Services
{
    public class SceneLoader : ISceneLoader
    {
        private const string GameSceneName = "GameScene";
        private const string BootstrapSceneName = "BootstrapScene";
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void LoadMainGameScene(Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(GameSceneName, onLoaded));

        public void LoadBootstrapScene(Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(BootstrapSceneName, onLoaded));

        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            yield return new WaitUntil(() => waitNextScene.isDone);

            onLoaded?.Invoke();
        }
    }
}
