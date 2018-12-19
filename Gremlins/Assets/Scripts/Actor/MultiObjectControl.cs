using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjectControl : ObjectControl
{
    [Header("Multi Objects")]
    public int objectNumber = 0;
    public float activateDelay = 2;

    protected int curObjectNumber = 0;
    protected float timer = 0;

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
                base.Activate();
            }
        }
    }

    public override void Activate()
    {
        ++curObjectNumber;
        if (curObjectNumber >= objectNumber)
        {
            timer = activateDelay;
        }
    }
}
