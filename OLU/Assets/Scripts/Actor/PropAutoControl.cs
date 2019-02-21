using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * automatically activate when slots are filled
 */

public abstract class PropAutoControl : PropControl
{
    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();

        Activate();
    }

    protected override void OnSlotsNotFull()
    {
        base.OnSlotsNotFull();

        Deactivate();
    }

    public override void TryFreeAllMen()
    {
        base.TryFreeAllMen();

        FreeAllMen();
    }
}
