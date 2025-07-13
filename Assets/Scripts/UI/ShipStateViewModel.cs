using AsteroidsTest.Ship;
using AsteroidsTest.SOScripts;
using R3;
using System;
using Zenject;

namespace AsteroidsTest.UI
{
    public class ShipStateViewModel : IInitializable, IDisposable
    {
        public ReactiveProperty<string> PositionX { get; private set; }
        public ReactiveProperty<string> PositionY { get; private set; }
        public ReactiveProperty<string> NormalizeAngle { get; private set; }
        public ReactiveProperty<string> Speed { get; private set; }

        private IDisposable _subX;
        private IDisposable _subY;
        private IDisposable _subAngle;
        private IDisposable _subSpeed;

        private ShipStateModel _model;
        private float _multiplier;


        public ShipStateViewModel( ShipStateModel model, GameStaticData gameStaticData)
        {
            _model = model;
            _multiplier = gameStaticData.ShipStateViewMultiplier;

            PositionX = new();
            PositionY = new();
            NormalizeAngle = new();
            Speed = new();  
        }

        public void Initialize()
        {
            _subX = _model.PositionX.Subscribe(OnPositionXChanged);
            _subY = _model.PositionY.Subscribe(OnPositionYChanged);
            _subAngle = _model.Angle.Subscribe(OnAngleChanged);
            _subSpeed = _model.Speed.Subscribe(OnSpeedChanged);
        }


        private void OnPositionXChanged(float x) => 
            PositionX.Value = (x * _multiplier).ToString("F0");

        private void OnPositionYChanged(float y) => 
            PositionY.Value = (y * _multiplier).ToString("F0");

        private void OnAngleChanged(float angle) => 
            NormalizeAngle.Value = (((360 - angle) > 180f) ? (360 - angle) - 360f : (360 - angle)).ToString("F0");

        private void OnSpeedChanged(float speed) => 
            Speed.Value = (speed * _multiplier).ToString("F0");

        public void Dispose()
        {
            _subX?.Dispose();
            _subY?.Dispose();
            _subAngle?.Dispose();
            _subSpeed?.Dispose();
        }
    }
}
