using System;
using System.Collections;

namespace AsteroidsTest.Services
{
    public interface ISceneLoader
    {
        public void LoadMainGameScene(Action onLoaded);
        public void LoadBootstrapScene(Action onLoaded);
    }
}