using UnityEngine;

public abstract class BaseEnemyFactory : BaseFactory, IPausable
{
    protected int _count = 15;
    protected Transform _spawnPoint;
    protected EnemiesDefeatPoints _targetDefeatPoints;
    protected DefeatPointsData _defeatPointsData;
    protected Pauser _pauser;

    protected bool _isPaused = false;

    protected BaseEnemyFactory(GameStaticData staticData, DefeatPointsData defeatPointsData, EnemiesDefeatPoints targetDefeatPoints, Pauser pauser)
        : base(staticData)
    {
        _targetDefeatPoints = targetDefeatPoints;
        _defeatPointsData = defeatPointsData;
        _pauser = pauser;
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Resume()
    {
        _isPaused = false;
    }

    public override void Spawn(Transform spawnTransform)
    {
        if (!_isPaused)
        {
            base.Spawn(spawnTransform);
        }
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
