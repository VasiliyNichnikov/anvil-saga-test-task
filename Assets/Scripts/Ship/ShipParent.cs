using Ship.Shooting.Ammunition;
using UnityEngine;

public abstract class ShipParent : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Rocket ammunition = other.GetComponent<Rocket>();
        if (ammunition != null)
        {
            ammunition.GettingIntoSomeoneElseShip(this);
        }
    }
}