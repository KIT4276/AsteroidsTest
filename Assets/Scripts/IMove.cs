using UnityEngine;

public interface IMove
{
    public void Initialize(Transform transform, BaseFactory factory);


    public void StopMove();
}
