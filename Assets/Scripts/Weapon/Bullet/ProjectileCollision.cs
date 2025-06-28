using System;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public abstract class ProjectileCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlingCollisions(collision);
    }

    protected abstract void HandlingCollisions(Collider2D collision);
}
