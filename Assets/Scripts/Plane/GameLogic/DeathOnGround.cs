using UnityEngine;
using Zenject;

public class DeathOnGround : MonoBehaviour
{
    private Level _level;
    [Inject]
    public void Construct(Level level)
    {
        _level = level;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null) {
            _level.GameOver();
        }
    }
}
