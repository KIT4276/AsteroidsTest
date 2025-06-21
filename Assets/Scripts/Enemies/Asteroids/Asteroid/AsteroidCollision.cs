using UnityEngine;

public class AsteroidCollision : BaseEnemyCollision
{
   private FragmentsFactory _fragmentsFactory;

    public void SetFactory(FragmentsFactory fragmentsFactory)
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
