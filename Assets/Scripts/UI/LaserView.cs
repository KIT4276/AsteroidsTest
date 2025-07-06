using AsteroidsTest.Weapon.Laser;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AsteroidsTest.UI
{
    public class LaserView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _laserShotsLeft;
        [SerializeField] private Image _laserRecovery;

        private LaserViewModel _viewModel;

        [Inject]
        public void Construct(LaserModel model)
        {
            _viewModel = new(model);

            _viewModel.ShotsLeft.Subscribe(OnNumberOfShotsChange);
            _viewModel.ShotsTimer.Subscribe(OnTimerChanged);
        }

        private void Start() => 
            _viewModel.Init();

        private void OnTimerChanged(float fill) => 
            _laserRecovery.fillAmount = fill;

        private void OnNumberOfShotsChange(string numberOfShotsLeft) => 
            _laserShotsLeft.text = numberOfShotsLeft;
    }
}
