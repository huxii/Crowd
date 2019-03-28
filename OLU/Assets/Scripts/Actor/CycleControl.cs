using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CycleControl : ObjectControl
{
    [Header("Cycle Settings")]
    public int cycle = 3;
    public float step = 120f;

    [SerializeField]
    protected int curCycle = 0;
    [SerializeField]
    protected int curAbsCycle = 0;

    public virtual void GoClockwise()
    {
        ++curCycle;
        ++curAbsCycle;
        if (curAbsCycle >= cycle)
        {
            curAbsCycle = 0;
        }

        Services.dotweenEvents.Rotate(gameObject.name + " y " + step + " 1");
    }

    public virtual void GoCounterClockwise()
    {
        --curCycle;
        --curAbsCycle;
        if (curAbsCycle < 0)
        {
            curAbsCycle = cycle - 1;
        }
        Services.dotweenEvents.Rotate(gameObject.name + " y " + -step + " 1");
    }
}
