using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// automatically deactivate after some time
public class PropAutoDeactivateControl : PropAutoControl
{
    [Header("Auto Deactivate Settings")]
    public float timeToAutoDeactivate = 1f;

    private float timer = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsActivated())
        {
            if (timer < timeToAutoDeactivate)
            {
                timer += Time.deltaTime;
                if (timer >= timeToAutoDeactivate)
                {
                    Deactivate();
                }
            }
        }
        else
        {
            timer = 0;
        }
	}

    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();
    }

    public override void Deactivate()
    {
        base.Deactivate();

        FreeAllMen();
    }
}
