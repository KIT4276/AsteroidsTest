using UnityEngine;

public class FragmentsFactory : BaseAsteroidsFactory
{
    public void SpawnFragments()
    {
        for (int i = _count; i > 0; i--)
        {
            Spawn();
        }
    }

    protected override Vector2 GetSpawnPosition()
    {
        return transform.position;
    }
}

