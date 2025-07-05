using AsteroidsTest.Ship;
using AsteroidsTest.SOScripts;
using System;

namespace AsteroidsTest.UI
{
    public class ShipStateViewModel
    {
        private ShipStateModel _model;

        private float _shipPositionX;
        private float _shipPositionY;
        private float _normalizeAngle;
        private float _speed;

        private float _multiplier;

        public event Action<string> PositionXChanged;
        public event Action<string> PositionYChanged;
        public event Action<string> AngleChanged;
        public event Action<string> SpeedChanged;


        public ShipStateViewModel( ShipStateModel model, GameStaticData gameStaticData)
        {
            _model = model;
            _multiplier = gameStaticData.ShipStateViewMultiplier;

            _model.PositionXChanged += OnPositionXChanged;
            _model.PositionYChanged += OnPositionYChanged;
            _model.AngleChanged += OnAngleChanged;
            _model.SpeedChanged += OnSpeedChanged;
        }

        private void OnPositionXChanged(float x)
        {
            _shipPositionX = x * _multiplier;

            PositionXChanged?.Invoke(_shipPositionX.ToString("F0"));
        }

        private void OnPositionYChanged(float y)
        {
            _shipPositionY = y * _multiplier;

            PositionYChanged?.Invoke(_shipPositionY.ToString("F0"));
        }

        private void OnAngleChanged(float angle)
        {
            float correctedAngle = 360 - angle;
            _normalizeAngle = (correctedAngle > 180f) ? correctedAngle - 360f : correctedAngle;

            AngleChanged?.Invoke(_normalizeAngle.ToString("F0"));
        }

        private void OnSpeedChanged(float speed)
        {
           _speed = speed * _multiplier;

            SpeedChanged?.Invoke(_speed.ToString("F0"));
        }
    }
}
