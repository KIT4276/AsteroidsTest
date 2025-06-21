using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFactory
{
    protected GameObject _prefab;

    protected List<GameObject> _pool = new();
    protected GameStaticData _staticData;

    public BaseFactory(GameStaticData staticData)
    {
        _staticData = staticData;
    }

    public virtual void Despawn(GameObject despawnedObject)
    {
        despawnedObject.GetComponent<IMove>().StopMove();// bad?!
        despawnedObject.SetActive(false);
        _pool.Add(despawnedObject);
    }

    public virtual void Spawn(Transform spawnTransform)
    {
        GameObject spawnedObject;

        if(_pool.Count>0)
        {
            spawnedObject = _pool[_pool.Count - 1];
            _pool.Remove(spawnedObject);
        }
        else
        {
            spawnedObject = Object.Instantiate(_prefab, spawnTransform.position, Quaternion.identity);
        }

        //if (_pool.Count == 0)
        //{
        //    spawnedObject = Object.Instantiate(_prefab, spawnTransform.position, Quaternion.identity);
        //}
        //else
        //{
        //    spawnedObject = _pool[_pool.Count -1];
        //    _pool.Remove(spawnedObject);
        //}

        InitializeSpawnedObject(spawnedObject);
    }

    protected abstract void InitializeSpawnedObject(GameObject spawnedObject);

    protected abstract Transform GetSpawnPoint(Transform spawnTransform);
}
