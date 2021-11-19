using System;
using UnityEngine;

namespace Ship.Shooting
{
    [Serializable]
    public class Side
    {
        [SerializeField] private string _name;
        [SerializeField] private Transform _firingPoint;
        [SerializeField] private Transform _departurePoint;
    
        public Transform FiringPoint => _firingPoint;
        public Transform DeparturePoint => _departurePoint;
    }
}