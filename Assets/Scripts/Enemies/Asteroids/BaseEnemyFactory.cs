using UnityEngine;

public abstract class BaseEnemyFactory : BaseFactory
{
    protected int _count = 15;
    protected Transform _spawnPoint;

    protected BaseEnemyFactory(GameStaticData staticData) : base(staticData)
    {
    }

    protected override Transform GetSpawnPoint(Transform transform)
    {
        return transform;
    }

    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        spawnedObject.GetComponent<IMove>().Initialize(GetSpawnPoint(_spawnPoint), this, _staticData);
        spawnedObject.GetComponent<BaseEnemyCollision>().Initialize(this);
    }
}
