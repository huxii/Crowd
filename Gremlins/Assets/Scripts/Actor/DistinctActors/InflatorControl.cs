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


    }

    public void Inflate()
    {
        if (IsReady())
        {
            GameObject man = GetSlotMan(1);
            if (man != null)
            {
                Services.dotweenEvents.Scale(man.gameObject.name + " 1.1, 1.1, 1.1, 0.5");
            }

            ++count;
            if (count >= inflatorCount)
            {
                Services.gameEvents.UnboundMan(man);
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
            Services.dotweenEvents.ScaleTo(man.gameObject.name + " 1, 1, 1, 0.9");
        }
    }


    public override void Deactivate()
    {
        Deflate();

        base.Deactivate();
    }
}
