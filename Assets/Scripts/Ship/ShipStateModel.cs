using System;
using UnityEngine;

namespace AsteroidsTest.Ship
{
    public class ShipStateModel 
    {
        private float _positionX;
        private float _positionY;
        private float _angle;
        private float _speed;

        public event Action<float> PositionXChanged;
        public event Action<float> PositionYChanged;
        public event Action<float> AngleChanged;
        public event Action<float> SpeedChanged;

        public void UpdateState(Rigidbody2D rigidbody2D)
        {
            UpdateXPosition(rigidbody2D);
            UpdateYPosition(rigidbody2D);
            UpdateAngle(rigidbody2D);
            UpdateSpeed(rigidbody2D);
        }

        private void UpdateXPosition(Rigidbody2D rigidbody2D)
        {
            float newPositionX = rigidbody2D.transform.position.x;

            if (newPositionX != _positionX)
            {
                _positionX = newPositionX;

                PositionXChanged?.Invoke(newPositionX);
            }
        }

        private void UpdateYPosition(Rigidbody2D rigidbody2D)
        {
            float newPositionY = rigidbody2D.transform.position.y;

            if ( newPositionY != _positionY)
            {
                _positionY = newPositionY;

                PositionYChanged?.Invoke(newPositionY);
            }
        }

        private void UpdateAngle(Rigidbody2D rigidbody2D)
        {
            float newAngle = rigidbody2D.transform.eulerAngles.z;

            if (newAngle != _angle)
            {
                _angle = newAngle;

                AngleChanged?.Invoke(newAngle);
            }
        }

        private void UpdateSpeed(Rigidbody2D rigidbody2D)
        {
            float newSpeed = rigidbody2D.linearVelocity.magnitude;

            if (newSpeed != _speed)
            {
                _speed = newSpeed;

                SpeedChanged?.Invoke(_speed);
            }
        }
    }
}
