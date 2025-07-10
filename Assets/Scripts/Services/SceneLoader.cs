using AsteroidsTest.SOScripts;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    private readonly GameStaticData _gameStaticData;

    public SceneLoader(GameStaticData gameStaticData)
    {
        _gameStaticData = gameStaticData;
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(_gameStaticData.GameScene);
    }
}
