using UnityEngine;

public class BaseAsteroidMove : MonoBehaviour, IMove
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed = 0.04f;
    private float _positionLimits;

    private bool _isActive;
    private BaseFactory _asteroidsFactory;

    public void Initialize(Transform transform, BaseFactory asteroidsFactory, GameStaticData gameStaticData)
    {
        _asteroidsFactory = asteroidsFactory;

        this.transform.position = transform.position;
        this.gameObject.SetActive(true);
        _isActive = true;
        _positionLimits = gameStaticData.MoveLimits;

        SelectRandomRotate();
    }

    public void StopMove()
    {
        _isActive = false;
    }

    private void SelectRandomRotate()
    {
        float randomAngle = Random.Range(0f, 360f);
        transform.Rotate(0f, 0f, randomAngle);
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
        _rigidbody.linearVelocity = transform.up * _moveSpeed;
    }

    private void CheckPosition()
    {
        if (transform.position.x > _positionLimits || transform.position.y > _positionLimits
            || transform.position.x < -_positionLimits || transform.position.y < -_positionLimits)
        {
            _asteroidsFactory.Despawn(this.gameObject);
        }
    }
}
