using AsteroidsTest.Save;
using AsteroidsTest.Save.Data;

namespace AsteroidsTest.Services
{
    public class EnemiesDefeatPoints : ISavedProgress
    {
        public int CurrentPoints { get; private set; }

        public void OnEnemyDestroyed(int points)
        {
            CurrentPoints += points;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.Score = CurrentPoints;
           
        }

        public void LoadProgress(PlayerProgress progress)
        {
            CurrentPoints = progress.Score;
            
        }
    }
}
