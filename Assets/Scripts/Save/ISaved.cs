namespace AsteroidsTest.Save
{
    public interface ISaved
    {
        void Save(PlayerSaveData data);
        void Load(PlayerSaveData data);
    }
}
