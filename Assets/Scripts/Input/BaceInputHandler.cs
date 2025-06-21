using System;
using UnityEngine.InputSystem;

public class BaceInputHandler : IInputHandler
{
    protected const string MoveForwardActionName = "MoveForward";
    protected const string RotationActionName = "Rotation";
    protected const string BulletFireActionName = "BulletFire";

    protected InputAction _moveAction;
    protected InputAction _rotationAction;
    protected InputAction _bulletFireAction;

    public event Action BulletFireAction;

    public BaceInputHandler(PlayerInput playerInput)
    {
        _moveAction = playerInput.actions[MoveForwardActionName];
        _moveAction.Enable();

        _rotationAction = playerInput.actions[RotationActionName];
        _rotationAction.Enable();

        _bulletFireAction = playerInput.actions[BulletFireActionName];
        _bulletFireAction.Enable();

        _bulletFireAction.performed += BulletFire;
    }

    private void BulletFire(InputAction.CallbackContext context)
    {
        BulletFireAction?.Invoke();
    }

    public float GetMoveInputValue()
    {
       return _moveAction.ReadValue<float>();
    }

    public float GetRotationInputValue()
    {
        return _rotationAction.ReadValue<float>();
    }
}
