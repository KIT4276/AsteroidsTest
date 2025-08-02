using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsTest.Pause
{
    public class Pauser
    {
        private readonly List<IPausable> _pausables = new();
        private bool _isPaused;

        public void Register(IPausable pausable)
        {
            if (!_pausables.Contains(pausable))
            {
                _pausables.Add(pausable);
            }
        }

        public void Unregister(IPausable pausable)
        {
            if (_pausables.Contains(pausable))
            {
                _pausables.Remove(pausable);
            }
        }

        public void Pause()
        {
            if (!_isPaused)
            {
                _isPaused = true;
                for (int i = 0; i < _pausables.Count; i++)
                {
                    _pausables[i].Pause();
                }
            }
        }

        public void Resume()
        {
            if (_isPaused)
            {
                _isPaused = false;

                for (int i = 0; i < _pausables.Count; i++)
                {
                    Debug.Log(_pausables[i].GetType().Name);
                    _pausables[i].Resume();
                }
            }
        }
    }
}
