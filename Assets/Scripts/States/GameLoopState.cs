using System;

namespace AsteroidsTest.States
{
    public class GameLoopState : IState
    {
        public event Action GameStarted;
        public void Enter()
        {
            GameStarted?.Invoke();
        }

        public void Exit() { }
    }
}
