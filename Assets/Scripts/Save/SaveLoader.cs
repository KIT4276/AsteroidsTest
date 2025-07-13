using UnityEngine;

namespace AsteroidsTest.Save
{
    public class SaveLoader
    {
        private const string SaveKey = "player_save";

        public void Save(PlayerSaveData data)
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(SaveKey, json);
            PlayerPrefs.Save();
        }

        public PlayerSaveData Load()
        {
            if (!PlayerPrefs.HasKey(SaveKey)) return new PlayerSaveData();

            string json = PlayerPrefs.GetString(SaveKey);
            return JsonUtility.FromJson<PlayerSaveData>(json);
        }
    }
}

