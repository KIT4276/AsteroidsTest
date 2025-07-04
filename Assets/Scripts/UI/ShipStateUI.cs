using TMPro;
using UnityEngine;

namespace AsteroidsTest.UI
{
    public class ShipStateUI : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _ship;
        [Space]
        [SerializeField] private TMP_Text _coordinateX;
        [SerializeField] private TMP_Text _coordinateY;
        [SerializeField] private TMP_Text _angle;
        [SerializeField] private TMP_Text _speed;
        [Space]
        [SerializeField] private float _multiplier = 100;
    
        private void Update()
        {
            _coordinateX.text = (_ship.transform.position.x * _multiplier).ToString("F0");
            _coordinateY.text = (_ship.transform.position.y* _multiplier).ToString("F0");
    
            float angle = 360 - _ship.transform.eulerAngles.z;
            float signedAngle = (angle > 180f) ? angle - 360f : angle;
            _angle.text = signedAngle.ToString("F0");
    
            _speed.text = (_ship.linearVelocity.magnitude* _multiplier).ToString("F0");
        }
    }
}
