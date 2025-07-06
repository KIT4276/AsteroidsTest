using AsteroidsTest.SOScripts;
using System;

public class LaserModel
{
    public int ShotsLeft { get; private set; }
    public float Timer { get; private set; }
    public float RecoveryTime { get; }

    public event Action<int> ShotsChanged;
    public event Action<float> TimerChanged;

    private int _maxShots;

    public LaserModel(GameStaticData gameStaticData)
    {
        _maxShots = gameStaticData.NumberOfLaserShots;
        RecoveryTime = gameStaticData.LaserShotRecoveryTime;
        ShotsLeft = _maxShots;
    }

    public bool TryFire()
    {
        if (ShotsLeft <= 0) return false;

        ShotsLeft--;
        ShotsChanged?.Invoke(ShotsLeft);
        return true;
    }

    public void UpdateTimer(float deltaTime)
    {
        if (ShotsLeft >= _maxShots) return;

        Timer += deltaTime;
        TimerChanged?.Invoke(Timer);

        if (Timer >= RecoveryTime)
        {
            Timer = 0;
            ShotsLeft++;
            ShotsChanged?.Invoke(ShotsLeft);
        }
    }
}
