using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragTransformControl : ObjectDragControl
{
    private Vector3 deltaPos = new Vector3(0, 0, 0);
    private Vector3 origPos;

    // Use this for initialization
    void Start ()
    {
        origPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    protected bool InRange()
    {
        return (deltaPos.x >= minValidDelta.x - 0.01f && deltaPos.x <= maxValidDelta.x + 0.01f
            && deltaPos.y >= minValidDelta.y - 0.01f && deltaPos.y <= maxValidDelta.y + 0.01f
            && deltaPos.z >= minValidDelta.z - 0.01f && deltaPos.z <= maxValidDelta.z + 0.01f);
    }

    public override void Drag(Vector3 dp)
    {
        if (IsReady() && !IsLocked())
        {
            base.Drag(dp);

            bool alreadyInRange = InRange();

            deltaPos = new Vector3(
                Mathf.Max(Mathf.Min(deltaPos.x + dp.x, maxDelta.x), minDelta.x),
                Mathf.Max(Mathf.Min(deltaPos.y + dp.y, maxDelta.y), minDelta.y),
                Mathf.Max(Mathf.Min(deltaPos.z + dp.z, maxDelta.z), minDelta.z)
                );
            transform.position = origPos + deltaPos;

            if (InRange())
            {
                if (!alreadyInRange)
                {
                    onArriveValidRange.Invoke();
                }
            }
            else
            {
                if (alreadyInRange)
                {
                    onLeaveValidRange.Invoke();
                }
            }
        }
    }
}
