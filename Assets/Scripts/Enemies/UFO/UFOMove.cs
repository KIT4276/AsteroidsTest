using System.Collections;
using UnityEngine;

public class UFOMove : MonoBehaviour, IMove
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _minDistance = 1;
    [Space]
    [SerializeField] private float _avoidanceTurningAngle = 30;
    [SerializeField] private float _avoidTime = 5;


    private bool _isActive = false;
    private Transform _target;
    private bool _isAvoidance = false;
    public Vector2 Direction { get; private set; }


    public void SetTarget(ShipCollision shipCollision)
    {
        _target = shipCollision.gameObject.transform;
    }

    public void Initialize(Transform transform, BaseFactory factory, GameStaticData gameStaticData)
    {
        this.transform.position = transform.position;
        this.gameObject.SetActive(true);


        _isActive = true;
    }

    public void StopMove()
    {
        _isActive = false;
    }

    public void Avoid()
    {
        _isAvoidance = true;
        StartCoroutine(WaitForAvoid());

        Direction = new Vector2
            (Direction.x * Mathf.Cos(_avoidanceTurningAngle) - Direction.y * Mathf.Sin(_avoidanceTurningAngle),
             Direction.x * Mathf.Sin(_avoidanceTurningAngle) + Direction.y * Mathf.Cos(_avoidanceTurningAngle));
    }

    private void FixedUpdate()
    {
        if (_isActive && _target != null)
        {
            if (!_isAvoidance)
            {
                Direction = (_target.position - transform.position).normalized;

            }
            _rigidbody.linearVelocity = Direction * _moveSpeed;

            CheckDistance();
        }
    }

    private IEnumerator WaitForAvoid()
    {
        yield return new WaitForSeconds(_avoidTime);
        _isAvoidance = false;
    }

    private void CheckDistance()
    {
        float distance = Vector2.Distance(_target.position, transform.position);

        if (distance < _minDistance)
        {
            _isActive = false;
        }
    }
}
