using AsteroidsTest.Progress;
using AsteroidsTest.Save.Data;
using UnityEngine;

namespace AsteroidsTest.Services
{
    public class EnemiesDefeatPoints : ISavedProgress
    {
        public int CurrentPoints { get; private set; } = new();

        public void OnEnemyDestroyed(int points)
        {
            CurrentPoints += points;
            //Debug.Log("CurrentPoints " + CurrentPoints);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
           // Debug.Log("UpdateProgress EnemiesDefeatPoints");
            progress.Score = CurrentPoints;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            CurrentPoints = progress.Score;
           // Debug.Log("CurrentPoints " + CurrentPoints);
        }
    }
}
