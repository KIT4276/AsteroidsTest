using UnityEngine;

public class FragmentsFactory : BaseEnemyFactory
{
    public FragmentsFactory(GameStaticData staticData, DefeatPointsData defeatPointsData, TargetDefeatPoints targetDefeatPoints) 
        : base(staticData, defeatPointsData, targetDefeatPoints)
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
}

