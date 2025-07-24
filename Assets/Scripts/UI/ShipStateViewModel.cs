using AsteroidsTest.Ship;
using AsteroidsTest.SOScripts;
using R3;
using System;
using Zenject;

namespace AsteroidsTest.UI
{
    public class ShipStateViewModel : IInitializable, IDisposable
    {
        private ReactiveProperty<string> _positionX = new();
        private ReactiveProperty<string> _positionY = new();
        private ReactiveProperty<string> _normalizeAngle = new();
        private ReactiveProperty<string> _speed = new();

        private ShipStateModel _model;
        private float _multiplier;

        public Observable<string> PositionX => _positionX.AsObservable();
        public Observable<string> PositionY => _positionY.AsObservable();
        public Observable<string> NormalizeAngle => _normalizeAngle.AsObservable();
        public Observable<string> Speed => _speed.AsObservable();

        private IDisposable _subX;
        private IDisposable _subY;
        private IDisposable _subAngle;
        private IDisposable _subSpeed;

        public ShipStateViewModel(ShipStateModel model, GameStaticData gameStaticData)
        {
            _model = model;
            _multiplier = gameStaticData.ShipStateViewMultiplier;

            _positionX = new();
            _positionY = new();
            _normalizeAngle = new();
            _speed = new();
        }

        public void Initialize()
        {
            _subX = _model.PositionX.Subscribe(OnPositionXChanged);
            _subY = _model.PositionY.Subscribe(OnPositionYChanged);
            _subAngle = _model.Angle.Subscribe(OnAngleChanged);
            _subSpeed = _model.Speed.Subscribe(OnSpeedChanged);
        }

        public void Dispose()
        {
            _subX?.Dispose();
            _subY?.Dispose();
            _subAngle?.Dispose();
            _subSpeed?.Dispose();
        }

        private void OnPositionXChanged(float x) =>
            _positionX.Value = (x * _multiplier).ToString("F0");

        private void OnPositionYChanged(float y) =>
            _positionY.Value = (y * _multiplier).ToString("F0");

        private void OnAngleChanged(float angle) =>
            _normalizeAngle.Value = (((360 - angle) > 180f) ? (360 - angle) - 360f : (360 - angle)).ToString("F0");

        private void OnSpeedChanged(float speed) =>
            _speed.Value = (speed * _multiplier).ToString("F0");
    }
}
