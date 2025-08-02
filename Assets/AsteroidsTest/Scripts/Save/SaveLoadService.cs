using AsteroidsTest.Progress;
using AsteroidsTest.Save.Data;
using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace AsteroidsTest.Save
{
    public class SaveLoadService
    {
        private readonly ProgressService _progressService;
        private readonly ProgressReadersHolder _progressReadersHolder;
        private readonly string _saveFilePath;
        private readonly string _backupFilePath;

        public SaveLoadService(ProgressService progressService, ProgressReadersHolder progressReadersHolder)
        {
            _progressService = progressService;
            _progressReadersHolder = progressReadersHolder;
            _saveFilePath = Path.Combine(Application.persistentDataPath, "player_progress.json");
            _backupFilePath = _saveFilePath + ".bak";
        }

        public void SaveProgress(Action onSaved = null)
        {
            try
            {
                foreach (ISavedProgress progressWriter in _progressReadersHolder.ProgressWriters)
                {
                    progressWriter.UpdateProgress(_progressService.Progress);
                }

                string json = JsonConvert.SerializeObject(_progressService.Progress, Formatting.Indented);

                CreateBackup();

                File.WriteAllText(_saveFilePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"[Save] Failed to save progress: {e.Message}");
                RestoreFromBackup();
            }

            onSaved?.Invoke();
        }

        public PlayerProgress LoadProgress()
        {
            if (!File.Exists(_saveFilePath))
            {
                return CreateNewProgress();
            }

            try
            {
                PlayerProgress progress = LoadFromFile(_saveFilePath);

                if (progress == null)
                {
                    return TryLoadBackup() ?? CreateNewProgress();
                }

                _progressService.Progress = progress;

                foreach (ISavedProgressReader reader in _progressReadersHolder.ProgressReaders)
                {
                    reader.LoadProgress(progress);
                }

                return progress;
            }
            catch (Exception e)
            {
                Debug.LogError($"[Load] Failed to load progress: {e.Message}");
                return TryLoadBackup() ?? CreateNewProgress();
            }
        }

        private PlayerProgress LoadFromFile(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<PlayerProgress>(json);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[LoadFromFile] Failed to read or deserialize from {path}: {e.Message}");
                return null;
            }
        }

        private PlayerProgress CreateNewProgress()
        {
            var newProgress = new PlayerProgress();
            _progressService.Progress = newProgress;
            return newProgress;
        }

        #region Backup System

        private void CreateBackup()
        {
            try
            {
                if (File.Exists(_saveFilePath))
                {
                    File.Copy(_saveFilePath, _backupFilePath, overwrite: true);
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[Backup] Failed to create backup: {e.Message}");
            }
        }

        private PlayerProgress TryLoadBackup()
        {
            if (!File.Exists(_backupFilePath))
                return null;

            return LoadFromFile(_backupFilePath);
        }

        private void RestoreFromBackup()
        {
            if (!File.Exists(_backupFilePath))
                return;

            try
            {
                File.Copy(_backupFilePath, _saveFilePath, overwrite: true);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[Backup] Failed to restore from backup: {e.Message}");
            }
        }

        #endregion
    }
}
