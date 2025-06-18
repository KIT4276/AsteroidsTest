using UnityEngine;
using UnityEngine.InputSystem;

public class StartTest : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ShipMove _shipMove;
    [SerializeField] private ShipRotation _shipRotation;


    private void Start()
    {
        var inputHandler = new PCInputHandler(_playerInput);

        _shipMove.Initialize(inputHandler);
        _shipRotation.Initialize(inputHandler);
    }
}
