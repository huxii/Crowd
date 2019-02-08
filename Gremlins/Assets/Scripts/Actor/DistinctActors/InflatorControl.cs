using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflatorControl : PropAutoLoopControl
{
    [Header("Inflator Settings")]
    public int inflatorCount;
    private int count;

    // Use this for initialization
    void Start()
    {
        ResetCount();
    }

    private void ResetCount()
    {
        count = 0;
    }

    protected override void OnSlotChange()
    {
        base.OnSlotChange();

        GameObject man0 = GetSlotMan(0);
        GameObject man1 = GetSlotMan(1);

        if (man0 == null && man1 != null)
        {
            Services.gameEvents.SwitchCrowdState(man1, CrowdControl.CrowdState.INFLATE_ING);
        }
        else
        if (man0 != null && man1 == null)
        {
            Services.gameEvents.SwitchCrowdState(man0, CrowdControl.CrowdState.INFLATE_HANDLE);
        }
        else
        if (man0 != null && man1 != null)
        {
            Services.gameEvents.SwitchCrowdState(man0, CrowdControl.CrowdState.INFLATE_HANDLE);
            Services.gameEvents.SwitchCrowdState(man1, CrowdControl.CrowdState.INFLATE_COMPLETE);
        }
    }

    public void Inflate()
    {
        if (IsReady())
        {
            GameObject man = GetSlotMan(1);
            if (man != null)
            {
                //Services.dotweenEvents.Scale(man.gameObject.name + " 1.1, 1.1, 1.1, 0.5");
            }

            ++count;
            if (count >= inflatorCount)
            {
                Services.gameEvents.UnboundMan(man);
                //Services.gameEvents.SwitchCrowdState(man, CrowdControl.CrowdState.INFLATE_FLOAT);
                Services.gameEvents.MakeFloatMan(man);

                ResetCount();
            }
        }
        else
        {
            // wind
        }
    }

    public void Deflate()
    {
        GameObject man = GetSlotMan(1);
        if (man != null)
        {
            Services.gameEvents.SwitchCrowdState(man, CrowdControl.CrowdState.IDLE);
            //Services.dotweenEvents.ScaleTo(man.gameObject.name + " 1, 1, 1, 0.9");
        }

        ResetCount();
    }


    public override void Deactivate()
    {
        if (count < inflatorCount)
        {
            Deflate();
        }

        base.Deactivate();
    }
}
