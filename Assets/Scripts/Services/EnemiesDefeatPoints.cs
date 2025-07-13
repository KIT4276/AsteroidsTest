using AsteroidsTest.Save;

namespace AsteroidsTest.Services
{
    public class EnemiesDefeatPoints : ISaved
    {
        public int CurrentPoints { get; private set; }

        //public EnemiesDefeatPoints()
        //{
        //    CurrentPoints = 0;
        //}

        public void OnEnemyDestroyed(int points)
        {
            CurrentPoints += points;
        }

        public void Save(PlayerSaveData playerSaveData)
        {
            playerSaveData.Score = CurrentPoints;
        }

        public void Load(PlayerSaveData playerSaveData)
        {
            CurrentPoints = playerSaveData.Score;
        }
    }
}
