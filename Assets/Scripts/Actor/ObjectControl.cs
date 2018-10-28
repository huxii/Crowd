﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class ObjectControl : ActorControl
{
    public UnityEvent onActivated;
    public UnityEvent onDeactivated;
    public UnityEvent onClick;

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

    public virtual void Click()
    {
        onClick.Invoke();
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
        onActivated.Invoke();
    }

    public virtual void Deactivate()
    {
        isActivated = false;
        onDeactivated.Invoke();
    }
}
