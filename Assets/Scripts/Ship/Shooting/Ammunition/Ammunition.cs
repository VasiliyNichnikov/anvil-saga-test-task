using UnityEngine;

namespace Ship.Shooting.Ammunition
{
    public abstract class Ammunition : MonoBehaviour
    {
        public float Speed;
        
        protected Transform ThisTransform;

        public virtual void Awake()
        {
            ThisTransform = transform;
        }

        public abstract void FlightLeft(Vector3 positionEnd);
        public abstract void FlightRight(Vector3 positionEnd);
        public abstract void FlightForward(Vector3 shootDirectory);

        public void Destruction()
        {
            Destroy(this.gameObject);
        }
        
    }
}