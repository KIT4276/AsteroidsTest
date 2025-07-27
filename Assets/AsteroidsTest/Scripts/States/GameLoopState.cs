using AsteroidsTest.Enemies;
using AsteroidsTest.Ship;
using System;

namespace AsteroidsTest.States
{
    public class GameLoopState : IState
    {
        private readonly BigEnemySpawner _bigEnemySpawner;

        public event Action GameStarted;

        public GameLoopState(BigEnemySpawner bigEnemySpawner)
        {
            _bigEnemySpawner = bigEnemySpawner;
        }

        public void Enter()
        {
            _bigEnemySpawner.OnGameStarted();
            GameStarted?.Invoke();
        }

        public void Exit() { }
    }
}
