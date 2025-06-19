using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.05f;

    private void FixedUpdate()
    {
        transform.Translate(transform.up * _moveSpeed);
    }
}
