using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(ScrollRectControl))]
public class ScrollRectControlEditor : ScrollRectEditor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}
