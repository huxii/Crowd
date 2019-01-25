using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDragControl : ObjectBasicControl
{
    public enum Axis
    {
        RX,
        RY,
        RZ,
        TX,
        TY,
        TZ
    };

    public UnityEvent onDrag;
    public UnityEvent onMinDrag;
    public UnityEvent onMaxDrag;

    public Axis dragAxis = Axis.RX;
    public float speed = 10f;
    public Vector2 range = new Vector2(0, 0);
    public bool isAxisRevert = false;
    public bool isSnappingBack = false;

    Vector3 origValue = new Vector3(0, 0, 0);
    Vector3 deltaValue = new Vector3(0, 0, 0);
    bool isDirty = true;
    bool isMinReached = false;
    bool isMaxReached = false;
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
            if (isDirty)
            {
                if (dragAxis <= Axis.RZ)
                {
                    origValue = transform.localEulerAngles;
                }
                else
                {
                    origValue = transform.localPosition;
                }

                if (isSnappingBack)
                {
                    deltaValue = new Vector3(0, 0, 0);
                }
                isDirty = false;
                isMinReached = false;
                isMaxReached = false;
            }

            if (!IsActivated() && !IsLocked())
            {
                float newDelta;
                float curDelta;
                if (dragAxis <= Axis.RZ)
                {
                    Vector3 curRot = transform.localEulerAngles;
                    Vector3 targetRot = origValue + deltaValue;
                    curDelta = (curRot - origValue)[(int)dragAxis];
                    targetRot[(int)dragAxis] = Services.utils.LerpRotation(curRot[(int)dragAxis], targetRot[(int)dragAxis], speed);
                    transform.localEulerAngles = targetRot;
                    newDelta = (targetRot - origValue)[(int)dragAxis];
                }
                else
                {
                    Vector3 curPos = transform.localPosition;
                    Vector3 targetPos = origValue + deltaValue;
                    curDelta = (curPos - origValue)[(int)dragAxis - 3];
                    targetPos = Vector3.Lerp(curPos, targetPos, speed * Time.deltaTime);
                    transform.localPosition = targetPos;
                    newDelta = (targetPos - origValue)[(int)dragAxis - 3];
                }

                
                if (newDelta >= range.y - 0.1f)
                {
                    if (!isMaxReached)
                    {
                        onMaxDrag.Invoke();
                        isMaxReached = true;
                    }
                }
                else
                if (newDelta <= range.x + 0.1f)
                {
                    if (!isMinReached)
                    {
                        onMinDrag.Invoke();
                        isMinReached = true;
                    }
                }
                else
                {
                    if (Mathf.Abs(curDelta - newDelta) >= 0.05f)
                    {
                        onDrag.Invoke();
                        isMaxReached = false;
                        isMinReached = false;
                    }
                }
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
                deltaValue = new Vector3(0, 0, 0);
            }
        }
    }

    public void SetAngle(float angle)
    {
        if (dragAxis > Axis.RZ)
        {
            return;
        }

        deltaValue[(int)dragAxis] = Mathf.Max(Mathf.Min(angle, range.y), range.x);
        //transform.localEulerAngles = origValue + deltaValue;
        origValue = origValue + deltaValue;
        deltaValue = new Vector3(0, 0, 0);
    }

    public override void Drag(Vector3 deltaPos)
    {
        base.Drag(deltaPos);

        if (!IsLocked() && !IsActivated())
        {
            isMouseDown = true;

            float curValue = 0;
            if (dragAxis <= Axis.RZ)
            {
                curValue = deltaValue[(int)dragAxis];
            }
            else
            {
                curValue = deltaValue[(int)dragAxis - 3];
            }

            float newValue = curValue;
            float deltaPosValue;
            if (dragAxis == Axis.RX || dragAxis == Axis.RY || dragAxis == Axis.TX)
            {
                deltaPosValue = deltaPos.x;
            }
            else
            {
                deltaPosValue = deltaPos.y;
            }

            if (isAxisRevert)
            {
                newValue -= deltaPosValue * 100;
            }
            else
            {
                newValue += deltaPosValue * 100;
            }

            newValue = Mathf.Min(range.y, Mathf.Max(range.x, newValue));

            if (dragAxis <= Axis.RZ)
            {
                deltaValue[(int)dragAxis] = newValue;
            }
            else
            {
                deltaValue[(int)dragAxis - 3] = newValue;
            }
        }
    }

    public override void Activate()
    {
        base.Activate();

        isDirty = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        isDirty = true;
    }

    public override bool IsDragOverride()
    {
        return IsLocked();
    }
}
