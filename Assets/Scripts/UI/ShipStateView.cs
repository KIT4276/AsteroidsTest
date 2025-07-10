using AsteroidsTest.Ship;
using AsteroidsTest.SOScripts;
using R3;
using TMPro;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.UI
{
    public class ShipStateView : MonoBehaviour
    {
        [SerializeField] private GameStaticData _staticData;
        [Space]
        [SerializeField] private TMP_Text _coordinateX;
        [SerializeField] private TMP_Text _coordinateY;
        [SerializeField] private TMP_Text _angle;
        [SerializeField] private TMP_Text _speed;

        private ShipStateViewModel _viewModel;


        [Inject]
        public void Construct(ShipStateModel model)
        {
            _viewModel = new(model, _staticData);

            _viewModel.PositionX.Subscribe(OnPositionXChanged);
            _viewModel.PositionY.Subscribe(OnPositionYChanged);
            _viewModel.NormalizeAngle.Subscribe(OnAngleChanged);
            _viewModel.Speed.Subscribe(OnSpeedChanged);
        }

        private void OnPositionXChanged(string x) =>
            _coordinateX.text = x;

        private void OnPositionYChanged(string y) =>
            _coordinateY.text = y;

        private void OnAngleChanged(string angle) =>
            _angle.text = angle;

        private void OnSpeedChanged(string speed) =>
            _speed.text = speed;
    }
}
