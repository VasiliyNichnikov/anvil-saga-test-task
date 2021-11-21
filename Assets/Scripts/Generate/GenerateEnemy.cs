using UnityEngine;

namespace Generate
{
    public class GenerateEnemy : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;
        [SerializeField] private float _min;
        [SerializeField] private float _max;
        [SerializeField] private GameObject _enemy;

        private float _timeDelay;
        private float _timeRemaining;


        private void Start()
        {
            _timeDelay = Random.Range(_min, _max);
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
                CreateShip();
                _timeDelay = Random.Range(_min, _max);
                _timeRemaining = _timeDelay;
            }
        }

        private void CreateShip()
        {
            GameObject newShip = Instantiate(_enemy, transform, false);
            newShip.transform.position = GetPositionShip();
        }

        private Vector3 GetPositionShip()
        {
            float x0 = Screen.width + Random.Range(20, 30);
            float y0 = Screen.height + Random.Range(20, 30);

            float x1 = 0 - Random.Range(20, 30);
            float y1 = 0 - Random.Range(20, 30);

            float selectX = Random.Range(0f, 1f);
            float selectY = Random.Range(0f, 1f);
            
            float x = selectX > 0.5f ? x1 : x0;
            float y = selectY > 0.5f ? y1 : y0;
            Vector3 result = _camera.ScreenToWorldPoint(new Vector3(x, y, 0));
            return new Vector3(result.x, result.y, 0);
        }
    }
}