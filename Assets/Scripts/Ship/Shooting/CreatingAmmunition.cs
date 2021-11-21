using System;
using Ship.Shooting.Ammunition;
using UnityEngine;

namespace Ship.Shooting
{
    public class CreatingAmmunition : MonoBehaviour
    {
        public Rocket Get(Transform departurePoint, GameObject prefab)
        {
            if (prefab.GetComponent<Rocket>() == null)
                throw new Exception("The object has no component Ammunition");
            GameObject newAmmunition = Instantiate(prefab, departurePoint.position, Quaternion.identity);
            newAmmunition.transform.SetParent(transform);
            return newAmmunition.GetComponent<Rocket>();
        }
    }
}