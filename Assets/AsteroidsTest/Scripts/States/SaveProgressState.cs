using AsteroidsTest.Save;

namespace AsteroidsTest.States
{
    public class SaveProgressState : IState
    {
        private readonly SaveLoadService _saveLoadService;

        public SaveProgressState(SaveLoadService saveLoadService)
        {
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