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
}

[CustomEditor(typeof(ObjectPrimaryControl))]
public class ObjectPrimaryControlEditor : ObjectControlEditor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Add Slot"))
        {
            GameObject newSlot = ((ObjectPrimaryControl)objectController).AddSlot();
            Selection.activeGameObject = newSlot;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}

[CustomEditor(typeof(ObjectClickControl))]
public class ObjectClickControlEditor : ObjectPrimaryControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(ObjectAutoControl))]
public class ObjectAutoControlEditor : ObjectPrimaryControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(ObjectDragControl))]
public class ObjectDragControlEditor : ObjectPrimaryControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(ObjectDragTransformControl))]
public class ObjectDragTransformControlEditor : ObjectDragControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(ObjectDragRotationControl))]
public class ObjectDragRotationControlEditor : ObjectDragControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(ObjectSecondaryControl))]
public class ObjectSecondaryControlEditor : ObjectControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}