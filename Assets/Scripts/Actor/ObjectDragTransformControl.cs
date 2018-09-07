using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragTransformControl : ObjectDragControl
{
    public bool ready = false;

    // tmp solution
    public GameObject startPathPoint;
    public GameObject endPathPoint;

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

    public override void Drag(Vector3 dp)
    {
        base.Drag(dp);

        deltaPos = new Vector3(
            Mathf.Max(Mathf.Min(deltaPos.x + dp.x, maxDelta.x), minDelta.x),
            Mathf.Max(Mathf.Min(deltaPos.y + dp.y, maxDelta.y), minDelta.y),
            Mathf.Max(Mathf.Min(deltaPos.z + dp.z, maxDelta.z), minDelta.z)
            );
        transform.position = origPos + deltaPos;

        if (deltaPos.x <= minDelta.x && deltaPos.y <= minDelta.y && deltaPos.z <= minDelta.z)
        {
            if (!ready)
            {
                ready = true;
                Services.pathFindingManager.ConnectPathPoints(startPathPoint, endPathPoint);
            }
        }
        else
        {
            if (ready)
            {
                ready = false;
                Services.pathFindingManager.DisconnectPathPoints(startPathPoint, endPathPoint);
            }
        }
    }

    //protected override void MouseDown()
    //{
    //    base.MouseDown();
    //}

    //protected override void MouseDrag()
    //{
    //    base.MouseDrag();

    //    deltaPos = new Vector3(
    //        Mathf.Max(Mathf.Min(deltaPos.x + deltaMouseWorldPos.x, maxDelta.x), minDelta.x),
    //        Mathf.Max(Mathf.Min(deltaPos.y + deltaMouseWorldPos.y, maxDelta.y), minDelta.y),
    //        Mathf.Max(Mathf.Min(deltaPos.z + deltaMouseWorldPos.z, maxDelta.z), minDelta.z)
    //        );
    //    transform.position = origPos + deltaPos;

    //    if (deltaPos.x <= minDelta.x && deltaPos.y <= minDelta.y && deltaPos.z <= minDelta.z)
    //    {
    //        if (!ready)
    //        {
    //            ready = true;
    //            Services.pathFindingManager.ConnectPathPoints(startPathPoint, endPathPoint);
    //        }
    //    }
    //    else
    //    {
    //        if (ready)
    //        {
    //            ready = false;
    //            Services.pathFindingManager.DisconnectPathPoints(startPathPoint, endPathPoint);
    //        }
    //    }
    //}
}
