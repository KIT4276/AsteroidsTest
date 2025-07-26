using AsteroidsTest.Factories;
using AsteroidsTest.Services;
using AsteroidsTest.SOScripts;
using UnityEngine;

namespace AsteroidsTest.Enemies.Asteroids
{
    public abstract class BaseEnemyCollision : MonoBehaviour, IDamageable
    {
        protected BaseFactory _factory;
        protected EnemiesDefeatPoints _targetDefeatPoints;
        protected int _numDefeatPoints;
    
        public virtual void Initialize(BaseFactory factory, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints)
        {
            _factory = factory;
            _targetDefeatPoints= targetDefeatPoints;
        }
    
        public virtual void TakeDamage()
        {
            _targetDefeatPoints.OnEnemyDestroyed(_numDefeatPoints);
            _factory.Despawn(this.gameObject);
        }
    }
}
