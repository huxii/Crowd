using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PathFindingManager))]
public class PathFindingManagerEditor : Editor
{
    private static PathFindingManager pathFinder;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        pathFinder = (PathFindingManager)target;

        if (GUILayout.Button("Refresh"))
        {
            pathFinder.Refresh();
        }

        if (GUILayout.Button("Add Navmesh"))
        {
            GameObject newNavmesh = pathFinder.AddNavmesh();
            Selection.activeGameObject = newNavmesh;
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

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        pathFinder = (PointBasedPathFindingManager)target;

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

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //pathFinder.test = EditorGUILayout.Toggle("haha", pathFinder.test);
        pathFinder = (TileBasedPathFindingManager)target;

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
