﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * the parent object to control multiple props
 * eg. ferris wheel
*/

public class MultiplePropControl : ObjectControl
{
    [Header("Multi Props")]
    public float lockDuration = -1;
    private float lockTimer;
    
    // Update is called once per frame
    void Update()
    {
        if (lockTimer > 0)
        {
            lockTimer -= Time.deltaTime;
            if (lockTimer <= 0)
            {
                UnlockChildren();
            }
        }
    }

    public void LockChildren()
    {
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            //Debug.Log(child.gameObject);
            if (child.gameObject.CompareTag("Prop") || child.gameObject.CompareTag("Man"))
            {
                child.gameObject.GetComponent<ActorControl>().Lock();
            }
        }
    }

    public void UnlockChildren()
    {
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.CompareTag("Prop") || child.gameObject.CompareTag("Man"))
            {
                child.gameObject.GetComponent<ActorControl>().Unlock();
            }
        }
    }

    public void ActivateChildren()
    {
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.CompareTag("Prop"))
            {
                child.gameObject.GetComponent<PropControl>().Activate();
            }
        }
    }

    public void DeactivateChildren()
    {
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.CompareTag("Prop"))
            {
                child.gameObject.GetComponent<PropControl>().Deactivate();
            }
        }
    }

    // when it is activated, all the children props/objects/men will be locked
    public override void Activate()
    {
        base.Activate();

        ActivateChildren();
        LockChildren();     

        lockTimer = lockDuration;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        UnlockChildren();
        DeactivateChildren();
    }
}
