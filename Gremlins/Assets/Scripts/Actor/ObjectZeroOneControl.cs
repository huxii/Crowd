using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZeroOneControl : ObjectControl
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Click()
    {
        base.Click();
        Charge();

    }

    public void Charge()
    {
        if (IsActivated())
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }
}
