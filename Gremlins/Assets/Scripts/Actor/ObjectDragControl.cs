﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDragControl : ObjectBasicControl
{
    public UnityEvent onDrag;
    public UnityEvent onMinDrag;
    public UnityEvent onMaxDrag;

    public float rotationSpeed = 10f;
    public Vector2 rotationRange = new Vector2(0, 0);

    Vector3 origRot = new Vector3(0, 0, 0);
    Vector3 deltaRot = new Vector3(0, 0, 0);
    bool isRotDirty = true;
    bool isMouseDown = false;

    // Use this for initialization
    void Start()
    {
        Services.eventManager.Register<ReleaseEvent>(OnHoldRelease);
    }

    private void OnApplicationQuit()
    {
        Services.eventManager.Unregister<ReleaseEvent>(OnHoldRelease);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCoolingDown())
        {
            if (isRotDirty)
            {
                origRot = transform.localEulerAngles;
                deltaRot = new Vector3(0, 0, 0);
                isRotDirty = false;
            }

            if (!IsActivated())
            {
                Vector3 curRot = transform.localEulerAngles;
                // hack
                if (curRot.z >= 180)
                {
                    curRot.z -= 360;
                }
                Vector3 targetRot = origRot + deltaRot;
                if (targetRot.z >= 180)
                {
                    targetRot.z -= 360;
                }
                if (Vector3.Distance(curRot, targetRot) > 0.02f)
                {
                    curRot += rotationSpeed * Time.deltaTime * (targetRot - curRot);
                    transform.localEulerAngles = curRot;
                }
            }
        }
    }

    private void OnHoldRelease(Crowd.Event e)
    {
        if (isMouseDown)
        {
            isMouseDown = false;
            deltaRot = new Vector3(0, 0, 0);
        }
    }

    public override void Drag(Vector3 deltaPos)
    {
        base.Drag(deltaPos);

        if (!IsActivated())
        {
            isMouseDown = true;

            float newRotZ = deltaRot.z + deltaPos.x * 100;
            if (newRotZ >= rotationRange.y)
            {
                newRotZ = rotationRange.y;
                if (deltaRot.z < rotationRange.y - 0.1f)
                {
                    onMaxDrag.Invoke();
                }

            }
            else
            if (newRotZ <= rotationRange.x)
            {
                newRotZ = rotationRange.x;
                if (deltaRot.z > rotationRange.x + 0.1f)
                {
                    onMinDrag.Invoke();
                }
            }
            else
            {
                onDrag.Invoke();
            }

            deltaRot = new Vector3(deltaRot.x, deltaRot.y, newRotZ);
        }
    }

    public override void Activate()
    {
        base.Activate();

        isRotDirty = true;
    }
}
