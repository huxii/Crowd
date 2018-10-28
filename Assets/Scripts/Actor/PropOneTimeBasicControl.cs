using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropOneTimeBasicControl : PropOneTimeControl
{
    public float deactivateDelay = 0f;

    private float timer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                FreeAllMan();
                Deactivate();
            }
        }
    }

    public override void Activate()
    {
        base.Activate();

        if (deactivateDelay > 0)
        {
            Lock();
            timer = deactivateDelay;
        }
        else
        {
            FreeAllMan();
            Lock();
            Deactivate();
        }
    }
}
