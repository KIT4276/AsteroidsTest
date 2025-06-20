using UnityEngine;

public class AsteroidCollision : BaseAsteroidCollision
{
    [SerializeField] private FragmentsFactory _fragmentsFactory;

    public override void OnBulletCollied()
    {
       base.OnBulletCollied(); 
        _fragmentsFactory.SpawnFragments();
    }
}
