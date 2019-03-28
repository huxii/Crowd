using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControl : ObjectControl
{
    [Header("Runner Settings")]
    public CycleControl floor1;
    public CycleControl floor2;
    public CycleControl floor3;
    public ElevatorControl teleA0;
    public ElevatorControl teleA1;
    public ElevatorControl teleB0;
    public ElevatorControl teleB1;
    public ElevatorControl teleB2;
    public ElevatorControl teleB3;

    private int cycle;
    private int curAbsCycle = 0;

    protected override void Start()
    {
        base.Start();

        cycle = Services.utils.LCM(Services.utils.LCM(floor1.cycle, floor2.cycle), floor3.cycle);
    }

    public void GoClockwise()
    {
        ++curAbsCycle;
        if (curAbsCycle >= cycle)
        {
            curAbsCycle = 0;
        }

        floor1.GoClockwise();
        floor2.GoCounterClockwise();
        floor3.GoClockwise();
    }

    public void GoCounterClockwise()
    {
        --curAbsCycle;
        if (curAbsCycle < 0)
        {
            curAbsCycle = cycle - 1;
        }

        floor1.GoCounterClockwise();
        floor2.GoClockwise();
        floor3.GoCounterClockwise();
    }
}
