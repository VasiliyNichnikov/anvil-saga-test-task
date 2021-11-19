using Ship;
using Ship.Movement;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MovingToPoint))]
    public class PlayerEngine : MonoBehaviour
    {
        [SerializeField] private ShipParameters _parameters;
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

        public void Move(Vector3 pointOfMovement)
        {
            _engine.CalculationToPoint(pointOfMovement);
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