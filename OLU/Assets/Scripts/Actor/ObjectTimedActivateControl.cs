using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTimedActivateControl : ObjectControl
{
    public float timeToAutoActivate = 1f;

    private bool isAboutToActivate = false;
    private float timer = 0;

    protected virtual void Update()
    {
        if (isAboutToActivate)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    base.Activate();
                }
            }
        }
    }

    public override void Activate()
    {
        isAboutToActivate = true;
        timer = timeToAutoActivate;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        isAboutToActivate = false;
        timer = 0;
    }
}
