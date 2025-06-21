using UnityEngine;

public class ProjectileMove : MonoBehaviour, IMove
{
    [SerializeField] private float _moveSpeed = 0.05f;

    private BaseFactory _factory;
    private bool _isActive;

    public void Initialize(Transform point, BaseFactory factory)
    {
        _factory = factory;

        _isActive = true;
        transform.position = point.position;
        transform.rotation = point.rotation;
    }

    public void StopMove()
    {
        _isActive = false;
    }

    private void FixedUpdate()
    {
        if (_isActive)
        {
            transform.Translate(transform.up * _moveSpeed);
        }
    }
}
