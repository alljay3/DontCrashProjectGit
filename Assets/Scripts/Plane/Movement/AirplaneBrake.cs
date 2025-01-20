using UnityEngine;

namespace Assets.Scripts.Plane.Movement
{
    public class AirplaneBrake : ISpeedModifier
    {
        private float _brakeFactor;
        private InputSystem_Actions _inputActions;
        private Transform _targetTransform;

        public AirplaneBrake(float accelerationFactor, InputSystem_Actions inputActions, Transform targetTransform)
        {
            _brakeFactor = accelerationFactor;
            _inputActions = inputActions;
            _targetTransform = targetTransform;
        }

        public Vector3 Apply(Vector3 velocity, float deltaTime)
        {
            float playerInput = _inputActions.Player.Move.ReadValue<Vector2>().y;
            if (playerInput > 0)
            {
                return velocity;
            }
            float speedAlongRight = Vector3.Dot(velocity, _targetTransform.right.normalized);
            if (speedAlongRight < 0)
            {
                return velocity;
            }

            Vector3 velocityChange = playerInput * speedAlongRight * deltaTime * _brakeFactor * _targetTransform.right;
            return velocity + velocityChange;
        }
    }
}
