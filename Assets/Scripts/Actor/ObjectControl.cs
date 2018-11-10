using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectControl : ActorControl
{
    [Header("Interaction")]
    public float interactionCD = 0;
    public UnityEvent onInteractionFeedback;
    protected float interactionTimer = 0;

    public UnityEvent onActivated;
    public UnityEvent onDeactivated;

    [Header("After Deactivated")]
    public bool isWalkable = false;
    public bool dropMen = false;

    protected bool isActivated = false;

    // Use this for initialization
    void Start ()
    {       
    }
	
	// Update is called once per frame
	void Update ()
    {		
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
        isActivated = true;

        interactionTimer = Time.time;
        onActivated.Invoke();
    }

    public virtual void Deactivate()
    {
        isActivated = false;

        interactionTimer = Time.time;
        onDeactivated.Invoke();
    }
}
