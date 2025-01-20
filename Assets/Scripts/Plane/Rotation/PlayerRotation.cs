using UnityEngine;

public class PlayerRotation
{
    private InputSystem_Actions _inputActions;
    private Transform _targetTransform;
    private float _rotationSpeed;

    public PlayerRotation(InputSystem_Actions inputActions, Transform targetTransform, float rotationSpeed)
    {
        _inputActions = inputActions;
        _targetTransform = targetTransform;
        _rotationSpeed = rotationSpeed;
    }

    public Quaternion Rotate(float deltaTime)
    {
        float playerInput = _inputActions.Player.Move.ReadValue<Vector2>().x;
        float rotationAmount = playerInput * _rotationSpeed * deltaTime;
        Quaternion rotation = Quaternion.Euler(0, 0, rotationAmount);

        return _targetTransform.rotation * rotation;
    }
}
