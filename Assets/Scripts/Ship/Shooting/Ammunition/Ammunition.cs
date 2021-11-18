using UnityEngine;

namespace Ship.Shooting.Ammunition
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Ammunition : MonoBehaviour
    {
        public float Speed;

        protected Rigidbody2D Rb2d;
        protected Transform ThisTransform;

        public virtual void Awake()
        {
            ThisTransform = transform;
            Rb2d = GetComponent<Rigidbody2D>();
        }

        public abstract void FlightLeft(Vector3 positionEnd);
        public abstract void FlightRight(Vector3 positionEnd);
        public abstract void FlightUp(Vector3 positionEnd);
    }
}