using System.Collections;
using UnityEngine;

namespace Ship.Shooting
{
    public class ShootingToUp : MonoBehaviour
    {
        [SerializeField] private CreatingAmmunition _creatingAmmunition;
        [SerializeField] private GameObject _rocketPrefab;

        [SerializeField] private Transform _firingPoint;
        [SerializeField] private Transform _departurePoint;


        public void Shot()
        {
            Vector3 positionEnd = _firingPoint.position;
            var rocket = _creatingAmmunition.Get(_departurePoint, _rocketPrefab);
            rocket.FlightUp(positionEnd);
            // StartCoroutine(AnimationMovementRocket());
        }

        private IEnumerator AnimationMovementRocket()
        {
            Vector3 positionEnd = _firingPoint.position;
            var rocket = _creatingAmmunition.Get(_departurePoint, _rocketPrefab);
            float distance = Vector3.Distance(positionEnd, rocket.transform.position);
            
            while (distance > 0.1f)
            {
                rocket.FlightUp(positionEnd);
                yield return null;
                distance = Vector3.Distance(positionEnd, rocket.transform.position);
            }
        }
        
    }
}