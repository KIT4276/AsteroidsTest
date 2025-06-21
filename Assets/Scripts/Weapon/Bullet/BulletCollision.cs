using UnityEngine;

public class BulletCollision : ProjectileCollision
{
    private BulletsFactory _bulletsFactory;

    public void Initialize(BulletsFactory bulletsFactory)
    {
        _bulletsFactory = bulletsFactory;
    }

    protected override void HandlingCollisions(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeBulletDamage();
            _bulletsFactory.Despawn(gameObject);
        }
    }
}
