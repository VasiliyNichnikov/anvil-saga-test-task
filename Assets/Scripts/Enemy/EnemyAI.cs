using Events;
using Player;
using Ship.Movement;
using Ship.Shooting;
using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private VisionAhead visionAhead;
        [SerializeField] private VisionGun _visionGun;
        private ConnectionPoints _connectionPoints;
        private TimerAttack _timer;
        private Gun _gun;
        private PlayerMovement _playerMovement;
        private MovingToPoint _engine;
        private Transform _thisTransform;
        private Vector3 _nearestPoint;

        private void OnEnable()
        {
            EventsMouse.EventChangeMousePosition += RecalculationOfPoints;
        }

        private void OnDisable()
        {
            EventsMouse.EventChangeMousePosition -= RecalculationOfPoints;
        }

        private void Awake()
        {
            _thisTransform = transform;
            _engine = GetComponent<MovingToPoint>();
            _gun = GetComponent<Gun>();
            _timer = GetComponent<TimerAttack>();
            _connectionPoints = FindObjectOfType<ConnectionPoints>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }

        private void Update()
        {
            _engine.CalculationToPoint(_nearestPoint, _speed, 0.25f);
            if (visionAhead.ShipIsAhead == false)
            {
                _engine.Move();
            }

            if (_timer.Recharged)
            {
                if (_visionGun.GetSide() == SideGun.None) return;
                _gun.Shooting(_visionGun.GetSide() == SideGun.Left ? 0 : 1);
                _timer.Recharged = false;
            }
        }

        private void RecalculationOfPoints()
        {
            CalculateNearestPoint();
        }

        private void CalculateNearestPoint()
        {
            Vector3[] points = CalculatePoints();
            float minTime = _playerMovement.TimeToPoint;

            foreach (var point in points)
            {
                float distance = Vector3.Distance(_thisTransform.position, point);
                float time = distance / _speed;
                if (time < minTime)
                {
                    _nearestPoint = point;
                    minTime = time;
                }
            }
        }

        private Vector3[] CalculatePoints()
        {
            Vector3 centerPoint =
                new Vector3(_playerMovement.MovementPosition.x, _playerMovement.MovementPosition.y, 1);

            Vector3[] newPoints = new Vector3[_connectionPoints.Points.Length];
            float rotZ = -Quaternion.LookRotation(_playerMovement.transform.position - centerPoint, Vector3.forward)
                .eulerAngles.z;
            Quaternion rotation = Quaternion.Euler(0, 0, rotZ);

            for (int i = 0; i < _connectionPoints.Points.Length; i++)
            {
                Vector3 selectedPoint = _connectionPoints.Points[i] + centerPoint;
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