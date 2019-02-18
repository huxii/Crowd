using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropOneTimeBasicControl : PropOneTimeControl
{
    public float deactivateDelay = 0f;

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                FreeAllMen();

                if (IsActivated())
                {
                    Deactivate();
                }

                if (!IsLocked())
                {
                    Lock();
                }
            }
        }
    }

    public override void Activate()
    {
        base.Activate();

        if (deactivateDelay > 0)
        {
            timer = deactivateDelay;
        }
        else
        if (deactivateDelay == 0)
        {
            FreeAllMen();
            Lock();
            Deactivate();
        }
        else
        {
            // manually deactivate
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        if (deactivateDelay < 0)
        {
            timer = Mathf.Abs(deactivateDelay);
        }
    }
}
