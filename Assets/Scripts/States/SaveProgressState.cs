using AsteroidsTest.Save;

namespace AsteroidsTest.States
{
    public class SaveProgressState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly SaveLoadService _saveLoadService;

        public SaveProgressState(StateMachine stateMachine, SaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            _saveLoadService.SaveProgress();

        }

        public void Exit()
        {
           
        }
    }
}