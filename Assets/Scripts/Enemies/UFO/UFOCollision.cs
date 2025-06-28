using UnityEngine;

public class UFOCollision : BaseEnemyCollision
{
    public override void Initialize(BaseFactory factory, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints)
    {
        base.Initialize(factory, defeatPointsData, targetDefeatPoints);
        _numDefeatPoints = defeatPointsData.UFOPoints;
    }
}
