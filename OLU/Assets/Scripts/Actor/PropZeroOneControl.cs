using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PropZeroOneControl : PropAutoControl
{
    [Header("Zero One Control")]
    public UnityEvent onActivatedZero;

    protected bool isOne = false;

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

    public virtual void SetZeroOne(bool zeroOne)
    {
        isOne = zeroOne;
    }
}
