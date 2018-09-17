using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectDragControl : ObjectPrimaryControl
{    
    // the range of dragging
    public Vector3 minDelta = new Vector3(0, 0, 0);
    public Vector3 maxDelta = new Vector3(0, 0, 0);

    public Vector3 minValidDelta = new Vector3(0, 0, 0);
    public Vector3 maxValidDelta = new Vector3(0, 0, 0);

    public UnityEvent onArriveValidRange;
    public UnityEvent onLeaveValidRange;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
