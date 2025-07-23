using R3;
using System;
using Zenject;

namespace AsteroidsTest.Weapon.Laser
{
    public class LaserViewModel : IInitializable, IDisposable
    {
        private ReactiveProperty<string> _shotsRemaining = new();
        private ReactiveProperty<float> _shotsTimer = new();

        public Observable<string> ShotsLeft => _shotsRemaining.AsObservable();
        public Observable<float> ShotsTimer => _shotsTimer.AsObservable();

        private IDisposable _shotsSub;
        private IDisposable _timerSub;

        private LaserModel _model;

        public LaserViewModel(LaserModel model)
        {
            _model = model;
        }

        public void Initialize()
        {
            _shotsSub = _model.ShotsLeft.Subscribe(OnShotsChanged);
            _timerSub = _model.ShotsTimer.Subscribe(OnTimerChanged);
        }

        private void OnShotsChanged(int numberOfShotsLeft) =>
            _shotsRemaining.Value = numberOfShotsLeft.ToString("F0");

        private void OnTimerChanged(float timer) =>
            _shotsTimer.Value = (timer / _model.RecoveryTime);

        public void Dispose()
        {
            _shotsSub?.Dispose();
            _timerSub?.Dispose();
        }
    }
}
