using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UFOMove : MonoBehaviour, IMove
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _minDistance = 1;

    private bool _isActive;
    private BaseFactory _factory;
    private Transform _target;

    public void SetTarget(ShipCollision shipCollision)
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

    private void Update()
    {
        if (_isActive && _target != null)
        {
            Vector2 direction = (_target.position - transform.position).normalized;
            transform.position += (Vector3)(direction * _moveSpeed * Time.deltaTime);

            CheckDistance();
        }
    }

    private void CheckDistance()
    {
        float distance = Vector2.Distance(_target.position, transform.position);

        if (distance < _minDistance)
        {
            _isActive = false ;
        }
    }
}
