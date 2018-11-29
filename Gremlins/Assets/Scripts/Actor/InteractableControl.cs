using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 *      Control all the actors that can interact with
 */
 
public abstract class InteractableControl : ActorControl
{
    // events invoked when it's activated & deactivated
    public bool canActivateMultipleTimes = false;
    public UnityEvent onActivated;
    public UnityEvent onDeactivated;
    
    [Header("Interaction")]
    // interactionCD will prevent player to constantly click on the interactable
    public float interactionCD = 0;
    // specifically for props like ladders
    public bool isWalkableAfterDeactivated = false;
    // specifically for objects like moving platforms
    public bool dropMenAfterDeactivated = false;

    protected float interactionTimer = 0;
    protected bool isActivated = false;

    // Use this for initialization
    void Start ()
    {       
    }
	
	// Update is called once per frame
	void Update ()
    {		
	}

    protected void CoolDown()
    {
        interactionTimer = Time.time;
    }

    public bool IsCoolingDown()
    {
        return Time.time - interactionTimer <= interactionCD;
    }

    public virtual void Click()
    {
    }

    public virtual void Drag(Vector3 deltaPos)
    {
    }

    public virtual void Swipe()
    {
    }

    public bool IsActivated()
    {
        return isActivated;
    }

    // it can not be activated when it is locked but can be deactivated
    public virtual void Activate()
    {
        if ((!IsActivated() || canActivateMultipleTimes) && !IsLocked())
        {
            isActivated = true;

            CoolDown();
            onActivated.Invoke();
        }
    }

    public virtual void Deactivate()
    {
        if (IsActivated())
        {
            isActivated = false;

            CoolDown();
            onDeactivated.Invoke();
        }
    }
}
