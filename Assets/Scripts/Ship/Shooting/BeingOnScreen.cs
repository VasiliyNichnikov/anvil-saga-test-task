using UnityEngine;

namespace Ship.Shooting
{
    public class BeingOnScreen : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;

        public bool ObjectInside(Vector3 objectPosition)
        {
            Vector3 screenObjectPosition = _camera.WorldToScreenPoint(objectPosition);
            return screenObjectPosition.x >= 0 &&
                   screenObjectPosition.x <= Screen.width &&
                   screenObjectPosition.y >= 0 &&
                   screenObjectPosition.y <= Screen.height;
        }
    }
}