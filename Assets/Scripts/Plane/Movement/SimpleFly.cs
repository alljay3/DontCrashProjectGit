using UnityEngine;

public class SimpleFly : ISpeedModifier
{
    private float _speed;
    private float _acceleration;
    private float _brakeAcceleration;
    private float _gravityScale;
    private float _maxSpeed;
    private Transform _airplaneTransform;
    private InputSystem_Actions _inputActions;

    public SimpleFly(float startSpeed, float acceleration, float maxSpeed, float brakeAcceleration, float gravityScale, Transform airplaneTransform, InputSystem_Actions inputActions)
    {
        _speed = startSpeed;
        _acceleration = acceleration;
        _brakeAcceleration = brakeAcceleration;
        _gravityScale = gravityScale;
        _airplaneTransform = airplaneTransform;
        _inputActions = inputActions;
        _maxSpeed = maxSpeed;
    }

    public float Speed { 
        get { return _speed; }
        set { _speed = value; }
    }

    public Vector3 Apply(Vector3 velocity, float deltaTime)
    {
        float playerInput = _inputActions.Player.Move.ReadValue<Vector2>().y;

        if (playerInput > 0)
        {
            _speed += _acceleration * deltaTime * playerInput;
        }


        float angle = _airplaneTransform.rotation.eulerAngles.z;
        float sinValue = Mathf.Sin(angle * Mathf.Deg2Rad);

        _speed -= sinValue * _gravityScale * deltaTime;

        _speed = Mathf.Clamp(_speed, 0, _maxSpeed);
        float speedAlongRight = Vector3.Dot(velocity, _airplaneTransform.right.normalized);
        if (playerInput < 0 && speedAlongRight > 0)
        {
            _speed += _brakeAcceleration * deltaTime * playerInput;
        }

        return _speed * deltaTime * _airplaneTransform.right.normalized;

    }
}
