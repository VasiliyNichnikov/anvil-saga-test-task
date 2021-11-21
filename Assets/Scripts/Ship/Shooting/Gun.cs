using System;
using UnityEngine;

namespace Ship.Shooting
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject _rocketPrefab;
        [SerializeField] private ShipParent _ship;

        [SerializeField] private Side[] _sides;
        private CreatingAmmunition _creatingAmmunition;

        public void Start()
        {
            _creatingAmmunition = FindObjectOfType<CreatingAmmunition>();
        }

        public void Shooting(int index)
        {
            CheckingOutOfArrayLimits(index);
            Shot(index);
        }

        private void CheckingOutOfArrayLimits(int index)
        {
            if (index < 0 || index > _sides.Length)
            {
                throw new IndexOutOfRangeException("The entered index is not included in the array");
            }
        }

        private void Shot(int index)
        {
            Vector3 shootDirection = _sides[index].FiringPoint.position - _sides[index].DeparturePoint.position;
            var rocket = _creatingAmmunition.Get(_sides[index].DeparturePoint, _rocketPrefab);
            rocket.SetParent(_ship);
            rocket.FlightDirection(shootDirection);
        }
    }
}