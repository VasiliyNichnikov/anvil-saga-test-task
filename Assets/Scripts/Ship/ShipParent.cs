using Ship.Shooting.Ammunition;
using UnityEngine;

public abstract class ShipParent : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Ammunition ammunition = other.GetComponent<Ammunition>();
        if (ammunition != null)
        {
            ammunition.GettingIntoSomeoneElseShip(this);
        }
    }
}