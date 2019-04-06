using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerFirstControl : CycleControl
{
    private PropAutoBasicControl controlPanel;
    private int activateCount = 0;

    protected void Awake()
    {
        controlPanel = GameObject.Find("ControlPanel0").GetComponent<PropAutoBasicControl>();
    }

    private void CheckStairs()
    {
        if (curAbsCycle == 1 && IsActivated())
        {
            Services.gameEvents.ConnectPath("Tile34, Tile33");
        }
        else
        {
            Services.gameEvents.DisconnectPath("Tile34, Tile33");
        }
    }

    public override void Activate()
    {
        ++activateCount;
        if (activateCount == 1)
        {
            base.Activate();
            CheckStairs();
        }
    }

    public override void Deactivate()
    {
        --activateCount;
        if (activateCount == 0)
        {
            base.Deactivate();
            CheckStairs();
        }
    }

    public override void GoClockwise()
    {
        base.GoClockwise();

        CheckStairs();
    }

    public override void GoCounterClockwise()
    {
        base.GoCounterClockwise();

        CheckStairs();
    }
}
