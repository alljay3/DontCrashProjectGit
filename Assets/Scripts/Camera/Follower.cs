using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);
    [SerializeField] private float _smoothing = 3f;

    protected void Move(float deltaTime)
    {
        var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offset, _smoothing * deltaTime);

        transform.position = nextPosition;
    }
}
