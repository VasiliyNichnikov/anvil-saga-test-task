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
            if (Input.GetMouseButton(0))
            {
                _positionLeftBtn = _camera.ScreenToWorldPoint(Input.mousePosition);
                _positionLeftBtn.z = 0;
                _playerEngine.Move(_positionLeftBtn);
            }
        }
    }
}