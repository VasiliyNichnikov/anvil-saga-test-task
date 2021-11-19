using System;
using Player;
using Ship.Movement;
using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] [Range(1, 300)] private float _moveSpeed;
        [SerializeField] [Range(0.001f, 0.2f)] private float _turnSpeed;

        private MovingToPoint _engine;
        private Transform _thisTransform;
        private Vector3 _pointOfMovement;

        private void Start()
        {
            _engine = GetComponent<MovingToPoint>();
            _engine.ConstantMoveSpeed = _moveSpeed;
            _engine.ConstantTurnSpeed = _turnSpeed;
            _thisTransform = transform;
        }

        private void Update()
        {
            _pointOfMovement = _player.position;
            _engine.CalculationToPoint(_pointOfMovement);
            _engine.Move();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_pointOfMovement, 0.2f);
        }
    }
}