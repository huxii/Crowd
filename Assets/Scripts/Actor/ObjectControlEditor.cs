using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(ObjectControl))]
public class ObjectControlEditor : Editor
{
    public static ObjectControl objectController;

    void Awake()
    {
        objectController = (ObjectControl)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Add Slot"))
        {
            GameObject newSlot = objectController.AddSlot();
            Selection.activeGameObject = newSlot;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}

[CustomEditor(typeof(ObjectDragTransformControl))]
public class ObjectDragTransformControlEditor : ObjectControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(ObjectClickControl))]
public class ObjectClickControlEditor : ObjectControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
