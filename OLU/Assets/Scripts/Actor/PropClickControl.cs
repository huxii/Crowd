using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropClickControl : PropControl
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
            Deactivate();
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
