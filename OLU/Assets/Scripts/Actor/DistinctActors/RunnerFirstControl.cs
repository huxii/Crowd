using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerFirstControl : CycleControl
{
    private PropAutoBasicControl controlPanel;
    private int activateCount = 0;
    private ElevatorControl teleA2A1;
    private GameObject teleA2;

    protected void Awake()
    {
        controlPanel = GameObject.Find("ControlPanel0").GetComponent<PropAutoBasicControl>();
        teleA2A1 = GameObject.Find("TeleA2A1").GetComponent<ElevatorControl>();
        teleA2 = GameObject.Find("TeleA2");
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

            Services.taskManager
                .Do(new ActionTask(teleA2A1.FreeAllMen))
                .Then(new Wait(0.1f))
                .Then(new ActionTask(() => teleA2.SetActive(false)));

        }
    }

    public override void Deactivate()
    {
        --activateCount;
        if (activateCount == 0)
        {
            base.Deactivate();
            CheckStairs();

            teleA2.SetActive(true);
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
