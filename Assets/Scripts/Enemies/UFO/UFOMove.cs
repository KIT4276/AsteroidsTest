using AsteroidsTest.Factories;
using AsteroidsTest.Pause;
using AsteroidsTest.Ship;
using AsteroidsTest.SOScripts;
using UnityEngine;

namespace AsteroidsTest.Enemies.UFO
{
    public class UFOMove : MonoBehaviour, IMove, IPausable
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private float _minDistance = 1;
    
        private bool _isActive = false;
        private bool _isMoving = true; 
        private Transform _target;
        public Vector2 Direction { get; private set; }

        public void SetTarget(ShipCollision shipCollision) => 
            _target = shipCollision.gameObject.transform;

        public void Initialize(Transform transform, BaseFactory factory, GameStaticData gameStaticData)
        {
            this.transform.position = transform.position;
            gameObject.SetActive(true);
    
            _isActive = true;
        }

        public void StopMove() => 
            _isActive = false;

        public void Pause() =>
            _isMoving = false;

        public void Resume() =>
            _isMoving = true;

        private void FixedUpdate()
        {
            if (_isMoving && _isActive && _target != null)
            {
                    Direction = (_target.position - transform.position).normalized;
    
                _rigidbody.linearVelocity = Direction * _moveSpeed;
    
                CheckDistance();
            }
        }
    
        private void CheckDistance()
        {
            float distance = Vector2.Distance(_target.position, transform.position);
    
            if (distance < _minDistance)
            {
                _isActive = false;
            }
        }
    }
}
