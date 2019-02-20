using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBedControl : PropAutoTimedDeactivateControl
{
    public override void Deactivate()
    {
        if (CanDeactivate())
        {
            isActivated = false;

            CoolDown();
            onDeactivated.Invoke();

            GameObject man = GetSlotMan(0);
            Services.gameEvents.ImmediateUnboundMan(man);
            Services.gameEvents.PlayAnimation(man.name + " BounceHigh");
        }
    }
}
