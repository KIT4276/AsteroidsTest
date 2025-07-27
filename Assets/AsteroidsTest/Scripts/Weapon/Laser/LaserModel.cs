using AsteroidsTest.Pause;
using AsteroidsTest.Save.Data;
using AsteroidsTest.SOScripts;
using R3;

namespace AsteroidsTest.Weapon.Laser
{
    public class LaserModel: ISavedProgress, IPausable
    {
        private ReactiveProperty<int> _shotsRemaining;
        private ReactiveProperty<float> _shotsTimer;

        public Observable<int> ShotsLeft => _shotsRemaining.AsObservable();
        public Observable<float> ShotsTimer => _shotsTimer.AsObservable();

        public float RecoveryTime { get; }

        private int _maxShots;
        private bool _isPause;

        public LaserModel(GameStaticData gameStaticData, Pauser pauser)
        {
            _maxShots = gameStaticData.NumberOfLaserShots;
            RecoveryTime = gameStaticData.LaserShotRecoveryTime;

            _shotsRemaining = new();
            _shotsTimer = new();
            _isPause = false;
            _shotsRemaining.Value = _maxShots;

            pauser.Register(this);
        }

        public void Restart()
        {
            _shotsRemaining.Value = _maxShots;
            _shotsTimer.Value = 0;
            _isPause = false;
        }

        public void Pause() => 
            _isPause = true;

        public void Resume() => 
            _isPause = false;

        public bool TryFire()
        {
            if (_shotsRemaining.Value <= 0)
                return false;

            _shotsRemaining.Value--;
            return true;
        }

        public void UpdateTimer(float deltaTime)
        {
            if (_shotsRemaining.Value >= _maxShots || _isPause) return;

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
