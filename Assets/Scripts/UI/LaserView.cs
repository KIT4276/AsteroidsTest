using AsteroidsTest.Weapon.Laser;
using R3;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsTest.UI
{
    public class LaserView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _laserShotsLeft;
        [SerializeField] private Image _laserRecovery;

        private IDisposable _numberOfShotsSub;
        private IDisposable _timerSub;

        private LaserViewModel _viewModel;

        public void Initialize(LaserViewModel viewModel)
        {
            _viewModel = viewModel;
            _numberOfShotsSub = _viewModel.ShotsLeft.Subscribe(OnNumberOfShotsChange);
            _timerSub = _viewModel.ShotsTimer.Subscribe(OnTimerChanged);
        }

        private void OnTimerChanged(float fill) =>
            _laserRecovery.fillAmount = fill;

        private void OnNumberOfShotsChange(string numberOfShotsLeft) =>
            _laserShotsLeft.text = numberOfShotsLeft;

        private void OnDisable()
        {
            _numberOfShotsSub?.Dispose();
            _timerSub?.Dispose();
        }
    }
}
