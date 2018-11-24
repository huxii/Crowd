using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjectControl : ObjectControl
{
    [Header("Multi Objects")]
    public int objectNumber = 0;
    protected int curObjectNumber = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Activate()
    {
        ++curObjectNumber;
        if (curObjectNumber >= objectNumber)
        {
            base.Activate();
        }
    }
}
