using R3;

namespace AsteroidsTest.Weapon.Laser
{
    public class LaserViewModel 
    {
        public ReactiveProperty<string> ShotsLeft { get; private set; }
        public ReactiveProperty<float> ShotsTimer { get; private set; }

        private LaserModel _model;

        public LaserViewModel(LaserModel model)
        {
            _model = model;

            ShotsLeft = new();
            ShotsTimer = new();

            _model.ShotsLeft.Subscribe(OnShotsChanged);
            _model.ShotsTimer.Subscribe(OnTimerChanged);
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
    }
}
