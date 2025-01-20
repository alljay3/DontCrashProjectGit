using Assets.Scripts.Plane.Movement;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
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


    private Rigidbody2D _rb;
    private List<ISpeedModifier> _speedModifiers = new List<ISpeedModifier>();
    private PlayerRotation _playerRotation;
    private InputSystem_Actions _inputActions;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputActions = new InputSystem_Actions();
        _playerRotation = new PlayerRotation(_inputActions, transform, _rotationSpeed);

        _speedModifiers.Add(new SimpleFly(_startSpeed, _airplaneAcceleration, _maxSpeed, _brakeFactor, _gravityOnSpeedEffect, transform, _inputActions));
        _speedModifiers.Add(new Graviry(_gravityScale));
        _speedModifiers.Add(new Wind(_windPower, _windDirection));
    }
    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void FixedUpdate()
    {
        foreach (var speedModifier in _speedModifiers)
        {
            _rb.linearVelocity = speedModifier.Apply(_rb.linearVelocity, Time.fixedDeltaTime);
        }

        transform.rotation = _playerRotation.Rotate(Time.fixedDeltaTime);
    }
}
