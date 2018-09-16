using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// automatically activate when slots are filled
public class ObjectAutoControl : ObjectPrimaryControl
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override void Ready()
    {
        base.Ready();

        Activate();
    }
}
