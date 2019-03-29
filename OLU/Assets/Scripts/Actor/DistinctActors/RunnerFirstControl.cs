using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerFirstControl : CycleControl
{
    private PropAutoBasicControl controlPanel;

    protected override void Start()
    {
        controlPanel = GameObject.Find("ControlPanel0").GetComponent<PropAutoBasicControl>();

        base.Start();
    }

    public bool IsShort()
    {
        return controlPanel.IsActivated();
    }
}
