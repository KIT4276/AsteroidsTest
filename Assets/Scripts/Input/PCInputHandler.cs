using UnityEngine.InputSystem;

public class PCInputHandler : BaceInputHandler
{
    public PCInputHandler(PlayerInput playerInput)
    {
        _moveAction = playerInput.actions[MoveForwardActionName];
        _moveAction.Enable();

        _rotationAction = playerInput.actions[RotationActionName];
        _rotationAction.Enable();
    }
}
