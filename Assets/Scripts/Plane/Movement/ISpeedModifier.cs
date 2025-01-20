using UnityEngine;

public interface ISpeedModifier
{
    public Vector3 Apply(Vector3 velocity, float time);
}
