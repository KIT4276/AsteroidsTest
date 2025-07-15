using AsteroidsTest.Progress;
using AsteroidsTest.Save.Data;
using UnityEngine;

namespace AsteroidsTest.Save
{
    public class SaveLoadService
    {
        private const string ProgressKey = "Progress";

        private readonly ProgressService _progressService;
        private readonly ProgressReadersHolder _progressReadersHolder;

        public SaveLoadService(ProgressService progressService, ProgressReadersHolder progressReadersHolder)
        {
            _progressService = progressService;
            _progressReadersHolder = progressReadersHolder;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _progressReadersHolder.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);

            string json = JsonUtility.ToJson(_progressService.Progress);
            PlayerPrefs.SetString(ProgressKey, json);
            PlayerPrefs.Save();
        }

        public PlayerProgress LoadProgress()
        {
            string json = PlayerPrefs.GetString(ProgressKey);
            PlayerProgress progress = JsonUtility.FromJson<PlayerProgress>(json);

            foreach(ISavedProgress progressReader in _progressReadersHolder.ProgressWriters)
                progressReader.LoadProgress(_progressService.Progress);

            return progress;
        }
    }
}