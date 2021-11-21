﻿using BezierAlgorithms;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : Editor
{
    private BezierCurve curve;
    private Transform handleTransform;
    private Quaternion handleRotation;

    private void OnSceneGUI()
    {
        curve = target as BezierCurve;
        if (curve.Points.Length != 4) return;
        
        handleTransform = curve.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
        
        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);
        Vector3 p3 = ShowPoint(3);

        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p2, p3);
        
        Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);
    }

    private Vector3 ShowPoint(int index)
    {
        Vector3 point = curve.Points[index];
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(curve, "Move Point");
            EditorUtility.SetDirty(curve);
            curve.Points[index] = point;
        }

        return point;
    }
}