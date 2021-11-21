using Camera;
using Events;
using Ship;
using Ship.Movement;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MovingToPoint))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private ShipParameters _parameters;
        [SerializeField] private CreationTrace _creationTrace;
        [SerializeField] private DeterminingMousePosition _determinant;

        [SerializeField] [Range(1, 300)] private float _moveSpeed;
        [SerializeField] [Range(0.001f, 0.2f)] private float _turnSpeed;

        private Vector3 _movementPosition;
        private MovingToPoint _engine;
        private Transform _thisTransform;

        public float TimeToPoint => Vector3.Distance(_movementPosition, _thisTransform.position);

        public Vector3 MovementPosition => _movementPosition;


        public void Start()
        {
            _engine = GetComponent<MovingToPoint>();
            _thisTransform = transform;
        }

        public void Moving()
        {
            if (Input.GetMouseButton(0))
            {
                MovingToNewPosition();
                _creationTrace.ChangeState(true);
                EventsMouse.OnChangeMousePosition();
            }
            else
            {
                _creationTrace.ChangeState(false);
            }
        }

        private void MovingToNewPosition()
        {
            _movementPosition = _determinant.GetCorrectMousePosition(Input.mousePosition);

            _engine.CalculationToPoint(_movementPosition, _moveSpeed, _turnSpeed);
            if (_engine.TargetDistance - _parameters.Extents.y >= 0)
                _engine.Move();
        }

        private void OnDrawGizmos()
        {
            if (_engine == null || _thisTransform == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(new Vector3(_engine.TargetPosition.x, _engine.TargetPosition.y, 0), 0.2f);

            Gizmos.color = Color.black;
            Gizmos.DrawSphere(new Vector3(_thisTransform.position.x, _thisTransform.position.y, 0), 0.2f);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector3(_engine.TargetPosition.x, _engine.TargetPosition.y, 0),
                new Vector3(_thisTransform.position.x, _thisTransform.position.y, 0));
        }
    }
}