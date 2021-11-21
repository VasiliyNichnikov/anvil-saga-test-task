using Ship;
using UnityEngine;

namespace Enemy
{
    public class VisionGunSideRightOrLeft : MonoBehaviour
    {
        private bool _canShoot;
        public bool CanShoot => _canShoot;

        public void OnTriggerEnter2D(Collider2D other)
        {
            _canShoot = other.GetComponent<ShipPlayer>() != null;
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            _canShoot = other.GetComponent<ShipPlayer>() != null;
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            _canShoot = false;
        }
    }
}