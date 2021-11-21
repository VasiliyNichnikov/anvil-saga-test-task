using UnityEngine;

namespace Player
{
    public class ConnectionPoints : MonoBehaviour
    {
        [SerializeField] private Vector3[] _points;

        public Vector3[] Points => _points;
    }
}