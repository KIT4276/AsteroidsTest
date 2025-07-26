using System;
using UnityEngine.InputSystem;

namespace AsteroidsTest.Input
{
    public class BaseInputHandler
    {
        protected const string MoveForwardActionName = "MoveForward";
        protected const string RotationActionName = "Rotation";
        protected const string BulletFireActionName = "BulletFire";
        protected const string LaserFireActionName = "LaserFire";
    
        protected InputAction _moveAction;
        protected InputAction _rotationAction;
        protected InputAction _bulletFireAction;
        protected InputAction _LaserFireAction;
    
        public event Action BulletFireAction;
        public event Action LaserFireAction;
    
        public BaseInputHandler(PlayerInput playerInput)
        {
            _moveAction = playerInput.actions[MoveForwardActionName];
            _moveAction.Enable();
    
            _rotationAction = playerInput.actions[RotationActionName];
            _rotationAction.Enable();
    
            _bulletFireAction = playerInput.actions[BulletFireActionName];
            _bulletFireAction.Enable();
    
            _LaserFireAction = playerInput.actions[LaserFireActionName];
            _LaserFireAction.Enable();
    
            _bulletFireAction.performed += BulletFire;
            _LaserFireAction.performed += LaserFire;
        }
    
        private void LaserFire(InputAction.CallbackContext context)
        {
            LaserFireAction?.Invoke();
        }
    
        private void BulletFire(InputAction.CallbackContext context)
        {
            BulletFireAction?.Invoke();
        }

        public float GetMoveInputValue() => 
            _moveAction.ReadValue<float>();

        public float GetRotationInputValue() =>
            _rotationAction.ReadValue<float>();
    }
}
