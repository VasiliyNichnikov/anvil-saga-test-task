using System;
using UnityEngine;

namespace Ship.Shooting.Ammunition
{
    public class Rocket : Ammunition
    {
        public override void FlightLeft(Vector3 positionEnd)
        {
            throw new Exception("The class does not implement this method");
        }

        public override void FlightRight(Vector3 positionEnd)
        {
            throw new Exception("The class does not implement this method");
        }

        public override void FlightForward(Vector3 shootDirectory)
        {
            ThisTransform.position += shootDirectory * Speed * Time.deltaTime;
        }
    }
}