using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPassiveHolderControl : PropPassiveControl
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Activate()
    {
        base.Activate();

        if (!IsReady())
        {
            OnSlotsFull();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        if (!IsReady())
        {
            OnSlotsNotFull();
        }
    }
}
