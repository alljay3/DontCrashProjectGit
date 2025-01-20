using UnityEngine;

namespace Assets.Scripts.Plane.Movement
{
    public class Wind : ISpeedModifier
    {
        private float _windPower;
        private Vector3 _windDirection;

        public Wind(float windPower, Vector3 windDirection)
        {
            _windPower = windPower;
            _windDirection = windDirection;
        }

        public Vector3 Apply(Vector3 velocity, float deltaTime)
        {
            float targetMovementByWind = Vector3.Dot(velocity, _windDirection.normalized);
            if(targetMovementByWind >= _windPower)
            {
                return velocity;
            }
            return velocity + _windPower * deltaTime * _windDirection;
        }
    }
}
