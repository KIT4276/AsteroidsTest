using AsteroidsTest.Progress;
using AsteroidsTest.Save.Data;
using System;
using System.IO;
using UnityEngine;

namespace AsteroidsTest.Save
{
    public class SaveLoadService
    {
        private readonly ProgressService _progressService;
        private readonly ProgressReadersHolder _progressReadersHolder;
        private readonly string _saveFilePath;

        public SaveLoadService(ProgressService progressService, ProgressReadersHolder progressReadersHolder)
        {
            _progressService = progressService;
            _progressReadersHolder = progressReadersHolder;
            _saveFilePath = Path.Combine(Application.persistentDataPath, "player_progress.json");

            //Debug.Log("Save file path: " + _saveFilePath);
        }

        public void SaveProgress()
        {
            try
            {
                // Debug.Log("[Save] Starting save process...");

                foreach (ISavedProgress progressWriter in _progressReadersHolder.ProgressWriters)
                {
                    progressWriter.UpdateProgress(_progressService.Progress);
                }

                string json = JsonUtility.ToJson(_progressService.Progress, prettyPrint: true);
                // Debug.Log("[Save] JSON data: " +json);

                CreateBackup();

                File.WriteAllText(_saveFilePath, json);
                //  Debug.Log($"[Save] Progress successfully saved to: " +_saveFilePath);
            }
            catch (Exception e)
            {
                Debug.LogError($"[Save] Failed to save progress: {e.Message}");
                RestoreFromBackup();
            }
        }

        public PlayerProgress LoadProgress()
        {
            try
            {
                if (!File.Exists(_saveFilePath))
                {
                    // Debug.Log("[Load] No save file found. Creating new progress.");
                    return CreateNewProgress();
                }

                string json = File.ReadAllText(_saveFilePath);
                //Debug.Log($"[Load] Loaded JSON: " +json);

                PlayerProgress progress = JsonUtility.FromJson<PlayerProgress>(json);

                if (progress == null)
                {
                    // Debug.LogWarning("[Load] Invalid save data. Trying backup...");
                    return TryLoadBackup() ?? CreateNewProgress();
                }

                _progressService.Progress = progress;

                // Debug.Log($"[Load] Success! Score: " +progress.Score} +" LaserShots: "+progress.LaserShots);
                return progress;
            }
            catch (Exception e)
            {
                Debug.LogError($"[Load] Failed to load progress: {e.Message}");
                return TryLoadBackup() ?? CreateNewProgress();
            }
        }

        private PlayerProgress CreateNewProgress()
        {
            PlayerProgress newProgress = new PlayerProgress();
            _progressService.Progress = newProgress;
            //Debug.Log("[System] Created new progress");
            return newProgress;
        }

        #region Backup System
        private string GetBackupPath() => _saveFilePath + ".bak";

        private void CreateBackup()
        {
            try
            {
                if (File.Exists(_saveFilePath))
                {
                    File.Copy(_saveFilePath, GetBackupPath(), overwrite: true);
                    // Debug.Log("[Backup] Created backup copy");
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[Backup] Failed to create backup: {e.Message}");
            }
        }

        private PlayerProgress TryLoadBackup()
        {
            string backupPath = GetBackupPath();
            if (!File.Exists(backupPath)) return null;

            try
            {
                string json = File.ReadAllText(backupPath);
                var progress = JsonUtility.FromJson<PlayerProgress>(json);
                if (progress != null)
                {
                    // Debug.Log("[Backup] Successfully restored from backup");
                    return progress;
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[Backup] Failed to restore from backup: {e.Message}");
            }

            return null;
        }

        private void RestoreFromBackup()
        {
            var backup = TryLoadBackup();
            if (backup != null)
            {
                File.Copy(GetBackupPath(), _saveFilePath, overwrite: true);
                // Debug.Log("[Backup] Restored main file from backup");
            }
        }
        #endregion
    }
}
