using UnityEngine;

namespace Assets.Scripts.Plane.Movement
{
    internal class LiftForce : ISpeedModifier
    {
        private float _zeroAngleCoef;
        private float _angleCoef;
        private float _airDensity; // incorrect. Becouse air Density shoud increase by height
        private Transform _targetTransform;

        public LiftForce(float zeroAngleCoef, float angleCoef, float airDensity, Transform targetTransform)
        {
            _zeroAngleCoef = zeroAngleCoef;
            _angleCoef = angleCoef;
            _airDensity = airDensity;
            _targetTransform = targetTransform;
        }

        public Vector3 Apply(Vector3 velocity, float deltaTime)
        {

            float liftForceCoef = _zeroAngleCoef + _angleCoef * _targetTransform.rotation.z;
            float speedSquared = velocity.sqrMagnitude;

            float liftMagnitude = deltaTime * 0.5f * _airDensity * speedSquared * liftForceCoef;

            Vector3 liftDirection = _targetTransform.up;

            return velocity + liftDirection * liftMagnitude;
        }
    }
}
