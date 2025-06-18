using UnityEngine;
using UnityEngine.InputSystem;

public class BaceInputHandler : IInputHandler
{
    protected const string MoveForwardActionName = "MoveForward";
    protected const string RotationActionName = "Rotation";

    protected InputAction _moveAction;
    protected InputAction _rotationAction;

    public float GetMoveInputValue()
    {
       return _moveAction.ReadValue<float>();
    }

    public float GetRotationInputValue()
    {
        return _rotationAction.ReadValue<float>();
    }
}
