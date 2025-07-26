using System.Collections;
using UnityEngine;

namespace AsteroidsTest.Weapon.Laser
{
    public class ShootingLaserRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _laserDuration = 0.1f;
    
        public IEnumerator LaserEffect(Vector3 start, Vector3 end, float laserThickness)
        {
            _lineRenderer.startWidth = laserThickness;
            _lineRenderer.endWidth = laserThickness;
            _lineRenderer.SetPosition(0, start);
            _lineRenderer.SetPosition(1, end);
            _lineRenderer.enabled = true;
    
            yield return new WaitForSeconds(_laserDuration);
            _lineRenderer.enabled = false;
        }
    }
}
