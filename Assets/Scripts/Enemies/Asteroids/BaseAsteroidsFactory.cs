using UnityEngine;

public abstract class BaseAsteroidsFactory : BaseFactory
{
    protected int _count = 15;
    protected Transform _spawnPoint;

    protected BaseAsteroidsFactory(GameStaticData staticData) : base(staticData)
    {
    }

    protected override Transform GetSpawnPoint(Transform transform)
    {
        return transform;
    }

    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        spawnedObject.GetComponent<IMove>().Initialize(GetSpawnPoint(_spawnPoint), this);
        spawnedObject.GetComponent<BaseAsteroidCollision>().Initialize(this);
    }
}
