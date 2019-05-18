using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerSecondControl : CycleControl
{
    private MirrorControl mirror;

    protected void Awake()
    {
        mirror = GameObject.Find("Mirror0").GetComponent<MirrorControl>();
    }

    public override void CheckCycle()
    {
        if (curAbsCycle == 0)
        {
            mirror.SetZeroOne(true);
        }
        else
        {
            mirror.SetZeroOne(false);
        }
    }
}
