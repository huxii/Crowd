using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerSecondControl : CycleControl
{
    private MirrorControl mirror;

    protected override void Start()
    {
        mirror = GameObject.Find("Mirror0").GetComponent<MirrorControl>();

        base.Start();
    }

    protected override void CheckCycle()
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
