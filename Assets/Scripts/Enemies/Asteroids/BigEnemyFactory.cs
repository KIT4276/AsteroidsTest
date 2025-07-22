using AsteroidsTest.Pause;
using AsteroidsTest.Services;
using AsteroidsTest.SOScripts;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Enemies.Asteroids
{
    public class BigEnemyFactory : BaseEnemyFactory, IInitializable, IPausable, IDisposable
    {
        protected ICoroutineRunner _coroutineRunner;
        protected BigEnemySpawner _bigEnemySpawner;
        protected float _spawnTime;
        protected float _spawnPosLimit;
        protected Vector2 _screenLimits;
        private Coroutine _spawnCoroutine;

        private bool _canSpawn = false;
    
        protected BigEnemyFactory(GameStaticData staticData, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints,
            ICoroutineRunner coroutineRunner, Transform spawnPoint, Pauser pauser, BigEnemySpawner bigEnemySpawner)
            : base(staticData, defeatPointsData, targetDefeatPoints, pauser)
        {
            _spawnPosLimit = staticData.SpawnPosLimit;
            _screenLimits = staticData.ScreenLimits;
    
            _coroutineRunner = coroutineRunner;
            _bigEnemySpawner = bigEnemySpawner;
            _spawnPoint = spawnPoint;
        }
    
        public void Initialize()
        {
            _canSpawn = true;
           
            _pauser.Register(this);
            _bigEnemySpawner.GameStarted += StartSpawn;
        }

        public void Pause()
        {
            if (_spawnCoroutine != null)
            {
                _coroutineRunner.StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }
    
        public void Resume()
        {
            if (_spawnCoroutine == null)
                StartSpawn();
        }
    
        public virtual void StartSpawn()
        {
            _spawnCoroutine = _coroutineRunner.StartCoroutine(SpawnRoutine());
        }
    
        public override void Spawn(Transform spawnTransform)
        {
            base.Spawn(spawnTransform);
            _spawnedObject.transform.position = GetSpawnPoint(_spawnPoint).position;
        }
    
    
        protected IEnumerator SpawnRoutine()
        {
            while (_canSpawn)
            {
                Spawn(_spawnPoint);
                yield return new WaitForSeconds(_spawnTime);
            }
        }

        protected float GenRandom() =>
            UnityEngine.Random.Range(-_spawnPosLimit, _spawnPosLimit);

        protected override Transform GetSpawnPoint(Transform spawnPoint)
        {
            var x = GenRandom();
            while (x > -_screenLimits.x && x < _screenLimits.x)
            {
                x = GenRandom();
            }
    
            var y = GenRandom();
            while (y > -_screenLimits.y && y < _screenLimits.y)
            {
                y = GenRandom();
            }
    
            var tr = _spawnPoint;//I know that transform is passed by reference and I change its position.
                                 //No problem, its position doesn't matter
            tr.position = new Vector2(x, y);
    
            return tr;
        }

        public void Dispose()
        {
            _canSpawn = false;
            _bigEnemySpawner.GameStarted -= StartSpawn;
        }
    }
}
