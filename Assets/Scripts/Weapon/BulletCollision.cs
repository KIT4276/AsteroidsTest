using UnityEngine;

public class BulletCollision : ProjectileCollision
{
    protected override void HandlingCollisions(Collider2D collision)
    {
        Debug.Log("BulletCollision HandlingCollisions to " + collision.name);
        if(collision.gameObject.TryGetComponent<ShipCollision>(out var shipCollision))
        {
            shipCollision.OnBulletCollision();
            //Todo despawn Bullet;
        }
    }
}
