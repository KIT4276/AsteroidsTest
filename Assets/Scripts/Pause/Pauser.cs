using System.Collections.Generic;

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
            _pausables.Remove(pausable);
    
        }
    
        public void Pause()
        {
            if (!_isPaused)
            {
                _isPaused = true;
    
                foreach (var pausable in _pausables)
                {
                    pausable.Pause();
                }
            }
        }
    
        public void Resume()
        {
            if (_isPaused)
            {
                _isPaused = false;
                foreach (var pausable in _pausables)
                {
                    pausable.Resume();
                }
            }
        }
    
        public void Reset()
        {
            _pausables.Clear();
            _isPaused = false;
        }
    }
}
