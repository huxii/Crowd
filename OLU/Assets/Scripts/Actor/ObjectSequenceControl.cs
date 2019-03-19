using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectSequenceControl : ObjectControl
{
    public List<UnityEvent> sequenceClickEvents;
    protected int curIdx = 0;

    private void DoNextEvent()
    {
        if (curIdx < sequenceClickEvents.Count)
        {
            CoolDown();
            sequenceClickEvents[curIdx++].Invoke();
        }
    }

    public override void Click()
    {
        //base.Click();

        if (CanActivate())
        {
            DoNextEvent();
        }
    }
}
