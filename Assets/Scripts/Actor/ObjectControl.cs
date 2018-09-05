using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: click task & feedback to switch state

// TODO: click task
// cycle time / number of cycles / is looping

public abstract class ObjectControl : ActorControl
{
    // total slots for the crowd
    public int totalSlots = 0;

    // current slots occupied by the crowd
    private int currentSlots = 0;

    //public enum ObjectControlScheme
    //{
    //    DRAG_TRANSFORMATION,
    //    DRAG_ROTATION,
    //    CLICK,
    //    // HOLD,
    //    // SMASH,
    //    // SWIPE,
    //    // OTHEROBJECT
    //};

    //public ObjectControlScheme controlScheme = ObjectControlScheme.DRAG_TRANSFORMATION;
    //public bool deltaLimited = false;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnMouseDown()
    {
        MouseDown();
    }

    public void OnMouseUp()
    {
        MouseUp();
    }

    public void OnMouseDrag()
    {
        if (currentSlots > totalSlots)
        {
            // should never happen
            print("currentSlots > totalSlots");
        }
        else
        if (currentSlots == totalSlots)
        {
            // happen when slots are fullfilled
            MouseDrag();
        }
    }
}
