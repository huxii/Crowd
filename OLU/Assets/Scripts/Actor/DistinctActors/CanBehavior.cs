using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBehavior : ObjectCountedDeactivateControl
{
    public void LightOnOff()
    {
        LightBehavior light = GetComponent<LightBehavior>();
        if (light != null)
        {
            Services.taskManager
                .Do(new ActionTask(light.Activate))
                .Then(new Wait(1))
                .Then(new ActionTask(light.Deactivate));
        }
    }
}
