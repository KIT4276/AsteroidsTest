using UnityEngine;

public class UFOFactory : BaseEnemyFactory
{
    public UFOFactory(GameStaticData staticData, ICoroutineRunner coroutineRunner, Transform spawnPoint) : 
        base(staticData)
    {
        _prefab = staticData.UFOPrefab;
        _count = staticData.UFOStartCount;
        //_spawnTime = staticData.UFOSpawnTime;
       
    }

   
    protected override void InitializeSpawnedObject(GameObject spawnedObject)
    {
        spawnedObject.GetComponent<UFOMove>().Initialize(_spawnPoint, this, _staticData);
    }
}
