using UnityEngine;
using Zenject;

public class DeathOnKillZone : MonoBehaviour
{
    private Level _level;
    [Inject]
    public void Construct(Level level)
    {
        _level = level;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<KillObject>() != null) {
            _level.GameOver();
        }
    }
}
