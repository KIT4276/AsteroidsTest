using AsteroidsTest.SOScripts;
using R3;

public class LaserModel
{
    public ReactiveProperty <int> ShotsLeft { get; private set; }
    public ReactiveProperty<float> ShotsTimer { get; private set; }

    public float RecoveryTime { get; }

    private int _maxShots;

    public LaserModel(GameStaticData gameStaticData)
    {
        _maxShots = gameStaticData.NumberOfLaserShots;
        RecoveryTime = gameStaticData.LaserShotRecoveryTime;

        ShotsLeft = new();
        ShotsTimer = new();

        ShotsLeft.Value = _maxShots;
    }

    public bool TryFire()
    {
        if (ShotsLeft.Value <= 0) 
            return false;

        ShotsLeft.Value--;
        return true;
    }

    public void UpdateTimer(float deltaTime)
    {
        if (ShotsLeft.Value >= _maxShots) return;

        ShotsTimer.Value += deltaTime;

        if (ShotsTimer.Value >= RecoveryTime)
        {
            ShotsTimer.Value = 0;
            ShotsLeft.Value++;
        }
    }
}
