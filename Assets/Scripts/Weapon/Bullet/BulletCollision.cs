using System;
using UnityEngine;

public class BulletCollision : ProjectileCollision
{
    protected override void HandlingCollisions(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeBulletDamage();
            //Todo despawn Bullet;
        }
    }
}
