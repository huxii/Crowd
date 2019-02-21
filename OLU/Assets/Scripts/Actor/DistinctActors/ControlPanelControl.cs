using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlPanelControl : PropZeroOneControl
{
    public void UnableToUse()
    {
        Services.taskManager
            .Do(new Wait(1))
            .Then(new ActionTask(FreeAllMen));
    }

    public override void TryFreeAllMen()
    {
    }
}
