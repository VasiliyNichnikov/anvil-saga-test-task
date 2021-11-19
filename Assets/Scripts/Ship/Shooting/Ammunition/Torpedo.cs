using System;
using System.Collections;
using UnityEngine;

namespace Ship.Shooting.Ammunition
{
    public class Torpedo : Ammunition
    {
        public override void FlightHorizontal(Vector3 shootDirection)
        {
            StartCoroutine(AnimationHorizontal(shootDirection));
        }

        public override void FlightForward(Vector3 shootDirection)
        {
            throw new Exception("The class does not implement this method");
        }

        private IEnumerator AnimationHorizontal(Vector3 shootDirection)
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