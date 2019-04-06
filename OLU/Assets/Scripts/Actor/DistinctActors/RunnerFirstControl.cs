using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerFirstControl : CycleControl
{
    private PropAutoBasicControl controlPanel;

    protected void Awake()
    {
        controlPanel = GameObject.Find("ControlPanel0").GetComponent<PropAutoBasicControl>();
    }

    public bool IsShort()
    {
        return controlPanel.IsActivated();
    }
}
