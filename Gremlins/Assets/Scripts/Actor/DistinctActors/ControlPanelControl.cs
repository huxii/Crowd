using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlPanelControl : PropPassiveControl
{
    [Header("Control Panel Settings")]
    public UnityEvent onActivatedWhenParentIsNot;

    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();

        if (GameObject.Find("ControlCenter").GetComponent<ObjectControl>().IsActivated())
        {
            if (CanActivate())
            {
                isActivated = true;

                CoolDown();
                onActivated.Invoke();
            }
        }
        else
        {
            if (CanActivate())
            {
                isActivated = true;

                CoolDown();
                onActivatedWhenParentIsNot.Invoke();

                Services.taskManager
                    .Do(new Wait(1))
                    .Then(new ActionTask(FreeAllMen));
            }
        }
    }

    protected override void OnSlotsNotFull()
    {
        base.OnSlotsNotFull();

        Deactivate();
    }
}
