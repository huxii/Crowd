using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* activate and deactivate by other props when slots are filled
*/

public abstract class PropPassiveControl : PropControl
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();

        LockAllMen();
    }

    protected override void OnSlotsNotFull()
    {
    }

    public override void Deactivate()
    {
        base.Deactivate();

        UnlockAllMen();
        FreeAllMen();
    }
}
