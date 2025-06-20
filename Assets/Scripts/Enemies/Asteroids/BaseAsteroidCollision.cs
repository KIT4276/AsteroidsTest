using UnityEngine;

public abstract class BaseAsteroidCollision : MonoBehaviour
{
    protected BaseAsteroidsFactory _factory;

    public void Initialize(BaseAsteroidsFactory factory)
    {
        _factory = factory;
    }

    public virtual void OnBulletCollied()
    {
        _factory.Despawn(this.gameObject);
    }
}
