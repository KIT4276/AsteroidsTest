using System;

public interface IInputHandler
{
    public event Action BulletFireAction;

    public float GetRotationInputValue();
    public float GetMoveInputValue();
}