using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// automatically activate when slots are filled
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

    public override void OnSlotsFull()
    {
        base.OnSlotsFull();

        Activate();
    }

    public override PropState Interact()
    {
        if (IsLocked())
        {
            if (isWalkableAfterDeactivated)
            {
                return PropState.WALKABLE;
            }
            else
            {
                return PropState.STAY;
            }
        }
        else
        {
            onInteractionFeedback.Invoke();

            if (IsActivated())
            {
                return PropState.DEACTIVATED;
            }
            else
            {
                return PropState.ACTIVATED;
            }
        }

        return PropState.STAY;
    }
}
