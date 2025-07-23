using System;
using System.IO;
using UnityEngine;

namespace AsteroidsTest.UI
{
    public class StartMenu : MonoBehaviour
    {
        public event Action OnStarted;

        public void StartNewGame()
        {
            ClearProgress();

            ContinueGame();
        }

        public void ContinueGame()
        {
            OnStarted?.Invoke();
        }

        private void ClearProgress()
        {
            string savePath = Path.Combine(Application.persistentDataPath, "player_progress.json");
            string backupPath = savePath + ".bak";

            if (File.Exists(savePath))
                File.Delete(savePath);

            if (File.Exists(backupPath))
                File.Delete(backupPath);
        }
    }
}
