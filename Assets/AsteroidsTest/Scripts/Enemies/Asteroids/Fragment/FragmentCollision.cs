using AsteroidsTest.Factories;
using AsteroidsTest.Services;
using AsteroidsTest.SOScripts;

namespace AsteroidsTest.Enemies.Asteroids.Fragment
{
public class FragmentCollision : BaseEnemyCollision
{
    public override void Initialize(BaseFactory factory, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints)
    {
        base.Initialize(factory, defeatPointsData, targetDefeatPoints);
        _numDefeatPoints = defeatPointsData.FragmentPoints;
    }
}
}
