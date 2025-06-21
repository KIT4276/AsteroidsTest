using UnityEngine;

public class BulletsFactory : BaseFactory
{
    private Transform _gunBarrel;

    public BulletsFactory(GameStaticData staticData) : base(staticData)
    {
        _prefab = staticData.BulletPrefab;
    }

    public override void Spawn(Transform gunBarrel)
    {
        //TODO
        _gunBarrel = gunBarrel;
        base.Spawn(gunBarrel);
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
