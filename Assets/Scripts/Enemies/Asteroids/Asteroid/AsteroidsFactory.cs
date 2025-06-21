using System.Collections;
using UnityEngine;

public class AsteroidsFactory : BaseAsteroidsFactory
{
    private float _spawnPosLimit = 1000;
    private Vector2 _screenLimits = new Vector2(11.2f, 5.25f);
    private float _spawnTime = 3;

    private FragmentsFactory _fragmentsFactory;

    protected ICoroutineRunner _coroutineRunner;

    public AsteroidsFactory(GameStaticData staticData, Transform spawnPoint,FragmentsFactory fragmentsFactory, ICoroutineRunner coroutineRunner)
        : base(staticData)
    {
        _prefab = staticData.AsteroidPrefab;
        _spawnPosLimit = staticData.AsteroidsSpawnPosLimit;
        _screenLimits = staticData.AsteroidsScreenLimits;
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
