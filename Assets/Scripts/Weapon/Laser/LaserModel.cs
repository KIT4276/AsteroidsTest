using AsteroidsTest.Save.Data;
using AsteroidsTest.SOScripts;
using R3;

namespace AsteroidsTest.Weapon.Laser
{
    public class LaserModel: ISavedProgress
    {
        private ReactiveProperty<int> _shotsRemaining = new();
        private ReactiveProperty<float> _shotsTimer = new();


        //public int LaserShots = 0;

        public Observable<int> ShotsLeft => _shotsRemaining.AsObservable();
        public Observable<float> ShotsTimer => _shotsTimer.AsObservable();

        public float RecoveryTime { get; }

        private int _maxShots;

        public LaserModel(GameStaticData gameStaticData)
        {
            _maxShots = gameStaticData.NumberOfLaserShots;
            RecoveryTime = gameStaticData.LaserShotRecoveryTime;

            _shotsRemaining = new();
            _shotsTimer = new();

            _shotsRemaining.Value = _maxShots;
        }

        public bool TryFire()
        {
            if (_shotsRemaining.Value <= 0)
                return false;

            _shotsRemaining.Value--;
            return true;
        }

        public void UpdateTimer(float deltaTime)
        {
            if (_shotsRemaining.Value >= _maxShots) return;

            _shotsTimer.Value += deltaTime;

            if (_shotsTimer.Value >= RecoveryTime)
            {
                _shotsTimer.Value = 0;
                _shotsRemaining.Value++;
            }
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.LaserShotsRemaining = _shotsRemaining.Value;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _shotsRemaining.Value = progress.LaserShotsRemaining;
        }
    }
}
