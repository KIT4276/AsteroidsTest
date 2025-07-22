using System;

namespace AsteroidsTest.Enemies
{
    public class BigEnemySpawner
    {
        public event Action GameStarted;


        public void OnGameStarted()
        {
            GameStarted?.Invoke();
        }
    }
}