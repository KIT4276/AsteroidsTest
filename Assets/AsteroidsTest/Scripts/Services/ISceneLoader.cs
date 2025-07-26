using System;
using System.Collections;

namespace AsteroidsTest.Services
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLoaded = null);

        IEnumerator LoadScene(string name, Action onLoaded = null);
    }
}