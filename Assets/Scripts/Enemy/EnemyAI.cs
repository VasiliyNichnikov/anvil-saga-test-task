using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _forwardPoint;

        private PlayerMovement _playerMovement;
        private Transform _thisTransform;

        private void Start()
        {
            _thisTransform = transform;
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }

        private Vector3[] CalculatePoints()
        {
            Vector3 p0 = _thisTransform.position;
            Vector3 pT = _playerMovement.MovementPosition;

            Vector3 v0 = (_forwardPoint.position - p0).normalized;
            Vector3 vT = _playerMovement.Direction;

            float distance0 = Vector3.Distance(p0, _playerMovement.transform.position);
            float distance1 = Vector3.Distance(p0, pT);

            float time0 = _speed / distance0;
            float time1 = _speed / distance1;

            Vector3 pA = p0 + (1f / 3f) * time0 * v0;
            Vector3 pB = pT - (1f / 3f) * time1 * vT;

            return new[] {p0, pA, pB, pT};
        }

        private void OnDrawGizmos()
        {
            if (_playerMovement != null)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawSphere(_thisTransform.position, 0.2f);


                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(_playerMovement.transform.position, 0.2f);

                Vector3[] points = CalculatePoints();
                
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(points[1], 0.2f);
                
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(points[2], 0.2f);

                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[0], points[1]);
                Gizmos.DrawLine(points[1], points[2]);
                Gizmos.DrawLine(points[2], points[3]);
            }
        }
    }
}