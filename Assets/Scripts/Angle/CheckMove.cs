using System;
using Ship.Movement;
using UnityEngine;

namespace Angle
{
    public class CheckMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private CheckAngle _checkAngle;
        private Vector3 _selectedPoint = Vector3.zero;
        // private MovingToPoint _engine;


        private void Start()
        {
            if (_speed <= 0)
                _speed = 1;

            float timeMainShip = _checkAngle.Time;
            // _selectedPoint = _checkAngle.Points[4];
            
            
            // print(timeMainShip);

            float minTime = timeMainShip;
            
            // foreach (var point in _checkAngle.Points)
            // {
            //     float time = Vector3.Distance(transform.position, point) / _speed;
            //     if (time < minTime)
            //     {
            //         _selectedPoint = point;
            //         minTime = time;
            //     }
            // }
        }

        private void OnDrawGizmos()
        {
            if (_checkAngle != null)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(_selectedPoint, transform.position);
                Gizmos.DrawSphere(_selectedPoint, 0.2f);
            }
        }
    }
}