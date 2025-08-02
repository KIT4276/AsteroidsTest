using AsteroidsTest.Factories;
using AsteroidsTest.SOScripts;
using UnityEngine;

namespace AsteroidsTest.Weapon.Bullet
{
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
            if (spawnedObject == null) return;
            spawnedObject.SetActive(true);
            spawnedObject.GetComponent<ProjectileMove>().Initialize(GetSpawnPoint(_gunBarrel), this, _staticData);
            spawnedObject.GetComponent<BulletCollision>().Initialize(this);
        }
    
        protected override Transform GetSpawnPoint(Transform spawnTransform)
        {
            return spawnTransform;
        }
    }
}
