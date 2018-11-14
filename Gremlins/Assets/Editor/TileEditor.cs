using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Tile))]
[CanEditMultipleObjects]
public class TileEditor : Editor
{
    private TileBasedPathFindingManager pathFinder;

    void OnDestroy()
    {
        //pathFinder.RemovePathPoint(pathPoint.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        pathFinder = GameObject.Find("PathFinder").GetComponent<TileBasedPathFindingManager>();

        if (GUILayout.Button("Connect"))
        {
            GameObject[] points = Selection.gameObjects;
            if (points.Length == 2 && points[0].GetComponent<Tile>() != null && points[1].GetComponent<Tile>() != null)
            {
                pathFinder.ConnectPath(points[0], points[1]);
            }
        }

        if (GUILayout.Button("Disconnect"))
        {
            GameObject[] points = Selection.gameObjects;
            if (points.Length == 2 && points[0].GetComponent<Tile>() != null && points[1].GetComponent<Tile>() != null)
            {
                pathFinder.DisconnectPath(points[0], points[1]);
            }
        }

        // 1. update the dirty data
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}

