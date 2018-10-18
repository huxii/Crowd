using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PathFindingManager))]
public class PathFindingManagerEditor : Editor
{
    private static PathFindingManager pathFinder;

    void Awake()
    {
        pathFinder = (PathFindingManager)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Refresh"))
        {
            pathFinder.GetComponent<PathFindingManager>().Refresh();
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}

[CustomEditor(typeof(PointBasedPathFindingManager))]
public class PointBasedPathFindingManagerEditor : PathFindingManagerEditor
{
    private static PointBasedPathFindingManager pathFinder;

    void Awake()
    {
        pathFinder = (PointBasedPathFindingManager)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add Tile"))
        {
            GameObject newTile = pathFinder.AddPathPoint();
            Selection.activeGameObject = newTile;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}

[CustomEditor(typeof(TileBasedPathFindingManager))]
public class TileBasedPathFindingManagerEditor : PathFindingManagerEditor
{
    private static TileBasedPathFindingManager pathFinder;

    void Awake()
    {
        pathFinder = (TileBasedPathFindingManager)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //pathFinder.test = EditorGUILayout.Toggle("haha", pathFinder.test);

        if (GUILayout.Button("Add Tile"))
        {
            GameObject newTile = pathFinder.AddTile();
            Selection.activeGameObject = newTile;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
