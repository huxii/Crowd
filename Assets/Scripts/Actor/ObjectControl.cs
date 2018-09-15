using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class ObjectControl : ActorControl
{
    public UnityEvent onActivated;
    public UnityEvent onDeactivated;

    protected bool readyToDeactivate = false;

    private Sequence animationSequence;

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

    public virtual void Drag(Vector3 deltaPos)
    {
    }

    public virtual bool IsActivated()
    {
        return false;
    }

    public void Activate()
    {
        onActivated.Invoke();
    }

    public void Deactivate()
    {
        onDeactivated.Invoke();
    }

    public void DelayToDeactivate()
    {
        readyToDeactivate = true;
    }

    public void Pause()
    {
        if (readyToDeactivate)
        {
            readyToDeactivate = false;
            Deactivate();
        }
    }

    public void SetSequence(Sequence seq)
    {
        animationSequence = seq;
    }

    public Sequence GetSequence()
    {
        return animationSequence;
    }
}
