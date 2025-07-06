using AsteroidsTest.SOScripts;
using System;

namespace AsteroidsTest.Weapon.Laser
{
    public class LaserViewModel 
    {
        private int _laserShotsLeft;
        private float _timerLeft;

        private LaserModel _model;
        private readonly GameStaticData _gameStaticData;

        public event Action<string> ShotsChanged;
        public event Action<float> TimerChanged;


        public LaserViewModel(LaserModel model, GameStaticData gameStaticData)
        {
            _model = model;
            _gameStaticData = gameStaticData;

            _model.ShotsChanged += OnShotsChanged;
            _model.TimerChanged += OnTimerChanged;

            OnShotsChanged(_model.ShotsLeft);
            OnTimerChanged(_model.Timer);
        }

        public void Init()
        {
            OnShotsChanged(_model.ShotsLeft);
            OnTimerChanged(_model.Timer);
        }

        private void OnShotsChanged(int numberOfShotsLeft)
        {
            _laserShotsLeft = numberOfShotsLeft;

            ShotsChanged?.Invoke(_laserShotsLeft.ToString());
        }

        private void OnTimerChanged(float timer)
        {
            _timerLeft = (timer / _gameStaticData.LaserShotRecoveryTime);

            TimerChanged?.Invoke(_timerLeft);
        }
    }
}
