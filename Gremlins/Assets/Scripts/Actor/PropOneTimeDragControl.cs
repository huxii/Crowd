using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropOneTimeDragControl : PropOneTimeControl
{
    [Header("Drag Settings")]
    public Vector3 dragOffset;
    public UnityEvent onReachEnd;

    protected Vector3 deltaPos;
    protected Vector3 origPos;
    protected Vector3 minBound;
    protected Vector3 maxBound;
    protected float speed = 5f;
    protected float hintTimer;
    protected float hintCD = 3f;

    // on dragging for sound effect
    // Use this for initialization
    void Start ()
    {
        origPos = transform.position;
        deltaPos = new Vector3(0, 0, 0);

        float minx = 0;
        float maxx = dragOffset.x;
        float miny = 0;
        float maxy = dragOffset.y;
        float minz = 0;
        float maxz = dragOffset.z;
        if (minx > maxx)
        {
            minx = maxx;
            maxx = 0;
        }

        if (miny > maxy)
        {
            miny = maxy;
            maxy = 0;
        }

        if (minz > maxz)
        {
            minz = maxz;
            maxz = 0;
        }

        minBound = new Vector3(minx, miny, minz);
        maxBound = new Vector3(maxx, maxy, maxz);
        hintTimer = 1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!IsLocked())
        {
            Vector3 targetPos = origPos + deltaPos;
            Vector3 newPos = transform.position;
            if (Vector3.Distance(targetPos, newPos) > 0.001f)
            {
                newPos = Vector3.Lerp(newPos, targetPos, Time.deltaTime * speed);
                transform.position = newPos;
            }
            else
            {
                if (Vector3.Distance(newPos, origPos + dragOffset) < 0.001f)
                {
                    onReachEnd.Invoke();
                    FreeAllMen();
                    Lock();
                }
                else
                {
                    if (IsActivated())
                    {
                        if (hintTimer <= 0)
                        {
                            hintTimer = hintCD;
                            Services.dotweenEvents.Spring(gameObject.name + " x -0.2 0.25 2");
                            CoolDown();
                        }
                        else
                        {
                            hintTimer -= Time.deltaTime;
                        }
                    }
                }
            }
        }
	}

    public override void Drag(Vector3 d)
    {
        if (!IsCoolingDown() && IsActivated() && !IsLocked())
        {
            base.Drag(d);

            deltaPos += d;
            deltaPos = new Vector3(
                Mathf.Min(Mathf.Max(minBound.x, deltaPos.x), maxBound.x),
                Mathf.Min(Mathf.Max(minBound.y, deltaPos.y), maxBound.y),
                Mathf.Min(Mathf.Max(minBound.z, deltaPos.z), maxBound.z)
                );
        }
    }
}
