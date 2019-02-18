using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCountedDeactivateControl : ObjectControl
{
    public int activatedCount = 1;

    private int count = 0;

    // Update is called once per frame
    void Update()
    {

    }

    public override bool CanActivateMultipleTimes()
    {
        return true;
    }

    public override void Activate()
    {
        base.Activate();

        ++count;
        if (count >= activatedCount)
        {
            ResetCount();
            Deactivate();
        }
    }

    public void ResetCount()
    {
        count = 0;
    }
}
