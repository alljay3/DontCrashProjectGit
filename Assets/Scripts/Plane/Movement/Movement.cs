using Assets.Scripts.Plane.Movement;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _brakeFactor = 10;

    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed = 10;

    [Header("Nature")]
    [SerializeField] private float _gravityScale = 9.8f;
    [SerializeField] private float _windPower = 0f;
    [SerializeField] private Vector3 _windDirection = Vector3.right;



    private Rigidbody2D _rb;
    private List<ISpeedModifier> _speedModifiers = new List<ISpeedModifier>();
    private PlayerRotation _playerRotation;
    private InputSystem_Actions _inputActions;

    [Inject]
    public void Construct(InputSystem_Actions inputActions)
    {
        _inputActions = inputActions;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    
        _playerRotation = new PlayerRotation(_inputActions, transform, _rotationSpeed);

        _speedModifiers.Add(new AirplanePower(_speed, _inputActions, transform));
        _speedModifiers.Add(new AirplaneBrake(_brakeFactor, _inputActions, transform));
        //_speedModifiers.Add(new RedirectRight(0.12f,transform));
        _speedModifiers.Add(new Graviry(_gravityScale));
        _speedModifiers.Add(new Wind(_windPower, _windDirection));
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
