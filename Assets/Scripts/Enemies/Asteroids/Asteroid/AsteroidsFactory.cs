using System.Collections;
using UnityEngine;

public class AsteroidsFactory : BaseAsteroidsFactory
{
    [SerializeField] private float _spawnPosLimit = 1000;
    [SerializeField] private Vector2 _screenLimits = new Vector2(11.2f, 5.25f);
    [SerializeField] private float _spawnTime = 3;

    private void Start() //temporary
    {
        StartSpawn();
    }

    public void StartSpawn()
    {
        for (int i = _count; i > 0; i--)
        {
            Spawn();
        }

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private float GenRandom()
    {
        return UnityEngine.Random.Range(-_spawnPosLimit, _spawnPosLimit);
    }

    protected override Vector2 GetSpawnPosition()
    {
        var x = GenRandom();
        while (x > -_screenLimits.x && x < _screenLimits.x)
        {
            x = GenRandom();
        }

        var y = GenRandom();
        while (y > -_screenLimits.y && y < _screenLimits.y)
        {
            y = GenRandom();
        }

        return new Vector2(x, y);
    }
}
