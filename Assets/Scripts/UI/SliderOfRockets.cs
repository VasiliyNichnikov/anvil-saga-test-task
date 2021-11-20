using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SliderOfRockets : MonoBehaviour
    {
        [SerializeField] private RocketUpdateTimer _timer;
        private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
        }
        
        private void Update()
        {
            _slider.value = _timer.SecondsFloat;
        }
    }
}
