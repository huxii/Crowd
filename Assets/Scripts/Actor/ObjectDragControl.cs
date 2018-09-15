using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectDragControl : ObjectPrimaryControl
{    
    // the range of dragging
    public Vector3 minDelta = new Vector3(0, 0, 0);
    public Vector3 maxDelta = new Vector3(0, 0, 0);

    public UnityEvent onArriveMinPosition;
    public UnityEvent onArriveMaxPosition;
    public UnityEvent onLeaveMinPosition;
    public UnityEvent onLeaveMaxPosition;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
