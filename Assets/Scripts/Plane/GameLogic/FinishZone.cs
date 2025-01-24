using UnityEngine;
using Zenject;

public class FinishZone : MonoBehaviour
{

    [SerializeField] private float _stopSpeed = 5f;
    [SerializeField] private float _maxAngle = 5f;
    private Player _playerInZone = null;
    private Level _level;

    [Inject]
    public void Construct(Level level)
    {
        _level = level;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        Player player = gameObject.GetComponent<Player>();
        if (player != null)
        {
            _playerInZone = player; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        Player player = gameObject.GetComponent<Player>();
        if (player != null)
        {
            _playerInZone = null ;
        }
    }

    private void Update()
    {
        if (_playerInZone == null) return;
        if (_playerInZone.Speed() > _stopSpeed) return;
        if (!_playerInZone.IsGrounded()) return;

        float angle = Vector3.SignedAngle(_playerInZone.transform.right, transform.right, Vector3.forward);
        //Debug.Log(angle);
        if (Mathf.Abs(angle) > _maxAngle) return;

        if (_level.CurrentLevelState != Level.LevelState.Playing) return;
        
        _level.FinishLevel();
    }
}
