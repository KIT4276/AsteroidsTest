using UnityEngine;

public interface IMove
{

    public void Initialize(Transform transform, BaseFactory factory, GameStaticData gameStaticData);


    public void StopMove();
}
