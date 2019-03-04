using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehavior : ObjectTimedDeactivateControl
{
    GameObject man = null;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (man == null && other.CompareTag("Man") && other.GetComponent<FloatBehavior>())
        {
            Services.gameEvents.AddAnchor(other.gameObject, gameObject);
            man = other.gameObject;

            GameObject.Find("WindZone").GetComponent<WindBehavior>().RemoveMan(man);

            Deactivate();
        }
    }

    public override void Activate()
    {
        base.Activate();

        man = null;
        Services.gameEvents.PlayAnimation("HookWithBendy HookExpand");
    }

    public override void Deactivate()
    {
        if (CanDeactivate())
        {
            isActivated = false;

            CoolDown();

            if (man != null)
            {
                Services.taskManager
                    .Do(new ActionTask(
                        () => Services.gameEvents.PlayAnimation("HookWithBendy HookCatched")
                        ))
                    .Then(new Wait(5))
                    .Then(new ActionTask(GameObject.Find("ControlPanel").GetComponent<PropControl>().FreeAllMen));
            }
            else
            {
                Services.taskManager
                    .Do(new ActionTask(
                        () => Services.gameEvents.PlayAnimation("HookWithBendy HookEmpty")
                        ))
                    .Then(new Wait(1))
                    .Then(new ActionTask(GameObject.Find("ControlPanel").GetComponent<PropControl>().FreeAllMen));
            }

            onDeactivated.Invoke();
        }
    }
}
