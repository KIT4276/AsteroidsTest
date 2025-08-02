using AsteroidsTest.Enemies.Asteroids;
using AsteroidsTest.Factories;
using AsteroidsTest.Services;
using AsteroidsTest.SOScripts;

namespace AsteroidsTest.Enemies.UFO
{
    public class UFOCollision : BaseEnemyCollision
    {
        public override void Initialize(BaseFactory factory, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints)
        {
            base.Initialize(factory, defeatPointsData, targetDefeatPoints);
            _numDefeatPoints = defeatPointsData.UFOPoints;
        }
    }
}
