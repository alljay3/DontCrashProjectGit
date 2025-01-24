using UnityEngine;

public class Player : MonoBehaviour
{
    private SimpleMovement _movement;
    private Rigidbody2D _rb;
    [SerializeField] private GroundCheck _groundCheck;
    private void Awake()
    {
        _movement = GetComponent<SimpleMovement>();
        _rb = GetComponent<Rigidbody2D>();
    }
    public float Speed()
    {
        return _rb.linearVelocity.magnitude;
    }
    public bool IsGrounded()
    {
        return _groundCheck.IsGrounded;
    }
}
