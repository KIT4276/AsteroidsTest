using System;
using UnityEngine;

public abstract class BaseEnemyFactory : BaseFactory
{
    protected int _count = 15;
    protected Transform _spawnPoint;
    protected DefeatPointsData _defeatPointsData;
    protected TargetDefeatPoints _targetDefeatPoints;

    public event Action<IDamageable> Spawned;


    protected BaseEnemyFactory(GameStaticData staticData, DefeatPointsData defeatPointsData, TargetDefeatPoints targetDefeatPoints) 
        : base(staticData)
    {
        _defeatPointsData = defeatPointsData;
        _targetDefeatPoints = targetDefeatPoints;
    }

    public override void Spawn(Transform spawnTransform)
    {
        base.Spawn(spawnTransform);
        Spawned?.Invoke(_spawnedObject.GetComponent<IDamageable>());
    }
    protected override Transform GetSpawnPoint(Transform transform)
    {
        return transform;
    }

    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        spawnedObject.GetComponent<IMove>().Initialize(GetSpawnPoint(_spawnPoint), this, _staticData);
        spawnedObject.GetComponent<BaseEnemyCollision>().Initialize(this, _defeatPointsData, _targetDefeatPoints);
    }
}
