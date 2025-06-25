using System;
using UnityEngine;

public class UFOFactory : BigEnemyFactory
{
    private ShipCollision  _shipCollision;

    public UFOFactory(GameStaticData staticData, ICoroutineRunner coroutineRunner, Transform spawnPoint, ShipCollision shipCollision) : 
        base(staticData, coroutineRunner, spawnPoint)
    {
        _prefab = staticData.UFOPrefab;
        _count = staticData.UFOStartCount;
        _spawnTime = staticData.UFOSpawnTime;

        _shipCollision = shipCollision;

        _spawnPosLimit = staticData.SpawnPosLimit;
        _screenLimits = staticData.ScreenLimits;

        StartSpawn();
    }

    protected override Transform GetSpawnPoint(Transform spawnPoint)
    {
        return spawnPoint;
    }


    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        var ufo = spawnedObject.GetComponent<UFOMove>();
        ufo.SetTarget( _shipCollision);
        ufo.Initialize(_spawnPoint, this, _staticData);

        spawnedObject.GetComponent<UFOCollision>().Initialize(this);
    }
}
