using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDragControl : ObjectBasicControl
{
    public enum Axis
    {
        X,
        Y,
        Z
    };

    public UnityEvent onDrag;
    public UnityEvent onMinDrag;
    public UnityEvent onMaxDrag;

    public Axis rotationAxis = Axis.X;
    public float rotationSpeed = 10f;
    public Vector2 rotationRange = new Vector2(0, 0);
    public bool isAxisRevert = false;
    public bool isSnappingBack = false;

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
                if (isSnappingBack)
                {
                    deltaRot = new Vector3(0, 0, 0);
                }
                isRotDirty = false;
            }

            if (!IsActivated() && !IsLocked())
            {
                Vector3 curRot = transform.localEulerAngles;
                Vector3 targetRot = origRot + deltaRot;
                targetRot[(int)rotationAxis] = Services.utils.LerpRotation(curRot[(int)rotationAxis], targetRot[(int)rotationAxis], rotationSpeed);
                transform.localEulerAngles = targetRot;
            }
        }
    }

    private void OnHoldRelease(Crowd.Event e)
    {
        if (isMouseDown)
        {
            isMouseDown = false;
            if (isSnappingBack)
            {
                deltaRot = new Vector3(0, 0, 0);
            }
        }
    }

    public void SetAngle(float angle)
    {
        deltaRot[(int)rotationAxis] = Mathf.Max(Mathf.Min(angle, rotationRange.y), rotationRange.x);
    }

    public override void Drag(Vector3 deltaPos)
    {
        base.Drag(deltaPos);

        if (!IsLocked() && !IsActivated())
        {
            isMouseDown = true;

            float curValue = deltaRot[(int)rotationAxis];
            float newValue = curValue;
            if (isAxisRevert)
            {
                newValue -= deltaPos.x * 100;
            }
            else
            {
                newValue += deltaPos.x * 100;
            }

            if (newValue >= rotationRange.y)
            {
                newValue = rotationRange.y;
                if (curValue < rotationRange.y - 0.1f)
                {
                    onMaxDrag.Invoke();
                }

            }
            else
            if (newValue <= rotationRange.x)
            {
                newValue = rotationRange.x;
                if (curValue > rotationRange.x + 0.1f)
                {
                    onMinDrag.Invoke();
                }
            }
            else
            {
                if (Mathf.Abs(newValue - curValue) >= 0.1f)
                {
                    onDrag.Invoke();
                }
            }

            deltaRot[(int)rotationAxis] = newValue;
        }
    }

    public override void Activate()
    {
        base.Activate();

        isRotDirty = true;
    }

    public override bool IsDragOverride()
    {
        return false;
    }
}
