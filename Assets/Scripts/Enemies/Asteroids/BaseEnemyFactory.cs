using AsteroidsTest.SOScripts;
using UnityEngine;

namespace AsteroidsTest.Enemies.Asteroids
{
    public abstract class BaseEnemyFactory : BaseFactory
    {
        protected int _count = 15;
        protected Transform _spawnPoint;
        protected EnemiesDefeatPoints _targetDefeatPoints;
        protected DefeatPointsData _defeatPointsData;
    
        protected BaseEnemyFactory(GameStaticData staticData, DefeatPointsData defeatPointsData,
            EnemiesDefeatPoints targetDefeatPoints)
            : base(staticData)
        {
            _targetDefeatPoints = targetDefeatPoints;
            _defeatPointsData = defeatPointsData;
        }
    
        public override void Spawn(Transform spawnTransform)
        {
            base.Spawn(spawnTransform);
        }
    
        protected override Transform GetSpawnPoint(Transform transform)
        {
            return transform;
        }
    
        protected override void InitializeSpawnedObject(GameObject spawnedObject)
        {
            spawnedObject.GetComponent<IMove>().Initialize(GetSpawnPoint(_spawnPoint), this, _staticData);
            spawnedObject.GetComponent<BaseEnemyCollision>().Initialize(this, _defeatPointsData, _targetDefeatPoints);
        }
    }
}
