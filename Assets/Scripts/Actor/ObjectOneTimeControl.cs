using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// automatically activate when slots are filled
public class ObjectOneTimeControl : ObjectPrimaryControl
{
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

    public override void OnSlotsFull()
    {
        base.OnSlotsFull();

        Activate();
    }

    public override void Deactivate()
    {
        base.Deactivate();

        foreach (SlotAttr slot in slots)
        {
            if (slot.man != null)
            {
                Services.gameController.UnboundMan(slot.man);
            }
        }
    }
}
