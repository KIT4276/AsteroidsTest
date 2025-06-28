using System;

public class TargetDefeatPoints
{
    public int _currentPoints; 

    public event Action<int> OnDefeat;
    
    public void OnEnemyDestroyed(int points)
    {
        _currentPoints += points;
        OnDefeat?.Invoke(_currentPoints);
    }
}


