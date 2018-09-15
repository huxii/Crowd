﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorControl : MonoBehaviour
{
    // 1. can't move    2. slots won't work
    protected bool locked = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public virtual void Lock()
    {
        locked = true;
    }

    public virtual void Unlock()
    {
        locked = false;
    }

    public bool IsLocked()
    {
        return locked;
    }
}
