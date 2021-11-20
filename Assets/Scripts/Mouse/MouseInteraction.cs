using Player;
using Ship.Shooting;
using UnityEngine;

namespace Mouse
{
    public class MouseInteraction : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        private PlayerMovement _movement;
        private PlayerGun _gun;
        
        private void Start()
        {
            _movement = _player.GetComponent<PlayerMovement>();
            _gun = _player.GetComponent<PlayerGun>();
        }

        private void Update()
        {
            _movement.Moving();
            _gun.Shooting();
        }
        
    }
}