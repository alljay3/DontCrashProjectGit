using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int _groundedCounter = 0; 
    public bool IsGrounded
    {
        get { return _groundedCounter > 0; } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            _groundedCounter++; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            _groundedCounter--; 
        }
    }
}
