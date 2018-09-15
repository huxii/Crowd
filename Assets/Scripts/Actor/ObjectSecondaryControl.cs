using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSecondaryControl : ObjectControl
{
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override void Lock()
    {
        base.Lock();

        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            Debug.Log(child.gameObject);
            if (child.gameObject.CompareTag("Object") || child.gameObject.CompareTag("Man"))
            {
                child.gameObject.GetComponent<ActorControl>().Lock();
            }
        }
    }

    public override void Unlock()
    {
        base.Unlock();

        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.CompareTag("Object") || child.gameObject.CompareTag("Man"))
            {
                child.gameObject.GetComponent<ActorControl>().Unlock();
            }
        }
    }
}
