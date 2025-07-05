using System;
using UnityEngine;

namespace AsteroidsTest.Ship
{
    public class ShipStateModel : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private float _positionX;
        private float _positionY;
        private float _angle;
        private float _speed;

        public event Action<float> PositionXChanged;
        public event Action<float> PositionYChanged;
        public event Action<float> AngleChanged;
        public event Action<float> SpeedChanged;

        private void Update()
        {
            UpdateXPosition();
            UpdateYPosition();
            UpdateAngle();
            UpdateSpeed();
        }

        private void UpdateXPosition()
        {
            float newPositionX = _rigidbody2D.transform.position.x;

            if (newPositionX != _positionX)
            {
                _positionX = newPositionX;

                PositionXChanged?.Invoke(newPositionX);
            }
        }

        private void UpdateYPosition()
        {
            float newPositionY = _rigidbody2D.transform.position.y;

            if ( newPositionY != _positionY)
            {
                _positionY = newPositionY;

                PositionYChanged?.Invoke(newPositionY);
            }
        }

        private void UpdateAngle()
        {
            float newAngle = _rigidbody2D.transform.eulerAngles.z;

            if (newAngle != _angle)
            {
                _angle = newAngle;

                AngleChanged?.Invoke(newAngle);
            }
        }

        private void UpdateSpeed()
        {
            float newSpeed = _rigidbody2D.linearVelocity.magnitude;

            if (newSpeed != _speed)
            {
                _speed = newSpeed;

                SpeedChanged?.Invoke(_speed);
            }
        }
    }
}
