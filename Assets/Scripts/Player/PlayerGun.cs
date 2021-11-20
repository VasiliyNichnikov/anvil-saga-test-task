using Events;
using Ship.Shooting;
using UnityEngine;

namespace Player
{
    public class PlayerGun : MonoBehaviour
    {
        private int _numberOfRockets;
        private Gun _gun;

        public void OnEnable()
        {
            EventNumberRockets.EventUpdateNumberRockets += UpdateNumberRockets;
        }

        public void OnDisable()
        {
            EventNumberRockets.EventUpdateNumberRockets -= UpdateNumberRockets;
        }

        public void Start()
        {
            _gun = GetComponent<Gun>();
            _numberOfRockets = 1;
            EventTextRockets.OnUpdateRockets(_numberOfRockets);
        }

        public void Shooting()
        {
            if (ThereAreRockets() == false || Input.GetMouseButtonDown(1) == false) return;
            UpdateNumberRockets(true);
            _gun.Shooting(0);
        }

        private bool ThereAreRockets()
        {
            return _numberOfRockets - 1 >= 0;
        }

        private void UpdateNumberRockets(bool subtract)
        {
            if (subtract)
                _numberOfRockets -= 1;
            else
                _numberOfRockets += 1;
            EventTextRockets.OnUpdateRockets(_numberOfRockets);
        }
    }
}