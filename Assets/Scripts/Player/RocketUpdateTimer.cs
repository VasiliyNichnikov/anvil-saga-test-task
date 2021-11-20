using Events;
using UnityEngine;

namespace Player
{
    public class RocketUpdateTimer : MonoBehaviour
    {
        [SerializeField] private float _timeSave = 5;

        private float _secondsFloat;
        private float _timeRemaining;

        public float SecondsFloat => _secondsFloat;

        private void Start()
        {
            _timeRemaining = _timeSave;
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
                _secondsFloat = _timeRemaining % 60;
            }
            else
            {
                EventNumberRockets.OnUpdateNumberRockets();
                _timeRemaining = _timeSave;
            }
        }
    }
}