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

            Services.taskManager
                .Do(new ActionTask(() => Services.gameEvents.LockMan(man)))
                .Then(new ActionTask(() => Services.gameEvents.PlayAnimation(man.name + " BounceHigh")))
                .Then(new Wait(1))
                .Then(new ActionTask(() => Services.gameEvents.UnlockMan(man)));
        }
    }
}
