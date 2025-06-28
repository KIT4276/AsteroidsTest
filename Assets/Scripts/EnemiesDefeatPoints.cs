using UnityEngine;

public class EnemiesDefeatPoints 
{
    public int CurrentPoints { get; private set; }

    public EnemiesDefeatPoints()
    {
        CurrentPoints = 0;
    }

    public void OnEnemyDestroyed(int points)
    {
        CurrentPoints += points;
        Debug.Log(CurrentPoints);
    }
}
