using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectBasicControl : ObjectControl
{
    public UnityEvent onClick;

    // Update is called once per frame
    void Update()
    {
    }

    public override void Click()
    {
        base.Click();

        if (CanActivate())
        {
            CoolDown();
            onClick.Invoke();
        }
    }
}
