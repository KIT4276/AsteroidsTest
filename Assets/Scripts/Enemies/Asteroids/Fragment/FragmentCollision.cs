public class FragmentCollision : BaseEnemyCollision
{
    public override void Initialize(BaseFactory factory, DefeatPointsData defeatPointsData, TargetDefeatPoints targetDefeatPoints)
    {
        base.Initialize(factory, defeatPointsData, targetDefeatPoints);
        _defeatPoints = defeatPointsData.FragmentPoints;
    }
}
