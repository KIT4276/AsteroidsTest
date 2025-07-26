using AsteroidsTest.SOScripts;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsTest.Factories
{
    public abstract class BaseFactory 
    {
        protected GameObject _prefab;
    
        protected List<GameObject> _pool = new();
        protected GameStaticData _staticData;
        protected GameObject _spawnedObject;
    
        public BaseFactory(GameStaticData staticData)
        {
            _staticData = staticData;
        }

        public void Restart()
        {
            _pool.Clear();
        }
    
        public virtual void Despawn(GameObject despawnedObject)
        {
            var rb = despawnedObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
    
            despawnedObject.GetComponent<IMove>().StopMove();
            despawnedObject.SetActive(false);
            _pool.Add(despawnedObject);
        }
    
        public virtual void Spawn(Transform spawnTransform)
        {
            if(_pool.Count>0)
            {
                _spawnedObject = _pool[_pool.Count - 1];
                _pool.Remove(_spawnedObject);
            }
            else
            {
                _spawnedObject = Object.Instantiate(_prefab, spawnTransform.position, Quaternion.identity);
            }

            if(_spawnedObject == null)
            {
                _spawnedObject = Object.Instantiate(_prefab, spawnTransform.position, Quaternion.identity);
            }

            InitializeSpawnedObject(_spawnedObject);
        }
    
        protected abstract void InitializeSpawnedObject(GameObject spawnedObject);
    
        protected abstract Transform GetSpawnPoint(Transform spawnTransform);
    }
}
