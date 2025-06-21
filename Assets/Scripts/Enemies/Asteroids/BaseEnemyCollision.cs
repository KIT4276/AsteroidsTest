using UnityEngine;

public abstract class BaseEnemyCollision : MonoBehaviour, IDamageable
{
    protected BaseFactory _factory;

    public void Initialize(BaseFactory factory)
    {
        _factory = factory;
    }

    public void TakeBulletDamage()
    {
        OnBulletCollied();
    }

    public virtual void OnBulletCollied()
    {
        _factory.Despawn(this.gameObject);
    }
}
