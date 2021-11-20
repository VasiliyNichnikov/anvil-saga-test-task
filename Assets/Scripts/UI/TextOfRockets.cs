using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Texts
{
    [RequireComponent(typeof(Text))]
    public class TextOfRockets : MonoBehaviour
    {
        private Text _rockets;

        private void Start()
        {
            _rockets = GetComponent<Text>();
        }

        private void OnEnable()
        {
            EventTextRockets.EventUpdateRockets += UpdateNumberRockets;
        }

        private void OnDisable()
        {
            EventTextRockets.EventUpdateRockets -= UpdateNumberRockets;
        }

        private void UpdateNumberRockets(int numberRockets)
        {
            _rockets.text = numberRockets.ToString();
        }
    }
}