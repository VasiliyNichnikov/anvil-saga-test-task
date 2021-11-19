using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class DeterminingMousePosition : MonoBehaviour
    {
        private UnityEngine.Camera _camera;

        public void Start()
        {
            _camera = GetComponent<UnityEngine.Camera>();
        }

        public Vector3 GetCorrectMousePosition(Vector3 position)
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