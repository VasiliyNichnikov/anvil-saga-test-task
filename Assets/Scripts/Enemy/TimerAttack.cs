using UnityEngine;

namespace Enemy
{
    public class TimerAttack : MonoBehaviour
    {
        [HideInInspector] public bool Recharged;
        [SerializeField] private float _timeDelay = 5;
        private float _timeRemaining;


        private void Start()
        {
            _timeRemaining = _timeDelay;
        }

        private void Update()
        {
            Count();
        }

        private void Count()
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                Recharged = true;
                _timeRemaining = _timeDelay;
            }
        }
    }
}