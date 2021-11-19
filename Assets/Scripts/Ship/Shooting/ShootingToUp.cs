using UnityEngine;

namespace Ship.Shooting
{
    public class ShootingToUp : MonoBehaviour
    {
        [SerializeField] private CreatingAmmunition _creatingAmmunition;
        [SerializeField] private GameObject _rocketPrefab;
        [SerializeField] private ShipParent _ship;
        
        [SerializeField] private Transform _firingPoint;
        [SerializeField] private Transform _departurePoint;


        public void Shot()
        {
            Vector3 shootDirection = _firingPoint.position - _departurePoint.position;
            var rocket = _creatingAmmunition.Get(_departurePoint, _rocketPrefab);
            rocket.SetParent(_ship);
            rocket.FlightForward(shootDirection);
        }
    }
}