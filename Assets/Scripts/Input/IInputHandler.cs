using System;

public interface IInputHandler
{
    public event Action BulletFireAction;
    public event Action LaserFireAction;

    public float GetRotationInputValue();
    public float GetMoveInputValue();
}