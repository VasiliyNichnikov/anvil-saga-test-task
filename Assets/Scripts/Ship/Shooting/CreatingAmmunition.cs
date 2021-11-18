using System;
using UnityEngine;

namespace Ship.Shooting
{
    public class CreatingAmmunition : MonoBehaviour
    {
        public Ammunition.Ammunition Get(Transform departurePoint, GameObject prefab)
        {
            if (prefab.GetComponent<Ammunition.Ammunition>() == null)
                throw new Exception("The object has no component Ammunition");
            GameObject newAmmunition = Instantiate(prefab, departurePoint.position, Quaternion.identity);
            newAmmunition.transform.SetParent(transform);
            return newAmmunition.GetComponent<Ammunition.Ammunition>();
        }
    }
}