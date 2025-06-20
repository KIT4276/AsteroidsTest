using System;
using UnityEngine;

public class BulletCollision : ProjectileCollision
{
    protected override void HandlingCollisions(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<AsteroidCollision>(out var asteroidCollision))
        {
            Debug.Log("BulletCollision HandlingCollisions to AsteroidCollision " + collision.name);
            asteroidCollision.OnBulletCollied();
            //Todo despawn Bullet;
        }
    }
}
