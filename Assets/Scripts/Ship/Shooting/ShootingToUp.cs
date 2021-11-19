using System.Collections;
using UnityEngine;

namespace Ship.Shooting
{
    public class ShootingToUp : MonoBehaviour
    {
        [SerializeField] private CreatingAmmunition _creatingAmmunition;
        [SerializeField] private BeingOnScreen _beingOnScreen;
        [SerializeField] private GameObject _rocketPrefab;

        [SerializeField] private Transform _firingPoint;
        [SerializeField] private Transform _departurePoint;


        public void Shot()
        {
            StartCoroutine(AnimationMovementRocket());
        }

        private IEnumerator AnimationMovementRocket()
        {
            Vector3 shootDirectory = _firingPoint.position - _departurePoint.position;
            var rocket = _creatingAmmunition.Get(_departurePoint, _rocketPrefab);
            
            while (_beingOnScreen.ObjectInside(rocket.transform.position))
            {
                rocket.FlightForward(shootDirectory);
                yield return null;
            }
            rocket.Destruction();
        }
        
    }
}