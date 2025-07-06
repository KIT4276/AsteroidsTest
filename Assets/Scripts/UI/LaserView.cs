using AsteroidsTest.SOScripts;
using AsteroidsTest.Weapon.Laser;
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
        public void Construct(LaserModel model, GameStaticData gameStaticData)
        {
            _viewModel = new(model, gameStaticData);

            _viewModel.ShotsChanged += OnNumberOfShotsChange;
            _viewModel.TimerChanged += OnTimerChanged;

        }

        private void Start()
        {
            _viewModel.Init();
        }

        private void OnTimerChanged(float fill) => 
            _laserRecovery.fillAmount = fill;

        private void OnNumberOfShotsChange(string numberOfShotsLeft) => 
            _laserShotsLeft.text = numberOfShotsLeft;

        private void OnDestroy()
        {
            _viewModel.ShotsChanged -= OnNumberOfShotsChange;
            _viewModel.TimerChanged -= OnTimerChanged;
        }
    }
}
