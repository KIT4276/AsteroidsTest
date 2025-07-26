using UnityEngine;

namespace AsteroidsTest.Pause
{
    [RequireComponent(typeof(PausableRegistrator))]
    public class PausableRigidbody2D : MonoBehaviour, IPausable
    {
        [SerializeField] private Rigidbody2D _rigidbody;
    
        private Vector2 _savedVelosity;
    
        public void Pause()
        {
            _savedVelosity = _rigidbody.linearVelocity;
    
            _rigidbody.linearVelocity = Vector2.zero;
            _rigidbody.simulated = false;
        }
    
        public void Resume()
        {
            _rigidbody.simulated = true;
            _rigidbody.linearVelocity = _savedVelosity;
        }
    }
}
