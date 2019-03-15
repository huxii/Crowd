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
                .Then(new ActionTask(() => GameObject.Find("Can").GetComponent<CanBehavior>().Activate()))
                .Then(new ActionTask(() => Services.gameEvents.SetCrowdAnimation(man, "inflate_asshole_squeeze", SpineAnimationControl.CLEAR_NOT_FACIAL)));

            Activate();
        }
    }

    public override void Deactivate()
    {
        if (CanDeactivate())
        {
            Services.gameEvents.RemoveAnchor(man);
            // dead :)
            Services.gameEvents.SetCrowdAnimation(man, "inflate_asshole_tired", SpineAnimationControl.CLEAR_NOT_FACIAL);
            Services.gameEvents.PlayAnimation(man.name + " ThrowOut");
            //Services.taskManager
            //    .Do(new Wait(1.8f))
            //    .Then(new ActionTask(() => Destroy(man)));
            
            //man.transform.eulerAngles = new Vector3(0, 0, 90);
            man = null;

            isActivated = false;

            CoolDown();
            onDeactivated.Invoke();
        }
    }
}
