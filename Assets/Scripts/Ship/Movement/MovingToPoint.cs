using UnityEngine;

namespace Ship.Movement
{
    public class MovingToPoint : MonoBehaviour
    {
        private Vector3 _targetPosition;
        private float _targetDistance;

        private float _constantMoveSpeed;
        private float _constantTurnSpeed;

        private Transform _thisTransform;
        private Rigidbody2D _rb2d;

        public Vector3 TargetPosition => _targetPosition;
        public float TargetDistance => _targetDistance;

        public void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _thisTransform = transform;
        }

        public void CalculationToPoint(Vector3 pointOfMovement, float moveSpeed=1f, float turnSpeed=1f)
        {
            _constantMoveSpeed = moveSpeed;
            _constantTurnSpeed = turnSpeed;
            
            _targetPosition = pointOfMovement;
            _targetDistance = Vector3.Distance(_thisTransform.position, pointOfMovement);
        }
        
        public void Move()
        {
            float turnSpeed = _constantTurnSpeed * _targetDistance;
            float moveSpeed = _constantMoveSpeed * _targetDistance;

            _rb2d.AddForce(_thisTransform.up * moveSpeed * Time.deltaTime);
            Quaternion newRotation =
                Quaternion.LookRotation(_thisTransform.position - _targetPosition, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            _thisTransform.rotation =
                Quaternion.Slerp(_thisTransform.rotation, newRotation, Time.deltaTime * turnSpeed);
        }
    }
}