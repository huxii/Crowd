using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// activate by other props when slots are filled
public class PropPassiveBasicControl : PropPassiveControl
{
    public int remainingTimes;
    private int timesCounter;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public override void OnSlotsFull()
    {
        base.OnSlotsFull();

        timesCounter = remainingTimes;
    }

    public override void Activate()
    {
        base.Activate();

        --timesCounter;
        if (timesCounter == 0)
        {
            Deactivate();
        }
    }
}
