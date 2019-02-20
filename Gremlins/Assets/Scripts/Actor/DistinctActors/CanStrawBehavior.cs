using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanStrawBehavior : ObjectTimedDeactivateControl
{
    private GameObject man = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Man") && CanActivate())
        {
            man = other.gameObject;
            Services.gameEvents.AddAnchor(other.gameObject, transform.GetChild(0).gameObject);
            Services.taskManager
                .Do(new Wait(1))
                .Then(new ActionTask(() => Services.gameEvents.SetCrowdAnimation(man, "inflate_asshole_squeeze", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL)));

            Activate();
        }
    }

    public override void Deactivate()
    {
        if (CanDeactivate())
        {
            Services.gameEvents.RemoveAnchor(man);
            // dead :)
            Services.gameEvents.SetCrowdAnimation(man, "inflate_asshole_tired", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);
            Services.gameEvents.PlayAnimation(man.name + " ThrowOut");
            //Services.taskManager
            //    .Do(new ActionTask(() => Services.dotweenEvents.MoveTo(man.name + " 2.77, 0.82, -2.53, 1")))
            //    .Then(new Wait(1))
            //    .Then(new ActionTask(() => Services.dotweenEvents.MoveTo(man.name + " 4.72, 0.23, -2.53, 1")));
            
            man.transform.eulerAngles = new Vector3(0, 0, 90);

            man = null;

            isActivated = false;

            CoolDown();
            onDeactivated.Invoke();
        }
    }
}
