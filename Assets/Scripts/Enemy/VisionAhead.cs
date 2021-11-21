using UnityEngine;

namespace Enemy
{
    public class VisionAhead : MonoBehaviour
    {
        public bool ShipIsAhead { get; private set; }

        public void OnTriggerEnter2D(Collider2D other)
        {
            ShipIsAhead = other.GetComponent<ShipParent>() != null;
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            ShipIsAhead = other.GetComponent<ShipParent>() != null;
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            ShipIsAhead = false;
        }
    }
}