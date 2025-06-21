using System.Collections;
using UnityEngine;

public class EnemyFactory //: BaseEnemyFactory
{
    ////protected float _spawnPosLimit;
    ////protected Vector2 _screenLimits;
    ////protected float _spawnTime;

    ////private ICoroutineRunner _coroutineRunner;

    ////public EnemyFactory(GameStaticData staticData, ICoroutineRunner coroutineRunner, Transform spawnPoint) : base(staticData)
    ////{
    ////    _spawnPosLimit = staticData.SpawnPosLimit;
    ////    _screenLimits = staticData.ScreenLimits;

    ////    _coroutineRunner = coroutineRunner;
    ////    _spawnPoint = spawnPoint;

    ////    StartSpawn();
    ////}

    ////protected void StartSpawn()
    ////{
    ////    for (int i = _count; i > 0; i--)
    ////    {
    ////        Spawn(_spawnPoint);
    ////    }

    ////    _coroutineRunner.StartCoroutine(SpawnRoutine());
    ////}

    ////protected IEnumerator SpawnRoutine()
    ////{
    ////    while (true)
    ////    {
    ////        Spawn(_spawnPoint);
    ////        yield return new WaitForSeconds(_spawnTime);
    ////    }
    ////}

    ////protected float GenRandom()
    ////{
    ////    return Random.Range(-_spawnPosLimit, _spawnPosLimit);
    ////}

    ////protected override Transform GetSpawnPoint(Transform spawnPoint)
    ////{
    ////    var x = GenRandom();
    ////    while (x > -_screenLimits.x && x < _screenLimits.x)
    ////    {
    ////        x = GenRandom();
    ////    }

    ////    var y = GenRandom();
    ////    while (y > -_screenLimits.y && y < _screenLimits.y)
    ////    {
    ////        y = GenRandom();
    ////    }

    ////    var tr = _spawnPoint;//I know that transform is passed by reference and I change its position.
    ////                         //No problem, its position doesn't matter
    ////    tr.position = new Vector2(x, y);

    ////    return tr;
    ////}
}
