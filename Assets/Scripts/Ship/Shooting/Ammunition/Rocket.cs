using System;
using System.Collections;
using UnityEngine;

namespace Ship.Shooting.Ammunition
{
    public class Rocket : MonoBehaviour
    {
        public float Speed;
        private Transform _thisTransform;
        private BeingOnScreen _beingOnScreen;
        private ShipParent _ship;

        public void Awake()
        {
            _thisTransform = transform;
            _beingOnScreen = FindObjectOfType<BeingOnScreen>();
        }

        public void FlightDirection(Vector3 shootDirection)
        {
            StartCoroutine(AnimationMovement(shootDirection));
        }

        public void SetParent(ShipParent ship)
        {
            _ship = ship;
        }

        private IEnumerator AnimationMovement(Vector3 shootDirection)
        {
            while (_beingOnScreen.ObjectInside(_thisTransform.position))
            {
                _thisTransform.position += shootDirection * Speed * Time.deltaTime;
                yield return null;
            }

            Destruction();
        }

        public bool CheckingWhereProjectileCameFrom(ShipParent other)
        {
            return _ship != other;
        }

        public void CheckDestruction(ShipParent other)
        {
            if (_ship != other)
            {
                Destruction();
            }
        }

        private void Destruction()
        {
            Destroy(this.gameObject);
        }
    }
}