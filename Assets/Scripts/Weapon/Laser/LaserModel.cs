using AsteroidsTest.SOScripts;
using R3;

public class LaserModel
{
    private ReactiveProperty<int> _shotsLeft = new();
    private ReactiveProperty<float> _shotsTimer = new();

    public Observable<int> ShotsLeft => _shotsLeft.AsObservable();
    public Observable<float> ShotsTimer => _shotsTimer.AsObservable();

    public float RecoveryTime { get; }

    private int _maxShots;

    public LaserModel(GameStaticData gameStaticData)
    {
        _maxShots = gameStaticData.NumberOfLaserShots;
        RecoveryTime = gameStaticData.LaserShotRecoveryTime;

        _shotsLeft = new();
        _shotsTimer = new();

        _shotsLeft.Value = _maxShots;
    }

    public bool TryFire()
    {
        if (_shotsLeft.Value <= 0)
            return false;

        _shotsLeft.Value--;
        return true;
    }

    public void UpdateTimer(float deltaTime)
    {
        if (_shotsLeft.Value >= _maxShots) return;

        _shotsTimer.Value += deltaTime;

        if (_shotsTimer.Value >= RecoveryTime)
        {
            _shotsTimer.Value = 0;
            _shotsLeft.Value++;
        }
    }
}
