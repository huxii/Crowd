using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlPanelControl : PropPassiveControl
{
    [Header("Control Panel Settings")]
    public UnityEvent onActivatedWhenWheelIsNot;
    private bool isWheelActivated;

    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();

        if (isWheelActivated)
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
                onActivatedWhenWheelIsNot.Invoke();

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

    public void SetWheelActivated(bool en)
    {
        isWheelActivated = en;
    }
}
