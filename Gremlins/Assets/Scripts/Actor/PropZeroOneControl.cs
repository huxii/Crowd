using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropZeroOneControl : PropAutoControl
{
    [Header("Zero One Control")]
    public UnityEvent onActivatedZero;

    private bool isOne = false;

    public override void Activate()
    {
        if (CanActivate())
        {
            isActivated = true;

            CoolDown();

            if (isOne)
            {
                onActivated.Invoke();
            }
            else
            {
                onActivatedZero.Invoke();
            }
        }
    }

    public void SetZeroOne(bool zeroOne)
    {
        isOne = zeroOne;
    }
}
