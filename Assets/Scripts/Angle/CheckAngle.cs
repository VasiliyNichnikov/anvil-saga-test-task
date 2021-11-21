using UnityEngine;

namespace Angle
{
    public class CheckAngle : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _pointEnd;
        [SerializeField] private Vector3[] _points;
        // private Vector3[] _newPoints;

        public float Time
        {
            get
            {
                if (_speed > 0)
                    return DistanceBetweenPointEndAndThisShip / _speed;
                return 0;
            }
        }

        public float DistanceBetweenPointEndAndThisShip => Vector3.Distance(transform.position, _pointEnd.position);
        // public Vector3[] Points => _newPoints;
        public Transform PointEnd => _pointEnd;

        private void Awake()
        {
            // _newPoints = new Vector3[_points.Length];
            CalculatePoints();
        }

        private Vector3[] CalculatePoints()
        {
            Vector3[] newPoints = new Vector3[_points.Length];
            Vector3 centerPoint = _pointEnd.position;
            
            float rotZ = Quaternion.LookRotation(transform.position - _pointEnd.position, Vector3.forward)
                .eulerAngles.z;
            Quaternion rotation = Quaternion.Euler(0, 0, rotZ);
            
            for (int i = 0; i < _points.Length; i++)
            {
                Vector3 selectedPoint = _points[i] + centerPoint;
                Vector3 offset = centerPoint - selectedPoint;
                // float rotZ = transform.rotation.eulerAngles.z;
                // float rotZ = 90;
                newPoints[i] = centerPoint - (rotation * offset);
            }

            return newPoints;
        }

        private void OnDrawGizmos()
        {
            // if (_newPoints == null) return;

            Gizmos.color = Color.black;
            CalculatePoints();
            foreach (var point in CalculatePoints())
            {
                // float angleRadian = transform.rotation.eulerAngles.z * Mathf.PI / 180;
                // float newY = selectedPoint.y * Mathf.Cos(angleRadian) - selectedPoint.x * Mathf.Sin(angleRadian);
                // float newX = selectedPoint.y * Mathf.Sin(angleRadian) + selectedPoint.x * Mathf.Cos(angleRadian);
                // Vector3 newPoint = new Vector3(newX, newY, selectedPoint.z);
                Gizmos.DrawSphere(point, 0.2f);
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_pointEnd.position, 0.5f);
        }
    }
}