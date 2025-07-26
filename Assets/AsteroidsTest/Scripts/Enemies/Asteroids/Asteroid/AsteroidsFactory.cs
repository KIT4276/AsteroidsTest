using AsteroidsTest.Enemies.Asteroids.Fragment;
using AsteroidsTest.Pause;
using AsteroidsTest.Services;
using AsteroidsTest.SOScripts;
using UnityEngine;

namespace AsteroidsTest.Enemies.Asteroids.Asteroid
{
    public class AsteroidsFactory : BigEnemyFactory
    {
        private FragmentsFactory _fragmentsFactory;
    
        public AsteroidsFactory(GameStaticData staticData, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints,
            Transform spawnPoint, FragmentsFactory fragmentsFactory, ICoroutineRunner coroutineRunner, Pauser pauser, BigEnemySpawner bigEnemySpawner)
            : base(staticData, defeatPointsData, targetDefeatPoints, coroutineRunner, spawnPoint, pauser, bigEnemySpawner)
        {
            _prefab = staticData.AsteroidPrefab;
    
            _spawnTime = staticData.AsteroidsSpawnTime;
            _count = staticData.AsteroidsStartCount;
    
            _spawnPoint = spawnPoint;
            _fragmentsFactory = fragmentsFactory;
            _coroutineRunner = coroutineRunner;
        }
    
        public override void StartSpawn()
        {
            for (int i = _count; i > 0; i--)
            {
                Spawn(_spawnPoint);
            }
    
            base.StartSpawn();
        }
    
        protected override void InitializeSpawnedObject(GameObject spawnedObject)
        {
            base.InitializeSpawnedObject(spawnedObject);
            spawnedObject.GetComponent<AsteroidCollision>().SetFactory(_fragmentsFactory);
            spawnedObject.GetComponent<PausableRegistrator>().Initialize(_pauser);
        }
    }
}
