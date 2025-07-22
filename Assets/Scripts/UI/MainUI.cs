using AsteroidsTest.UI;
using AsteroidsTest.Weapon.Laser;
using UnityEngine;

[RequireComponent(typeof(LaserView), (typeof(ShipStateView)), typeof(GameOverView))]
public class MainUI : MonoBehaviour
{
    [SerializeField] private LaserView _laserView;
    [SerializeField] private ShipStateView _shipStateView;
    [SerializeField] private GameOverView _gameOverView;

    public void Initialize(LaserViewModel laserViewModel, ShipStateViewModel shipStateViewModel, GameOverViewModel gameOverViewModel)
    {
        _laserView.Initialize(laserViewModel);
        _shipStateView.Initialize(shipStateViewModel);
        _gameOverView.Initialize(gameOverViewModel);
    }
}
