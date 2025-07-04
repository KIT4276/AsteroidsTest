using AsteroidsTest.Weapon.Laser;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsTest.UI
{
    public class LaserUI : MonoBehaviour
    {
        [SerializeField] private ShootingLaser _shootingLaser;
        [Space]
        [SerializeField] private TMP_Text _laserShotsLeft;
        [SerializeField] private Image _laserRecovery;
    
        private void Start()
        {
            _laserShotsLeft.text = _shootingLaser.ShotsLeft.ToString();
    
            _shootingLaser.NumberOfShotsChange += UpdateLaserShorsLeft;
        }
    
        private void UpdateLaserShorsLeft()
        {
            _laserShotsLeft.text = _shootingLaser.ShotsLeft.ToString();
        }
    
        private void Update()
        {
            _laserRecovery.fillAmount = _shootingLaser.Timer / _shootingLaser.OneShotRecoveryTime;
        }
    
        private void OnDestroy()
        {
            _shootingLaser.NumberOfShotsChange -= UpdateLaserShorsLeft;
        }
    }
}
