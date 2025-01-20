using UnityEngine;

namespace Assets.Scripts.Plane.Movement
{
    public class Graviry : ISpeedModifier
    {
        private float _gravityScale = 9.8f;

        public Graviry(float gravityScale)
        {
            _gravityScale = gravityScale;
        }

        public Vector3 Apply(Vector3 velocity, float deltaTime)
        {
            return new Vector3(velocity.x, velocity.y - _gravityScale * deltaTime);
        }
    }
}
