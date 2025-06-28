using UnityEngine;

public class AsteroidCollision : BaseEnemyCollision
{
   private FragmentsFactory _fragmentsFactory;

    public override void Initialize(BaseFactory factory, DefeatPointsData defeatPointsData, TargetDefeatPoints targetDefeatPoints)
    {
        base.Initialize(factory, defeatPointsData, targetDefeatPoints);
        _defeatPoints = defeatPointsData.AsteroidPoints;
    }

    public void SetFragmentsFactory(FragmentsFactory fragmentsFactory)
    {
        _fragmentsFactory = fragmentsFactory;
    }

    public override void OnBulletCollied()
    {
        if (_fragmentsFactory != null)
        {
            base.OnBulletCollied();
            _fragmentsFactory.SpawnFragments(this.transform);
        }
    }
}
