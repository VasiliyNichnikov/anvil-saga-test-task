using UnityEngine;

namespace Ship.Shooting.Ammunition
{
    public abstract class Ammunition : MonoBehaviour
    {
        public float Speed;
        
        protected Transform ThisTransform;
        protected BeingOnScreen BeingOnScreen;
        private ShipParent _ship;
        
        public virtual void Awake()
        {
            ThisTransform = transform;
            BeingOnScreen = FindObjectOfType<BeingOnScreen>();
        }

        public abstract void FlightLeft(Vector3 positionEnd);
        public abstract void FlightRight(Vector3 positionEnd);
        public abstract void FlightForward(Vector3 shootDirection);

        public void SetParent(ShipParent ship)
        {
            _ship = ship;
        }

        public void GettingIntoSomeoneElseShip(ShipParent other)
        {
            if (_ship != other)
            {
                Destruction();
            }
        }
        
        protected void Destruction()
        {
            Destroy(this.gameObject);
        }
    }
}