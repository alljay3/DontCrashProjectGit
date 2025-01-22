using System;
using UnityEngine;

namespace Assets.Scripts.Plane.Movement
{
    internal class RedirectRight : ISpeedModifier
    {
        [Range(0,1)]
        private float _coef;
        private Transform _targetTransform;

        public RedirectRight(float coef, Transform targetTransform)
        {
            _coef = coef;
            _targetTransform = targetTransform;
        }

        public Vector3 Apply(Vector3 velocity, float deltaTime)
        {
            float speed = velocity.magnitude;
            Vector3 direction = Vector3.Lerp(velocity.normalized, _targetTransform.right.normalized, _coef);
            return direction * speed;
        }
    }
}
