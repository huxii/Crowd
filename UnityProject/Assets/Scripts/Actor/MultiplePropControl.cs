using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the objects that control or are controlled by primary objects
public class MultiplePropControl : ObjectControl
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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

    public override void Activate()
    {
        base.Activate();

        LockChildren();
        ActivateChildren();
    }

    public override void Deactivate()
    {
        base.Deactivate();

        UnlockChildren();
        DeactivateChildren();
    }
}
