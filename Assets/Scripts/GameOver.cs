using AsteroidsTest.Pause;
using System;

namespace AsteroidsTest
{
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
    
            GameOverAction?.Invoke();
        }
    }
}
