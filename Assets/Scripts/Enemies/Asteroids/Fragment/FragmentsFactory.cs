using UnityEngine;

public class FragmentsFactory : BaseEnemyFactory
{
    public FragmentsFactory(GameStaticData staticData) : base(staticData)
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
}

