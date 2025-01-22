using UnityEngine;

public class RespawnPosition : LevelStateKeeper
{
    private Vector3 _startPosition; 
    private Quaternion _startRotation; 

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    protected override void RestoreState()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }

}
