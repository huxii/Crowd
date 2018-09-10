using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragTransformControl : ObjectControl
{
    [HideInInspector]
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
        ActivatedUpdate();
	}

    public override void Drag(Vector3 dp)
    {
        if (ObjectReady())
        {
            base.Drag(dp);

            deltaPos = new Vector3(
                Mathf.Max(Mathf.Min(deltaPos.x + dp.x, maxDelta.x), minDelta.x),
                Mathf.Max(Mathf.Min(deltaPos.y + dp.y, maxDelta.y), minDelta.y),
                Mathf.Max(Mathf.Min(deltaPos.z + dp.z, maxDelta.z), minDelta.z)
                );
            transform.position = origPos + deltaPos;

            if (deltaPos.x <= minDelta.x + 0.01f && deltaPos.y <= minDelta.y + 0.01f && deltaPos.z <= minDelta.z + 0.01f)
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
    }
}
