using System;
using UnityEngine;

namespace BezierAlgorithms
{
    public class BezierCurve : MonoBehaviour
    {
        private Vector3[] _points;

        public Vector3[] Points
        {
            get => _points;
            set
            {
                CheckNumberPoints(value);
                _points = value;
            }
        }
        
        public Vector3 GetPoint(float t)
        {
            return Bezier.GetPoint(_points[0], _points[1], _points[2], _points[3], t);
        }

        public Vector3 GetVelocity(float t)
        {
            return Bezier.GetFirstDerivative(_points[0], _points[1], _points[2], _points[3], t) - transform.position;
        }

        public Vector3 GetDirection(float t)
        {
            return GetVelocity(t).normalized;
        }

        private void CheckNumberPoints(Vector3[] points)
        {
            if (points.Length != 4)
                throw new Exception("The number of points should be equal to 4");
        }
    }
}