using UnityEngine;

namespace Assets.Scripts.Plane.Movement
{
    internal class AirplanePower : ISpeedModifier
    {
        private float _accelerationFactor;
        private InputSystem_Actions _inputActions;
        private Transform _targetTransform;

        public AirplanePower(float accelerationFactor, InputSystem_Actions inputActions, Transform targetTransform)
        {
            _accelerationFactor = accelerationFactor;
            _inputActions = inputActions;
            _targetTransform = targetTransform;
        }

        public Vector3 Apply(Vector3 velocity, float deltaTime)
        {
            float playerInput = _inputActions.Player.Move.ReadValue<Vector2>().y;
            if (playerInput < 0)
            {
                return velocity;
            }

            Vector3 velocityChange = playerInput * deltaTime * _accelerationFactor * _targetTransform.right;
            return velocity + velocityChange;
        }
    }
}
