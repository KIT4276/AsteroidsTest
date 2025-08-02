using R3;
using System;
using TMPro;
using UnityEngine;

namespace AsteroidsTest.UI
{
    public class ShipStateView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coordinateX;
        [SerializeField] private TMP_Text _coordinateY;
        [SerializeField] private TMP_Text _angle;
        [SerializeField] private TMP_Text _speed;

        private IDisposable _positionXSub;
        private IDisposable _positionYSub;
        private IDisposable _angleSub;
        private IDisposable _speedSub;

        private ShipStateViewModel _viewModel;

        public void Initialize( ShipStateViewModel viewModel)
        {
            _viewModel = viewModel;
            _positionXSub = _viewModel.PositionX.Subscribe(OnPositionXChanged);
            _positionYSub = _viewModel.PositionY.Subscribe(OnPositionYChanged);
            _angleSub = _viewModel.NormalizeAngle.Subscribe(OnAngleChanged);
            _speedSub = _viewModel.Speed.Subscribe(OnSpeedChanged);
        }

        private void OnPositionXChanged(string x) =>
            _coordinateX.text = x;

        private void OnPositionYChanged(string y) =>
            _coordinateY.text = y;

        private void OnAngleChanged(string angle) =>
            _angle.text = angle;

        private void OnSpeedChanged(string speed) =>
            _speed.text = speed;

        private void OnDisable()
        {
            _positionXSub?.Dispose();
            _positionYSub?.Dispose();
            _angleSub?.Dispose();
            _speedSub?.Dispose();
        }
    }
}
