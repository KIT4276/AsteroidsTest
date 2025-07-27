using AsteroidsTest.Input;
using AsteroidsTest.Save.Data;
using AsteroidsTest.States;
using System;
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

        private BaseInputHandler _inputHandler;
        private float _currentInput;
    
        [Inject]
        private void Initialize(BaseInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        //public void OnBootstrap()
        //{
        //    this.gameObject.SetActive(false);
        //}

        //public void OnGameStarted()
        //{
        //    this.gameObject.SetActive(true);
        //    transform.position = Vector3.zero;  
        //    transform.rotation = Quaternion.identity;
        //}

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
