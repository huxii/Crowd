using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractableControl : ActorControl
{
    public UnityEvent onActivated;
    public UnityEvent onDeactivated;

    [Header("Interaction")]
    public float interactionCD = 0;
    public bool isWalkableAfterDeactivated = false;
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

    public virtual void Activate()
    {
        if (!IsActivated() && !IsLocked())
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
