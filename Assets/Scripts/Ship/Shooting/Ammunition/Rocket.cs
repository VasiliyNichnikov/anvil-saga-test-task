using System;
using UnityEngine;

namespace Ship.Shooting.Ammunition
{
    public class Rocket : Ammunition
    {
        private Vector3 _bulletRight;

        public override void Awake()
        {
            base.Awake();
            _bulletRight = Vector3.right;
        }

        public override void FlightLeft(Vector3 positionEnd)
        {
            throw new Exception("The class does not implement this method");
        }

        public override void FlightRight(Vector3 positionEnd)
        {
            throw new Exception("The class does not implement this method");
        }

        public override void FlightUp(Vector3 positionEnd)
        {
            Rb2d.AddRelativeForce(Vector2.right * 20);
            
            // Vector3 different = positionEnd - ThisTransform.position;
            //
            // float t = 0.5f / Vector3.Distance(ThisTransform.position, positionEnd);
            // _bulletRight = Vector3.Slerp(_bulletRight, different, t);
            // ThisTransform.position += _bulletRight * Speed * Time.deltaTime;
        }
    }
}