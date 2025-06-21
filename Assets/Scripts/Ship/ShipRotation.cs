using UnityEngine;
using Zenject;

public class ShipRotation : MonoBehaviour
{
    [SerializeField] private float _acceleration = 2;
    [SerializeField] private Rigidbody2D _rigidbody;

    private IInputHandler _inputHandler;

    [Inject]
    private void Initialize(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    private void FixedUpdate()
    {
        if (_inputHandler != null)
        {
            float input = _inputHandler.GetRotationInputValue();

            if (_inputHandler != null)
            {
                if (input != 0)
                {
                    _rigidbody.AddTorque(-input * _acceleration);
                }
            }
        }
    }
}

