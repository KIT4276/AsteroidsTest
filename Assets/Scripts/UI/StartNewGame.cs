using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else

        Application.Quit();
#endif

    }
}
