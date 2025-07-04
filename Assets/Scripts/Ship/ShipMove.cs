using AsteroidsTest.Input;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Ship
{
    public class ShipMove : MonoBehaviour
    {
        [SerializeField] private float _acceleration = 2;
        [SerializeField] private Rigidbody2D _rigidbody;
        [Space]
        [SerializeField] private float _x_limits;
        [SerializeField] private float _y_limits;
        [SerializeField] private float _indentation = 1;
    
        private BaceInputHandler _inputHandler;
        private float _currentInput;
    
        [Inject]
        private void Initialize(BaceInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }
    
        private void Update()
        {
            if (_inputHandler != null)
            {
                _currentInput = _inputHandler.GetMoveInputValue();
            }
        }
    
        private void FixedUpdate()
        {
            if (_currentInput != 0)
            {
                Vector3 force = transform.up * _currentInput * _acceleration;
                _rigidbody.AddForce(force);
    
                CheckPosition();
            }
        }
    
        private void CheckPosition()
        {
            if (transform.position.x < -_x_limits)
            {
                transform.position = new Vector2(_x_limits - _indentation, transform.position.y);
            }
            else if (transform.position.x > _x_limits)
            {
                transform.position = new Vector2(-_x_limits + _indentation, transform.position.y);
            }
    
            if (transform.position.y < -_y_limits)
            {
                transform.position = new Vector2(transform.position.x, _y_limits - _indentation);
            }
            else if (transform.position.y > _y_limits)
            {
                transform.position = new Vector2(transform.position.x, -_y_limits + _indentation);
            }
        }
    }
}
