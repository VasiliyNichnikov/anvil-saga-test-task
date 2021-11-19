using System;
using System.Collections;
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

        public override void FlightForward(Vector3 shootDirection)
        {
            StartCoroutine(AnimationMovement(shootDirection));
        }
        
        private IEnumerator AnimationMovement(Vector3 shootDirection)
        {
            while (BeingOnScreen.ObjectInside(ThisTransform.position))
            {
                ThisTransform.position += shootDirection * Speed * Time.deltaTime;
                yield return null;
            }
            Destruction();
        }
        
    }
}