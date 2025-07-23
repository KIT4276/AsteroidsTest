using AsteroidsTest.Save.Data;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsTest.Progress
{
    public class ProgressReadersHolder
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public void ClearAll()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        public void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        public void Register(ISavedProgressReader progressReader)
        {
            //Debug.Log("Register " + progressReader);
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }
    }
}