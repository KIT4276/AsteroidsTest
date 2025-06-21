using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFactory
{
    protected GameObject _prefab;

    protected List<GameObject> _pool = new();

    public BaseFactory(GameStaticData staticData)
    {
        //_prefab = prefab;
    }

    public virtual void Despawn(GameObject despawnedObject)
    {
        despawnedObject.GetComponent<IMove>().StopMove();// bad?!
        despawnedObject.SetActive(false);
        _pool.Add(despawnedObject);
    }

    protected virtual void Spawn(Transform spawnTransform)
    {
        GameObject spawnedObject;

        if (_pool.Count == 0)
        {
            spawnedObject = Object.Instantiate(_prefab, spawnTransform.position, Quaternion.identity);
        }
        else
        {
            spawnedObject = _pool[0];
            _pool.Remove(spawnedObject);
        }

        InitializeSpawnedObject(spawnedObject);
    }

    protected abstract void InitializeSpawnedObject(GameObject spawnedObject);

    protected abstract Transform GetSpawnPoint(Transform spawnTransform);
}
