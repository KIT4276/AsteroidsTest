using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAsteroidsFactory : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected int _count = 15;

    protected List<GameObject> _pool = new();

    public  void Despawn(GameObject asteroid)
    {
        asteroid.GetComponent<BaseAsteroidMove>().StopMove();// bad?!
        asteroid.SetActive(false);
        _pool.Add(asteroid);
    }

    protected void Spawn()
    {
        GameObject asteroid;

        if (_pool.Count == 0)
        {
            asteroid = Instantiate(_prefab, transform.position, Quaternion.identity);
        }
        else
        {
            asteroid = _pool[0];
            _pool.Remove(asteroid);
        }

        asteroid.GetComponent<BaseAsteroidMove>().Initialize(GetSpawnPosition(), this);
        asteroid.GetComponent<BaseAsteroidCollision>().Initialize(this);
    }

    protected abstract Vector2 GetSpawnPosition();
}
