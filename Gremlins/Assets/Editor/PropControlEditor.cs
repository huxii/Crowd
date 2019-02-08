using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PropControl))]
public class PropControlEditor : Editor
{
    public static PropControl propController;

    void Awake()
    {
        propController = (PropControl)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Add Slot"))
        {
            GameObject newSlot = propController.AddSlot();
            Selection.activeGameObject = newSlot;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}

[CustomEditor(typeof(PropClickControl))]
public class PropClickControlEditor : PropControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropAutoControl))]
public class PropAutoControlEditor : PropControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropAutoBasicControl))]
public class PropAutoBasicControlEditor : PropAutoControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropAutoLoopControl))]
public class PropAutoLoopControlEditor : PropAutoControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(InflatorControl))]
public class InflatorControlEditor : PropAutoLoopControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropOneTimeControl))]
public class PropOneTimeControlEditor : PropAutoControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropOneTimeBasicControl))]
public class PropOneTimeBasicControlEditor : PropOneTimeControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropOneTimeSwipeControl))]
public class PropOneTimeSwipeControlEditor : PropOneTimeControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropOneTimeDragControl))]
public class PropOneTimeDragControlEditor : PropOneTimeControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropAutoTimedDeactivateControl))]
public class PropAutoTimedDeactivateControlEditor : PropAutoControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropPassiveControl))]
public class PropPassiveControlEditor : PropControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropPassiveBasicControl))]
public class PropPassiveBasicControlEditor : PropControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropPassiveHolderControl))]
public class PropPassiveHolderControlEditor : PropPassiveControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropPassiveTimedDeactivateControl))]
public class PropPassiveTimedDeactivateControlEditor : PropPassiveControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(PropPassiveElevatorControl))]
public class PropPassiveElevatorControlEditor : PropPassiveTimedDeactivateControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(ControlPanelControl))]
public class ControlPanelControlEditor : PropPassiveControlEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}

[CustomEditor(typeof(MultiplePropControl))]
public class MultiplePropControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}