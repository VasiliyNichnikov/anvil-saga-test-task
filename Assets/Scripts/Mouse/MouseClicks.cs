using Camera;
using Ship.Shooting;
using UnityEngine;

namespace Mouse
{
    public class MouseClicks : MonoBehaviour
    {
        [SerializeField] private InteractionWithScreen _screen;
        [SerializeField] private ShootingToUp _gunPlayer;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _screen.ChangeMousePosition();
            }

            if (Input.GetMouseButtonDown(1))
            {
                _gunPlayer.Shot();
            }
        }
    }
}