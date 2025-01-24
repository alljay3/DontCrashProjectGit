using Assets.Scripts.Plane.Movement;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleMovement : LevelStateKeeper
{

    [Header("Movement")]
    [SerializeField] private float _startSpeed = 0f;
    [SerializeField] protected float _maxSpeed = 400f;
    [SerializeField] private float _airplaneAcceleration = 3f;
    [SerializeField] private float _brakeFactor = 3f;

    [Header("Nature")]
    [SerializeField] private float _gravityScale = 3f;
    [SerializeField] private float _gravityOnSpeedEffect = 3f;
    [SerializeField] private float _windPower = 0f;
    [SerializeField] private Vector3 _windDirection = Vector3.right;

    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed = 10;

    [Header("Ground")]
    [SerializeField] private GroundCheck _groundCheck;

    private Rigidbody2D _rb;
    private List<ISpeedModifier> _flySpeedModifiers = new List<ISpeedModifier>();
    private List<ISpeedModifier> _groundSpeedModifiers = new List<ISpeedModifier>();
    private PlayerRotation _playerRotation;
    private InputSystem_Actions _inputActions;

    private SimpleFly _simpleFly;

    [Inject]
    public void Construct(InputSystem_Actions inputActions)
    {
        _inputActions = inputActions;
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerRotation = new PlayerRotation(_inputActions, transform, _rotationSpeed);
        _simpleFly = new SimpleFly(_startSpeed, _groundCheck, _airplaneAcceleration, _maxSpeed, _brakeFactor, _gravityOnSpeedEffect, transform, _inputActions);
        _flySpeedModifiers.Add(_simpleFly);
        _groundSpeedModifiers.Add(_simpleFly);

        Graviry gravity = new Graviry(_gravityScale);
        _flySpeedModifiers.Add(gravity);
        _groundSpeedModifiers.Add(gravity);

        Wind wind = new Wind(_windPower, _windDirection);
        _flySpeedModifiers.Add(wind);

    }
    protected override void RestoreState()
    {
        base.RestoreState();
        _simpleFly.Speed = _startSpeed;
    }

    public float Speed()
    {
        return _simpleFly.Speed;
    }

    private void FixedUpdate()
    {
        var speedModifiers = _groundCheck.IsGrounded ? _groundSpeedModifiers : _flySpeedModifiers;
        foreach (var speedModifier in speedModifiers)
        {
            _rb.linearVelocity = speedModifier.Apply(_rb.linearVelocity, Time.fixedDeltaTime);
        }

        transform.rotation = _playerRotation.Rotate(Time.fixedDeltaTime);
    }
}
