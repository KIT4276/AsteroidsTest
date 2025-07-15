using AsteroidsTest.Factories;
using AsteroidsTest.Pause;
using AsteroidsTest.SOScripts;
using UnityEngine;

namespace AsteroidsTest.Weapon.Bullet
{
    public class ProjectileMove : MonoBehaviour, IMove, IPausable
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _moveSpeed = 5f;

        private BaseFactory _factory;
        private bool _isActive;
        private Vector2 _positionLimits;

        public void Initialize(Transform point, BaseFactory factory, GameStaticData gameStaticData)
        {
            _factory = factory;
            _isActive = true;
            transform.position = point.position;
            transform.rotation = point.rotation;

            _positionLimits = gameStaticData.BulletsMoveLimits;
        }

        public void StopMove() =>
            _isActive = false;

        private void FixedUpdate()
        {
            if (_isActive)
            {
                Move();
                CheckPosition();
            }
        }

        private void Move()
        {
            _rigidbody.linearVelocity = transform.up * _moveSpeed;
        }

        protected void CheckPosition()
        {
            if (transform.position.x > _positionLimits.x || transform.position.y > _positionLimits.y
                || transform.position.x < -_positionLimits.x || transform.position.y < -_positionLimits.x)
            {
                _factory.Despawn(this.gameObject);
            }
        }

        public void Pause() => 
            _isActive = false;

        public void Resume() => 
            _isActive = true;
    }
}
