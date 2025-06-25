using UnityEngine;

[RequireComponent(typeof(Collider2D), (typeof(FieldOfView)), (typeof(UFOMove)))]
public class Avoidance : MonoBehaviour
{
    [SerializeField] private UFOMove _move;
    [SerializeField] private FieldOfView _fieldOfView;
    [SerializeField] private Collider2D _collider2D;

    private void Update()
    {
        CheckView();
    }

    private void CheckView()
    {
        if (_fieldOfView.IsTargetInSight(out Collider2D target) && target != _collider2D)
        {
            _move.Avoid();
        }
    }
}
