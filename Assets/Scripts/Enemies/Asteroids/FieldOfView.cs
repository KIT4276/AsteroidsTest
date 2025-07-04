using AsteroidsTest.Enemies.UFO;
using UnityEditor;
using UnityEngine;

namespace AsteroidsTest.Enemies.Asteroids
{
    public class FieldOfView : MonoBehaviour
    {
        [SerializeField] private UFOMove _uFOMove;
        [SerializeField] private float _viewRadius = 5f;
        [SerializeField] private float _viewAngle = 45f;
        [SerializeField] private LayerMask _targetLayer;
    
        public bool IsTargetInSight(out Collider2D t)
        {
            Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, _viewRadius, _targetLayer);
    
            foreach (Collider2D target in targetsInViewRadius)
            {
                Vector2 dirToTarget = (target.transform.position - transform.position).normalized;
                float angleToTarget = Vector2.Angle(_uFOMove.Direction, dirToTarget); 
    
                if (angleToTarget < _viewAngle / 2f)
                {
                    t = target;
                    return true;
                }
            }
            t = null;
            return false;
        }
    
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _viewRadius);
        }
    
    #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = new Color(1, 1, 0, 0.2f);
            Vector3 forward = _uFOMove.Direction;
    
            Handles.DrawSolidArc(
                transform.position,
                Vector3.forward,
                Quaternion.Euler(0, 0, -_viewAngle / 2f) * forward,
                _viewAngle,
                _viewRadius
            );
        }
    #endif
    }
}
