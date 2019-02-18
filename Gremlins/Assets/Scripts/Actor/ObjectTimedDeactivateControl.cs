using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTimedDeactivateControl : ObjectControl
{
    public float timeToAutoDeactivate = 1f;

    protected float timer = 0;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (IsActivated())
        {
            if (timer < timeToAutoDeactivate)
            {
                timer += Time.deltaTime;
                if (timer >= timeToAutoDeactivate)
                {
                    Deactivate();
                }
            }
        }
        else
        {
            timer = 0;
        }
    }
}
