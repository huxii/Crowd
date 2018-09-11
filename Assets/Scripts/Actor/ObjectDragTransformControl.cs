using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragTransformControl : ObjectControl
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

    protected bool AtMinPos()
    {
        return (deltaPos.x <= minDelta.x + 0.01f && deltaPos.y <= minDelta.y + 0.01f && deltaPos.z <= minDelta.z + 0.01f);
    }

    protected bool AtMaxPos()
    {
        return (deltaPos.x >= maxDelta.x - 0.01f && deltaPos.y >= maxDelta.y - 0.01f && deltaPos.z >= maxDelta.z - 0.01f);
    }

    public override void Drag(Vector3 dp)
    {
        if (ObjectReady())
        {
            base.Drag(dp);

            bool alreadyMinPos = AtMinPos();
            bool alreadyMaxPos = AtMaxPos();

            deltaPos = new Vector3(
                Mathf.Max(Mathf.Min(deltaPos.x + dp.x, maxDelta.x), minDelta.x),
                Mathf.Max(Mathf.Min(deltaPos.y + dp.y, maxDelta.y), minDelta.y),
                Mathf.Max(Mathf.Min(deltaPos.z + dp.z, maxDelta.z), minDelta.z)
                );
            transform.position = origPos + deltaPos;

            if (AtMinPos())
            {
                if (!alreadyMinPos)
                {
                    OnArriveMinPosition.Invoke();
                }
            }
            else
            if (alreadyMinPos)
            {
                OnLeaveMinPosition.Invoke();
            }

            if (AtMaxPos())
            {
                if (!alreadyMaxPos)
                {
                    OnArriveMaxPosition.Invoke();
                }
            }
            else
            if (alreadyMaxPos)
            {
                OnLeaveMaxPosition.Invoke();
            }
        }
    }
}
