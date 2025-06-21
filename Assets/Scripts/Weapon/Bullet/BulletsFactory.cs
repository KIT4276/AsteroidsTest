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
        _gunBarrel = gunBarrel;
        base.Spawn(gunBarrel);
    }

    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        spawnedObject.SetActive(true);
        spawnedObject.GetComponent<ProjectileMove>().Initialize(GetSpawnPoint(_gunBarrel), this, _staticData);
        spawnedObject.GetComponent<BulletCollision>().Initialize(this);
    }
   

    protected override Transform GetSpawnPoint(Transform spawnTransform)
    {
        return spawnTransform;
    }
}
