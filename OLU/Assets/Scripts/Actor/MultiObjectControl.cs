using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjectControl : ObjectControl
{
    [Header("Multi Objects")]
    public int objectNumber = 0;
    public float activateDelay = 2;

    protected int curObjectNumber = 0;

    public void Charge()
    {
        ++curObjectNumber;
        if (curObjectNumber >= objectNumber)
        {
            Services.taskManager
                .Do(new Wait(activateDelay))
                .Then(new ActionTask(Activate));
        }
    }

    public void Release()
    {
        --curObjectNumber;
        if (curObjectNumber == 0)
        {
            Deactivate();
        }
    }
}
