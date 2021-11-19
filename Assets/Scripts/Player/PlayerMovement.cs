using Camera;
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

        private MovingToPoint _engine;
        private Transform _thisTransform;

        public void Start()
        {
            _engine = GetComponent<MovingToPoint>();
            _engine.ConstantMoveSpeed = _moveSpeed;
            _engine.ConstantTurnSpeed = _turnSpeed;
            _thisTransform = transform;
        }

        public void Moving()
        {
            if (Input.GetMouseButton(0))
            {
                MovingToNewPosition();
                _creationTrace.ChangeState(true);
            }
            else
            {
                _creationTrace.ChangeState(false);
            }
        }

        private void MovingToNewPosition()
        {
            Vector3 newPosition = _determinant.GetCorrectMousePosition(Input.mousePosition);

            _engine.CalculationToPoint(newPosition);
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