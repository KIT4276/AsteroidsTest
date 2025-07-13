using AsteroidsTest.Assets;

namespace AsteroidsTest.Factories
{
    public class UIFactory
    {
        private IAssets _assets;

        public UIFactory(IAssets assets)
        {
            _assets = assets;
        }

        public StartMenu CreateStartMenu()
        {
            return _assets.Instantiate(AssetsPath.StartMenuPath).GetComponent<StartMenu>();
        }
    }
}
