using AsteroidsTest.Pause;
using AsteroidsTest.Services;
using AsteroidsTest.SOScripts;
using UnityEngine;

namespace AsteroidsTest.Enemies.Asteroids.Fragment
{
    public class FragmentsFactory : BaseEnemyFactory
    {
        public FragmentsFactory(GameStaticData staticData, DefeatPointsData defeatPointsData,
            EnemiesDefeatPoints targetDefeatPoints, Pauser pauser)
            : base(staticData, defeatPointsData, targetDefeatPoints, pauser)
        {
            _prefab = staticData.FragmentPrefab;
            _count = staticData.FragmentsCount;
        }

        public void SpawnFragments(Transform transform)
        {
            for (int i = _count; i > 0; i--)
            {
                _spawnPoint = transform;
                Spawn(transform);
            }
        }
        protected override Transform GetSpawnPoint(Transform spawnPoint)
        {
            return spawnPoint;
        }

        protected override void InitializeSpawnedObject(GameObject spawnedObject)
        {
            base.InitializeSpawnedObject(spawnedObject);
            spawnedObject.GetComponent<PausableRegistrator>().Initialize(_pauser);
        }
    }

}
