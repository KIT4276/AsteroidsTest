using R3;
using System;
using Zenject;

namespace AsteroidsTest.Weapon.Laser
{
    public class LaserViewModel : IInitializable, IDisposable
    {
        public ReactiveProperty<string> ShotsLeft { get; private set; }
        public ReactiveProperty<float> ShotsTimer { get; private set; }

        private IDisposable _shotsSub;
        private IDisposable _timerSub;

        private LaserModel _model;

        public LaserViewModel(LaserModel model)
        {
            _model = model;

            ShotsLeft = new();
            ShotsTimer = new();
        }

        public void Initialize()
        {
            _shotsSub = _model.ShotsLeft.Subscribe(OnShotsChanged);
            _timerSub = _model.ShotsTimer.Subscribe(OnTimerChanged);
        }

        public void Init()
        {
            OnShotsChanged(_model.ShotsLeft.Value);
            OnTimerChanged(_model.ShotsTimer.Value);
        }

        private void OnShotsChanged(int numberOfShotsLeft) =>
            ShotsLeft.Value = numberOfShotsLeft.ToString("F0");

        private void OnTimerChanged(float timer) =>
            ShotsTimer.Value = (timer / _model.RecoveryTime);

        public void Dispose()
        {
            _shotsSub?.Dispose();
            _timerSub?.Dispose();
        }
    }
}
