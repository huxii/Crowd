using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflatorBehavior : ObjectCountedDeactivateControl
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool Inflate()
    {
        PropControl prop = GetComponent<PropControl>();
        if (prop == null || !prop.IsReady())
        {
            return false;
        }

        GameObject man = prop.GetSlotMan(1);
        if (man != null)
        {
            Services.dotweenEvents.Scale(man.gameObject.name + " 1.1, 1.1, 1.1, 0.5");
            return true;
        }

        return false;
    }

    public void Deflate()
    {
        PropControl prop = GetComponent<PropControl>();
        if (prop == null)
        {
            return;
        }

        GameObject man = prop.GetSlotMan(1);
        if (man != null)
        {
            Services.dotweenEvents.ScaleTo(man.gameObject.name + " 1, 1, 1, 0.9");
            ResetCount();
        }
    }

    public override void Activate()
    {
        if (Inflate())
        {
            base.Activate();
        }
    }

    public override void Deactivate()
    {
        GameObject man = GetComponent<PropControl>().GetSlotMan(1);
        Services.gameEvents.UnboundMan(man);
        Services.gameEvents.MakeFloatMan(man);

        base.Deactivate();
    }
}
