using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathPoint))]
[CanEditMultipleObjects]
public class PathPointEditor : Editor
{
    private PathPoint pathPoint;
    private PathFindingManager pathFinder;

    void Awake()
    {
        pathPoint = (PathPoint)target;
        pathFinder = pathPoint.transform.parent.gameObject.GetComponent<PathFindingManager>();
    }

    void OnDestroy()
    {
        //pathFinder.RemovePathPoint(pathPoint.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Connect"))
        {
            GameObject[] points = Selection.gameObjects;
            if (points.Length == 2 && points[0].GetComponent<PathPoint>() != null && points[1].GetComponent<PathPoint>() != null)
            {
                pathFinder.ConnectPathPoints(points[0], points[1]);
            }
        }
    }
}
