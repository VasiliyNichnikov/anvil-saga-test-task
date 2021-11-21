using Ship.Shooting.Ammunition;
using UnityEngine;

namespace Ship
{
    public class ShipPlayer : ShipParent
    {
        [SerializeField] private GameObject _gameOverPanel;

        private void Start()
        {
            _gameOverPanel.SetActive(false);
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                rocket.CheckRemoveDestruction(this);
                if(rocket.CheckingWhereProjectileCameFrom(this))
                    ActiveGameOverPanel();
            }
        }

        private void ActiveGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }
    }
}