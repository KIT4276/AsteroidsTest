using UnityEngine;
using Zenject;

public class UFOFactory : BigEnemyFactory
{
    private ShipCollision _shipCollision;

    public UFOFactory(GameStaticData staticData, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints, 
        ICoroutineRunner coroutineRunner, Transform spawnPoint, ShipCollision shipCollision, Pauser pauser) :
        base(staticData, defeatPointsData, targetDefeatPoints, coroutineRunner, spawnPoint, pauser)
    {
        _prefab = staticData.UFOPrefab;
        _spawnTime = staticData.UFOSpawnTime;
        _shipCollision = shipCollision;
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

        spawnedObject.GetComponent<UFOCollision>().Initialize(this, _defeatPointsData, _targetDefeatPoints);
        spawnedObject.GetComponent<PausableRegistrator>().Initialize(_pauser);
    }
}

