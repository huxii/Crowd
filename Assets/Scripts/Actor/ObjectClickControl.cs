using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickControl : ObjectPrimaryControl
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public override void Click()
    {
        base.Click();

        if (IsActivated())
        {
            if (needDelayToDeactivate)
            {
                DelayToDeactivate();
            }
            else
            {
                Deactivate();
            }
        }
        else
        {
            if (IsReady())
            {
                Activate();
            }
        }
    }
}
