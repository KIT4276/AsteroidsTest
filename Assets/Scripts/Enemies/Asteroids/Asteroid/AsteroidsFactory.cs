using System.Collections;
using UnityEngine;

public class AsteroidsFactory : BaseEnemyFactory
{
    private float _spawnPosLimit;
    private Vector2 _screenLimits;
    private float _spawnTime;

    private FragmentsFactory _fragmentsFactory;

    protected ICoroutineRunner _coroutineRunner;

    public AsteroidsFactory(GameStaticData staticData, Transform spawnPoint, FragmentsFactory fragmentsFactory, ICoroutineRunner coroutineRunner)
        : base(staticData)
    {
        _prefab = staticData.AsteroidPrefab;
        _spawnPosLimit = staticData.SpawnPosLimit;
        _screenLimits = staticData.ScreenLimits;
        _spawnTime = staticData.AsteroidsSpawnTime;
        _count = staticData.AsteroidsStartCount;

        _spawnPoint = spawnPoint;
        _fragmentsFactory = fragmentsFactory;
        _coroutineRunner = coroutineRunner;

        StartSpawn();
    }

    private void StartSpawn()
    {
        for (int i = _count; i > 0; i--)
        {
            Spawn(_spawnPoint);
        }

        _coroutineRunner.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn(_spawnPoint);
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private float GenRandom()
    {
        return Random.Range(-_spawnPosLimit, _spawnPosLimit);
    }

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

    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        base.InitializeSpawnedObject(spawnedObject);
        spawnedObject.GetComponent<AsteroidCollision>().SetFactory(_fragmentsFactory);
    }
}
