using Player;
using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class InteractionWithScreen : MonoBehaviour
    {
        [SerializeField] private PlayerEngine _playerEngine;

        private UnityEngine.Camera _camera;
        private Vector3 _positionLeftBtn;

        private void Start()
        {
            _camera = GetComponent<UnityEngine.Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) == false) return;
            _positionLeftBtn = GetCorrectPositionMouse(Input.mousePosition);
            _playerEngine.Move(_positionLeftBtn);
        }

        private Vector3 GetCorrectPositionMouse(Vector3 position)
        {
            float x = position.x;
            float y = position.y;
            float z = 0.0f;

            if (x < 0)
                x = 0;
            else if (x > Screen.width)
                x = Screen.width;

            if (y < 0)
                y = 0;
            else if (y > Screen.height)
                y = Screen.height;

            Vector3 worldPositionMouse = _camera.ScreenToWorldPoint(new Vector3(x, y, z));
            worldPositionMouse.z = 0;
            return worldPositionMouse;
        }
    }
}