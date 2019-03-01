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

            // prevent be pushed out by other men
            Destroy(man.GetComponent<Collider>());
            
            man.transform.eulerAngles = new Vector3(0, 0, 90);

            man = null;

            isActivated = false;

            CoolDown();
            onDeactivated.Invoke();
        }
    }
}
