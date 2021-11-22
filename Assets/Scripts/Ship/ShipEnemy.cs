using Ship.Shooting.Ammunition;
using UnityEngine;

namespace Ship
{
    public class ShipEnemy : ShipParent
    {
        [SerializeField] private GameObject _mainPart;

        public void OnTriggerEnter2D(Collider2D other)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                rocket.CheckDestruction(this);
                if (rocket.CheckingWhereProjectileCameFrom(this))
                    Destroy(_mainPart);
            }
        }
    }
}