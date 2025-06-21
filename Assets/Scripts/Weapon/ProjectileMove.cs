using UnityEngine;

public class ProjectileMove : MonoBehaviour, IMove
{
    [SerializeField] private float _moveSpeed = 0.05f;

    private BaseFactory _factory;
    private bool _isActive;
    private float _positionLimits;

    public void Initialize(Transform point, BaseFactory factory, GameStaticData gameStaticData)
    {
        _factory = factory;
        _isActive = true;
        transform.position = point.position;
        transform.rotation = point.rotation;

        _positionLimits = gameStaticData.MoveLimits;
    }

    public void StopMove()
    {
        _isActive = false;
    }

    private void FixedUpdate()
    {
        if (_isActive)
        {
            Move();
            CheckPosition();
        }
    }

    private void Move()
    {
        transform.position += transform.up * _moveSpeed;
    }

    protected void CheckPosition()
    {
        if (transform.position.x > _positionLimits || transform.position.y > _positionLimits
            || transform.position.x < -_positionLimits || transform.position.y < -_positionLimits)
        {
            _factory.Despawn(this.gameObject);
        }
    }
}
