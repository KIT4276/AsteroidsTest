namespace AsteroidsTest.Save.Data
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
        void Restart();
    }
}
