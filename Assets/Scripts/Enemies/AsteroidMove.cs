//using System;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;

    private bool _isActive;

    private void Start()
    {
        Initialize(transform.position);
    }

    public void Initialize(Vector2 position)
    {
        transform.position = position;
        this.gameObject.SetActive(true);
        _isActive = true;

        SelectRandomRotate();
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
            transform.Translate(transform.up * _moveSpeed);
        }
    }
}
