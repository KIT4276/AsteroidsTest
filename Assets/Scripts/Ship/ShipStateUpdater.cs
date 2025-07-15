using UnityEngine;
using Zenject;

namespace AsteroidsTest.Ship
{
    public class ShipStateUpdater : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private ShipStateModel _model;

        [Inject]
        public void Construct(ShipStateModel model)
        {
            _model = model;
        }

        private void Update()
        {
            if (_model != null)
                _model.UpdateState(_rigidbody2D);
        }
    }
}
