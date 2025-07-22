using AsteroidsTest.Enemies.Asteroids.Asteroid;
using AsteroidsTest.Enemies.UFO;
using AsteroidsTest.States;
using System;
using Zenject;

namespace AsteroidsTest.Enemies
{
    public class BigEnemySpawner//: IInitializable
    {
        //private readonly GameLoopState _gameLoopState;
        //private readonly UFOFactory _uFOFactory;
        //private readonly AsteroidsFactory _asteroidsFactory;

        public event Action GameStarted;

        public BigEnemySpawner(/*GameLoopState gameLoopState, UFOFactory uFOFactory, AsteroidsFactory asteroidsFactory*/)
        {
           // _gameLoopState = gameLoopState;
           //_uFOFactory = uFOFactory;
           // _asteroidsFactory = asteroidsFactory;
        }

        //public void Initialize()
        //{
        //    _gameLoopState.GameStarted += OnGameStarted;
        //}

        public void OnGameStarted()
        {
            //_uFOFactory.StartSpawn();
            //_asteroidsFactory.StartSpawn();

            GameStarted?.Invoke();
        }
    }
}