using AsteroidsTest.Progress;
using AsteroidsTest.Save.Data;

namespace AsteroidsTest.Save
{
    public class SaveLoadService
    {
        private const string ProgressKey = "Progress";

        private readonly ProgressService _progressService;
        private readonly ProgressReadersHolder _progressReadersHolder;

        public SaveLoadService(ProgressService progressService, ProgressReadersHolder progressReadersHolder)
        {
            _progressService = progressService;
            _progressReadersHolder = progressReadersHolder;
        }

        public void SaveProgress()
        {
            //foreach (ISavedProgress progressWriter in _progressReadersHolder.ProgressWriters)
            //    progressWriter.UpdateProgress(_progressService.Progress);

            //PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());

            // TODO
        }

        public PlayerProgress LoadProgress()
        {
            return null; //PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();

            // TODO
        }
    }
}