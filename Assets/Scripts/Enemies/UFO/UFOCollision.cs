using AsteroidsTest.Enemies.Asteroids;
using AsteroidsTest.SOScripts;
using UnityEngine;

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
