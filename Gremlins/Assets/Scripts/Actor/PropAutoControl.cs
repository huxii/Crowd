using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * automatically activate when slots are filled
 */

public abstract class PropAutoControl : PropControl
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();

        Activate();
    }
}
