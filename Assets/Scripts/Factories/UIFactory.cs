using AsteroidsTest.Assets;
using AsteroidsTest.UI;
using AsteroidsTest.Weapon.Laser;

namespace AsteroidsTest.Factories
{
    public class UIFactory
    {
        private IAssets _assets;
        private LaserViewModel _laserViewModel;
        private ShipStateViewModel _shipStateViewModel;
        private GameOverViewModel _gameOverViewModel;

        public UIFactory(IAssets assets, LaserViewModel laserViewModel, ShipStateViewModel shipStateViewModel, GameOverViewModel gameOverViewModel)
        {
            _assets = assets;
            _laserViewModel = laserViewModel;
            _shipStateViewModel = shipStateViewModel;
            _gameOverViewModel = gameOverViewModel;
        }

        public StartMenu CreateStartMenu() =>
            _assets.Instantiate(AssetsPath.StartMenuPath).GetComponent<StartMenu>();

        public void CreateMainUI()
        {
            var mainUI = _assets.Instantiate(AssetsPath.MainUIPath).GetComponent<MainUI>();
            mainUI.Initialize(_laserViewModel, _shipStateViewModel, _gameOverViewModel);
        }
    }
}
