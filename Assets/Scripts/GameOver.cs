using System;
using UnityEngine;

public class GameOver 
{
    public event Action GameOverAction;

    public void OnGameOver()
    {
        Time.timeScale = 0;
        GameOverAction?.Invoke();
    }
}
