using System.Collections.Generic;

namespace AsteroidsTest.Save
{
    public class SaveCoordinator
    {
        private readonly List<ISaved> _savedObjects = new();
        private readonly SaveLoader _loader = new();

        public void Register(ISaved saved)
        {
            if (!_savedObjects.Contains(saved))
            {
                _savedObjects.Add(saved);
            }
        }

        public void SaveAll()
        {
            var data = new PlayerSaveData();

            foreach (var obj in _savedObjects)
                obj.Save(data);

            _loader.Save(data);
        }

        public void LoadAll()
        {
            var data = _loader.Load();

            foreach (var obj in _savedObjects)
                obj.Load(data);
        }
    }
}
