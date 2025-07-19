using AsteroidsTest.Enemies.Asteroids.Asteroid;
using AsteroidsTest.Enemies.UFO;
using AsteroidsTest.States;
using System.Diagnostics;
using Zenject;

namespace AsteroidsTest.Enemies
{
    public class BigEnemySpawner: IInitializable
    {
        private readonly GameLoopState _gameLoopState;
        private readonly UFOFactory _uFOFactory;
        private readonly AsteroidsFactory _asteroidsFactory;

        public BigEnemySpawner(GameLoopState gameLoopState, UFOFactory uFOFactory, AsteroidsFactory asteroidsFactory)
        {
            _gameLoopState = gameLoopState;
           _uFOFactory = uFOFactory;
            _asteroidsFactory = asteroidsFactory;
        }

        public void Initialize()
        {
            _gameLoopState.GameStarted += OnGameStarted;
        }

        private void OnGameStarted()
        {
            _uFOFactory.StartSpawn();
            _asteroidsFactory.StartSpawn();
        }
    }
}