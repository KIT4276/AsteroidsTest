using System;

public class GameOver 
{
    private readonly Pauser _pauser;

    public GameOver(Pauser pauser)
    {
       _pauser = pauser;
    }
    
    public event Action GameOverAction;

    public void OnGameOver()
    {
        _pauser.Pause();

        //Time.timeScale = 0;
        GameOverAction?.Invoke();
    }
}
