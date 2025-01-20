using UnityEngine;

namespace Assets.Scripts.Plane.Movement
{
    public class GravirySpeedModifier : ISpeedModifier
    {
        private float _gravityScale = 9.8f;

        public GravirySpeedModifier(float gravityScale)
        {
            _gravityScale = gravityScale;
        }

        public Vector3 Apply(Vector3 velocity, float time)
        {
            return new Vector3(velocity.x, velocity.y - _gravityScale * time);
        }
    }
}
