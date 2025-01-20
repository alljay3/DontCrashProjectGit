using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Plane.Movement
{
    internal class PlanePowerSpeedModifier : ISpeedModifier
    {
        private float _speed;
        private PlayerInput input;
        public Vector3 Apply(Vector3 velocity, float time)
        {
            throw new NotImplementedException();
        }
    }
}
