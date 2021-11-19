using UnityEngine;

namespace Ship
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ShipParameters : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private Vector3 _extents;
        
        public Vector3 Extents => _extents;


        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _extents = _renderer.bounds.extents;
        }
    }
}