using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PathEdge))]
public class PathEdgeEditor : Editor
{
    //private PathEdge pathEdge;
    //private PathFindingManager pathFinder;

    void Awake()
    {
        //pathEdge = (PathEdge)target;
        //pathFinder = GameObject.Find("PathFinder").GetComponent<PathFindingManager>();
    }

    void OnDestroy()
    {
        //pathFinder.RemovePathPoint(pathPoint.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        // 1. update the dirty data
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}