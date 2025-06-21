using UnityEngine;

public class BulletFactory : BaseFactory
{
    private Transform _gunBarrel;

    public BulletFactory(GameStaticData staticData) : base(staticData)
    {
    }

    protected override void Spawn(Transform gunBarrel)
    {
        //TODO
        _gunBarrel = gunBarrel;
    }

    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        spawnedObject.GetComponent<ProjectileMove>().Initialize(GetSpawnPoint(_gunBarrel), this);
    }
   

    protected override Transform GetSpawnPoint(Transform spawnTransform)
    {
        return spawnTransform;
    }
}
