using UnityEngine;

public class BaseAsteroidMove : MonoBehaviour, IMove
{
    [SerializeField] private float _moveSpeed = 0.04f;
    [SerializeField] private Vector2 _positionLimits = new Vector2(35, 35);
 
    private bool _isActive;
    private BaseFactory _asteroidsFactory;

    public void Initialize(Transform transform, BaseFactory asteroidsFactory)
    {
        _asteroidsFactory = asteroidsFactory;

        this.transform.position = transform.position;
        this.gameObject.SetActive(true);
        _isActive = true;

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
            transform.Translate(transform.up * _moveSpeed);
            if (transform.position.x > _positionLimits.x || transform.position.y > _positionLimits.y
                || transform.position.x< -_positionLimits.x || transform.position.y < -_positionLimits.y)
            {
                _asteroidsFactory.Despawn(this.gameObject);
            }
        }
    }
}
