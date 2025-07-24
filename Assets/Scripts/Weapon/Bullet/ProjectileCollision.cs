using UnityEngine;

namespace AsteroidsTest.Weapon.Bullet
{
    [RequireComponent (typeof(Collider2D))]
    public abstract class ProjectileCollision : MonoBehaviour
    {
        protected abstract void HandlingCollisions(Collider2D collision);
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            HandlingCollisions(collision);
        }
    
    }
}
