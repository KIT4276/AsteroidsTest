using UnityEngine;
using Zenject;

public class UFOMove : MonoBehaviour, IMove
{
    private bool _isActive;
    private BaseFactory _factory;

    private Transform _target;

    [Inject]
    private void SetTarget(ShipCollision shipCollision)
    {
        _target = shipCollision.gameObject.transform;
    }

    public void Initialize(Transform transform, BaseFactory factory, GameStaticData gameStaticData)
    {
        this.transform.position = transform.position;
        this.gameObject.SetActive(true);

        _isActive = true;
        _factory = factory;
    }

    public void StopMove()
    {
        _isActive = false;
    }

    private void FixedUpdate()
    {
        if (_isActive)
        {
            transform.Translate(_target.position * 0.01f);
        }
    }
}
