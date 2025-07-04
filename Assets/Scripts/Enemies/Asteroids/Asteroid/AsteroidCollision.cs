using AsteroidsTest.Enemies.Asteroids.Fragment;
using AsteroidsTest.SOScripts;

namespace AsteroidsTest.Enemies.Asteroids.Asteroid
{
    public class AsteroidCollision : BaseEnemyCollision
    {
        private FragmentsFactory _fragmentsFactory;

        public override void Initialize(BaseFactory factory, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints)
        {
            base.Initialize(factory, defeatPointsData, targetDefeatPoints);
            _numDefeatPoints = defeatPointsData.AsteroidPoints;
        }

        public void SetFactory(FragmentsFactory fragmentsFactory)
        {
            _fragmentsFactory = fragmentsFactory;
        }

        public override void TakeDamage()
        {
            if (_fragmentsFactory != null)
            {
                base.TakeDamage();
                _fragmentsFactory.SpawnFragments(this.transform);
            }
        }
    }
}
