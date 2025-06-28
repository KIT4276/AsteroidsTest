using UnityEngine;

public class AsteroidsFactory : BigEnemyFactory
{
    private FragmentsFactory _fragmentsFactory;

    public AsteroidsFactory(GameStaticData staticData, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints,
        Transform spawnPoint, FragmentsFactory fragmentsFactory, ICoroutineRunner coroutineRunner)
        : base(staticData, defeatPointsData, targetDefeatPoints, coroutineRunner, spawnPoint)
    {
        _prefab = staticData.AsteroidPrefab;

        _spawnTime = staticData.AsteroidsSpawnTime;
        _count = staticData.AsteroidsStartCount;

        _spawnPoint = spawnPoint;
        _fragmentsFactory = fragmentsFactory;
        _coroutineRunner = coroutineRunner;

        StartSpawn();
    }

    

    protected override void StartSpawn()
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
    }
}
