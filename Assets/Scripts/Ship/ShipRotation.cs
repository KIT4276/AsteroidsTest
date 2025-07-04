using UnityEngine;
using Zenject;

public class ShipRotation : MonoBehaviour
{
    [SerializeField] private float _acceleration = 2;
    [SerializeField] private Rigidbody2D _rigidbody;

    private BaceInputHandler _inputHandler;
    private float _input;

    [Inject]
    private void Initialize(BaceInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    private void Update()
    {
        if (_inputHandler != null)
        {
            _input = _inputHandler.GetRotationInputValue();
        }
    }

    private void FixedUpdate()
    {
        if (_input != 0)
        {
            _rigidbody.AddTorque(-_input * _acceleration);
        }
    }
}

