using UnityEngine;
using R3;

namespace AsteroidsTest.Ship
{
    public class ShipStateModel 
    {
        private ReactiveProperty<float> _positionX = new();
        private ReactiveProperty<float> _positionY = new();
        private ReactiveProperty<float> _angle = new();
        private ReactiveProperty<float> _speed = new();

        public Observable<float> PositionX => _positionX.AsObservable();
        public Observable<float> PositionY => _positionY.AsObservable();
        public Observable<float> Angle => _angle.AsObservable();
        public Observable<float> Speed => _speed.AsObservable();

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

            if (newPositionX != _positionX.Value)
            {
                _positionX.Value = newPositionX;
            }
        }

        private void UpdateYPosition(Rigidbody2D rigidbody2D)
        {
            float newPositionY = rigidbody2D.transform.position.y;

            if ( newPositionY != _positionY.Value)
            {
                _positionY.Value = newPositionY;
            }
        }

        private void UpdateAngle(Rigidbody2D rigidbody2D)
        {
            float newAngle = rigidbody2D.transform.eulerAngles.z;

            if (newAngle != _angle.Value)
            {
                _angle.Value = newAngle;
            }
        }

        private void UpdateSpeed(Rigidbody2D rigidbody2D)
        {
            float newSpeed = rigidbody2D.linearVelocity.magnitude;

            if (newSpeed != _speed.Value)
            {
                _speed.Value = newSpeed;
            }
        }
    }
}
