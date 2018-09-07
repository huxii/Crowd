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
    protected int currentSlots = 0;

    private float holdTime = 0;

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
        Services.eventManager.Register<ManArrivesAtObj>(OnManArrivesAtObj);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnDestroy()
    {
        Services.eventManager.Unregister<ManArrivesAtObj>(OnManArrivesAtObj);
    }

    void OnManArrivesAtObj(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrivesAtObj;
        ++currentSlots;
    }

    public virtual void Drag(Vector3 deltaPos)
    {

    }

    //protected override void MouseDown()
    //{
    //    holdTime = Time.time;
    //    Debug.Log("Click on object " + gameObject.name);
    //}

    //protected override void MouseUp()
    //{
    //    base.MouseUp();
    //    if (Time.time - holdTime > 1f)
    //    {
    //        MouseHold();
    //    }
    //}

    //protected override void MouseHold()
    //{
    //    base.MouseHold();

    //    if (currentSlots < totalSlots)
    //    {
    //        Services.gameController.RequestNewMan(gameObject);
    //    }
    //}
}
