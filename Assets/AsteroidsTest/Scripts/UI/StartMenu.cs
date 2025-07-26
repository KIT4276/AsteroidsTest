using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsTest.UI
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private Button _startNewGameButton;
        [SerializeField] private Button _continueGameButton;

        public event Action OnStarted;

        private void Awake()
        {
            _startNewGameButton.onClick.AddListener(StartNewGame);
            _continueGameButton.onClick.AddListener(ContinueGame);
        }

        private void StartNewGame()
        {
            ClearProgress();

            ContinueGame();
        }

        private void ContinueGame()
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
