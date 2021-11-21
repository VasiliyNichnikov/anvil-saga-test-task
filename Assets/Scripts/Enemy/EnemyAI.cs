using BezierAlgorithms;
using Events;
using Player;
using Ship.Movement;
using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        // [SerializeField] private float _duration;
        [SerializeField] private float _speed;
        // [SerializeField] private Transform _forwardPoint;

        // [SerializeField] private BezierCurve _curve;
        private PlayerMovement _playerMovement;
        private MovingToPoint _engine;
        private Transform _thisTransform;

        private Vector3 _nearestPoint;

        // private Vector3[] _points;
        // private int _testIndex;

        private void OnEnable()
        {
            EventsMouse.EventChangeMousePosition += RecalculationOfPoints;
        }

        private void OnDisable()
        {
            EventsMouse.EventChangeMousePosition -= RecalculationOfPoints;
        }

        private void Start()
        {
            _thisTransform = transform;
            _engine = GetComponent<MovingToPoint>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _engine.ConstantTurnSpeed = 0.15f;
            _engine.ConstantMoveSpeed = _speed;

            // _points = CalculatePoints();
            // _testIndex = 1;
        }

        // private float _progress;

        private void Update()
        {
            _engine.CalculationToPoint(_nearestPoint);
            _engine.Move();
            // if (_engine.TargetDistance < 2f && _testIndex < 3)
            // {
            //     _testIndex++;
            //     // print("Test index: " + _testIndex);
            // }
        }

        private void RecalculationOfPoints()
        {
            CalculateNearestPoint();
            // print(Vector3.Distance(_playerMovement.transform.position, _thisTransform.position));
            // float distance = Vector3.Distance(_playerMovement.transform.position, _thisTransform.position);
            // if(_testIndex == 3 || distance < 5)
            // {
            //     _points = CalculatePoints();
            //     _testIndex = 1;
            // }
        }

        // private Vector3[] CalculatePoints()
        // {
        //     Vector3 p0 = _thisTransform.position;
        //     Vector3 pT = _playerMovement.MovementPosition;
        //
        //     Vector3 v0 = (_forwardPoint.position - p0).normalized;
        //     Vector3 vT = _playerMovement.Direction;
        //
        //     float distance0 = Vector3.Distance(p0, _playerMovement.transform.position);
        //     float distance1 = Vector3.Distance(p0, pT);
        //
        //     float time0 = _speed / distance0;
        //     float time1 = _speed / distance1;
        //
        //     Vector3 pA = p0 + (1f / 3f) * time0 * v0;
        //     Vector3 pB = pT - (1f / 3f) * time1 * vT;
        //
        //     return new[] {p0, pA, pB, pT};
        // }


        private void CalculateNearestPoint()
        {
            Vector3[] points = CalculatePoints();
            float minDistance = Mathf.Infinity;

            foreach (var point in points)
            {
                float distance = Vector3.Distance(_thisTransform.position, point);
                if (distance < minDistance)
                {
                    _nearestPoint = point;
                    minDistance = distance;
                }
            }
        }

        private Vector3[] CalculatePoints()
        {
            Vector3 centerPoint =
                new Vector3(_playerMovement.MovementPosition.x, _playerMovement.MovementPosition.y, 1);

            Vector3[] newPoints = new Vector3[_playerMovement.PointsToCapture.Length];
            float rotZ = -Quaternion.LookRotation(_playerMovement.transform.position - centerPoint, Vector3.forward)
                .eulerAngles.z;
            Quaternion rotation = Quaternion.Euler(0, 0, rotZ);

            for (int i = 0; i < _playerMovement.PointsToCapture.Length; i++)
            {
                Vector3 selectedPoint = _playerMovement.PointsToCapture[i] + centerPoint;
                Vector3 offset = centerPoint - selectedPoint;
                newPoints[i] = centerPoint - (rotation * offset);
            }

            return newPoints;
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

                Gizmos.color = Color.black;
                foreach (var point in points)
                {
                    Gizmos.DrawSphere(point, 0.2f);
                }

                Gizmos.color = Color.green;
                Gizmos.DrawSphere(_nearestPoint, 0.4f);
            }
        }
    }
}