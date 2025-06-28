using System;
using UnityEngine;

public abstract class BaseEnemyCollision : MonoBehaviour, IDamageable
{
    protected BaseFactory _factory;
    protected TargetDefeatPoints _targetDefeatPoints;
    protected int _defeatPoints;

    public virtual void Initialize(BaseFactory factory, DefeatPointsData defeatPointsData, TargetDefeatPoints targetDefeatPoints)
    {
        _factory = factory;
        _targetDefeatPoints = targetDefeatPoints;
    }

    public void TakeBulletDamage()
    {
        OnBulletCollied();
    }

    public virtual void OnBulletCollied()
    {
        _factory.Despawn(this.gameObject);
        _targetDefeatPoints.OnEnemyDestroyed(_defeatPoints);
    }
}
