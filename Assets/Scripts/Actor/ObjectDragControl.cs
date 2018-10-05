using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectDragControl : ObjectPrimaryControl
{
    // the range of dragging
    public Vector3 minDelta = new Vector3(0, 0, 0);
    public Vector3 maxDelta = new Vector3(0, 0, 0);

    public UnityEvent onArriveMaxEnd;
    public UnityEvent onArriveMinEnd;

    protected Vector3 deltaPos;
    protected Vector3 origPos;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    protected void Init()
    {
        origPos = transform.position;
        deltaPos = new Vector3(0, 0, 0);
    }

    protected bool InRange()
    {
        return (deltaPos.x >= minDelta.x - 0.01f && deltaPos.x <= maxDelta.x + 0.01f
            && deltaPos.y >= minDelta.y - 0.01f && deltaPos.y <= maxDelta.y + 0.01f
            && deltaPos.z >= minDelta.z - 0.01f && deltaPos.z <= maxDelta.z + 0.01f);
    }
}
