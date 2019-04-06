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
                .Then(new ActionTask(() => Services.gameEvents.SwitchCrowdState(man, CrowdControl.CrowdState.BOUNCE)))
                .Then(new ActionTask(() => Services.gameEvents.PlayAnimation(man.name + " BounceHigh")))
                .Then(new Wait(0.3f))
                .Then(new ActionTask(() => Services.gameEvents.SwitchCrowdState(man, CrowdControl.CrowdState.IDLE)))
                .Then(new Wait(0.7f))
                .Then(new ActionTask(() => Services.gameEvents.UnlockMan(man)));
        }
    }
}
