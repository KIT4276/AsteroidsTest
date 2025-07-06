using UnityEngine;
using R3;

namespace AsteroidsTest.Ship
{
    public class ShipStateModel 
    {
        public ReactiveProperty<float> PositionX { get; private set; }
        public ReactiveProperty<float> PositionY { get; private set; }
        public ReactiveProperty<float> Angle { get; private set; }
        public ReactiveProperty<float> Speed { get; private set; }

        public ShipStateModel()
        {
            PositionX = new();
            PositionY = new();
            Angle = new();
            Speed = new();
        }

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

            if (newPositionX != PositionX.Value)
            {
                PositionX.Value = newPositionX;
            }
        }

        private void UpdateYPosition(Rigidbody2D rigidbody2D)
        {
            float newPositionY = rigidbody2D.transform.position.y;

            if ( newPositionY != PositionY.Value)
            {
                PositionY.Value = newPositionY;
            }
        }

        private void UpdateAngle(Rigidbody2D rigidbody2D)
        {
            float newAngle = rigidbody2D.transform.eulerAngles.z;

            if (newAngle != Angle.Value)
            {
                Angle.Value = newAngle;
            }
        }

        private void UpdateSpeed(Rigidbody2D rigidbody2D)
        {
            float newSpeed = rigidbody2D.linearVelocity.magnitude;

            if (newSpeed != Speed.Value)
            {
                Speed.Value = newSpeed;
            }
        }
    }
}
