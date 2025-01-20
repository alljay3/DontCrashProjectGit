using Assets.Scripts.Plane.Movement;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _gravityScale = 9.8f;
    [SerializeField] private float _speed = 10;

    private Rigidbody2D _rb;
    private List<ISpeedModifier> _speedModifiers = new List<ISpeedModifier>();
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _speedModifiers.Add(new GravirySpeedModifier(_gravityScale));
    }

    private void FixedUpdate()
    {
        foreach (var speedModifier in _speedModifiers)
        {
            _rb.linearVelocity = speedModifier.Apply(_rb.linearVelocity, Time.fixedDeltaTime);
        }
        Debug.Log(_rb.linearVelocity);
    }


}
