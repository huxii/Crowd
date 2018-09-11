using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PathFindingManager))]
public class PathFindingManagerEditor : Editor
{
    public static PathFindingManager pathFinder;

    void Awake()
    {
        pathFinder = (PathFindingManager)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        //pathFinder.test = EditorGUILayout.Toggle("haha", pathFinder.test);

        if (GUILayout.Button("Add Path Point"))
        {
            GameObject newPoint = pathFinder.AddPathPoint();
            Selection.activeGameObject = newPoint;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
