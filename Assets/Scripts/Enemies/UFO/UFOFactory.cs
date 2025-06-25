using UnityEngine;

public class UFOFactory : BigEnemyFactory
{
    private ShipCollision _shipCollision;

    public UFOFactory(GameStaticData staticData, ICoroutineRunner coroutineRunner, Transform spawnPoint, ShipCollision shipCollision) :
        base(staticData, coroutineRunner, spawnPoint)
    {
        _prefab = staticData.UFOPrefab;
        _spawnTime = staticData.UFOSpawnTime;

        _shipCollision = shipCollision;

        StartSpawn();
    }

    protected override Transform GetSpawnPoint(Transform spawnPoint)
    {
        return base.GetSpawnPoint(spawnPoint);
    }


    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        var ufo = spawnedObject.GetComponent<UFOMove>();
        ufo.SetTarget(_shipCollision);
        ufo.Initialize(_spawnPoint, this, _staticData);

        spawnedObject.GetComponent<UFOCollision>().Initialize(this);
    }
}

