using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ASRBehavior))]
public class PropOneTimeDragControl : PropOneTimeControl
{
    public enum DragAxis
    {
        TX,
        TY,
        RX,
        RY
    };

    [Header("Drag Settings")]
    public DragAxis dragAxis;
    public float dragOffset;
    //public UnityEvent onDragging;
    public UnityEvent onReachEnd;

    protected float deltaOffset;
    protected Vector3 origPos;
    protected Vector3 origRot;
    protected float minDelta;
    protected float maxDelta;
    protected float speed = 5f;
    protected float hintTimer;
    protected float hintCD = 3f;

    protected bool isDragging = false;
    protected bool isMoving = false;
    protected ASRBehavior asr = null;

    // on dragging for sound effect
    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        origPos = transform.position;
        origRot = transform.localEulerAngles;
        deltaOffset = 0;

        minDelta = 0;
        maxDelta = dragOffset;
        if (minDelta > maxDelta)
        {
            minDelta = maxDelta;
            maxDelta = 0;
        }

        hintTimer = 1f;

        asr = GetComponent<ASRBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsLocked())
        {
            Vector3 targetValue;
            Vector3 newValue;
            if (dragAxis <= DragAxis.TY)
            {
                targetValue = origPos;
                targetValue[(int)dragAxis] += deltaOffset;
                newValue = transform.position;
            }
            else
            {
                targetValue = origRot;
                targetValue[(int)dragAxis - 2] += deltaOffset;
                newValue = transform.localEulerAngles;
            }

            // only invoke onDragging when it's actually being dragged
            if (Vector3.Distance(targetValue, newValue) > 0.001f)
            {
                if (!isMoving)
                {
                    isMoving = true;
                    asr.Attack();
                }
                else
                {
                    asr.Sustain();
                }
                
                newValue = Vector3.Lerp(newValue, targetValue, Time.deltaTime * speed);
                if (dragAxis <= DragAxis.TY)
                {
                    transform.position = newValue;
                }
                else
                {
                    transform.localEulerAngles = newValue;
                }

                //if (Vector3.Distance(targetPos, newPos) > 0.05f)
                //{
                //    onDragging.Invoke();
                //}

                if (dragAxis <= DragAxis.TY)
                {
                    // syncing animation
                    Services.eventManager.Fire(new PropDragEvent(Mathf.Abs((newValue[(int)dragAxis] - origPos[(int)dragAxis]) / dragOffset)));
                }
                else
                {
                    // syncing animation
                    Services.eventManager.Fire(new PropDragEvent(Mathf.Abs((newValue[(int)dragAxis - 2] - origRot[(int)dragAxis - 2]) / dragOffset)));
                }
            }
            else
            {
                if (isMoving)
                {
                    isMoving = false;
                    asr.Release();
                }

                Vector3 finalValue;
                if (dragAxis <= DragAxis.TY)
                {
                    finalValue = origPos;
                    finalValue[(int)dragAxis] += dragOffset;
                }
                else
                {
                    finalValue = origRot;
                    finalValue[(int)dragAxis - 2] += dragOffset;
                }

                // has reached the end
                if (Vector3.Distance(newValue, finalValue) < 0.001f)
                {
                    onReachEnd.Invoke();
                    FreeAllMen();
                    Lock();

                    asr.End();
                }
                else
                {
                    if (IsActivated() && !isDragging)
                    {
                        // automatically shake a little bit to indicate dragging
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

    protected override void RegisterEvents()
    {
        Services.eventManager.Register<ReleaseEvent>(OnRelease);
    }

    protected override void UnregisterEvents()
    {
        Services.eventManager.Unregister<ReleaseEvent>(OnRelease);
    }

    protected void OnRelease(Crowd.Event e)
    {
        if (isDragging)
        {
            isDragging = false;
            Services.dotweenEvents.ScaleTo(GetComponent<PropFeedbackBehavior>().targetObj.name + " 1, 1, 1, 0.5");
            if (Mathf.Abs(deltaOffset) < Mathf.Abs(dragOffset))
            {
                deltaOffset = 0;
            }
        }
    }

    public override void Drag(Vector3 d, Vector3 mouseClickPos)
    {
        if (!IsCoolingDown() && IsActivated() && !IsLocked())
        {
            base.Drag(d, mouseClickPos);

            if (!isDragging)
            {
                isDragging = true;
                Services.dotweenEvents.ScaleTo(GetComponent<PropFeedbackBehavior>().targetObj.name + " 1.1, 1.1, 1.1, 0.5");
            }

            float delta = 0;
            if (dragAxis <= DragAxis.TY)
            {
                delta = d[(int)dragAxis];
                if (Mathf.Abs(delta) > 0.5f)
                {
                    delta = Mathf.Sign(delta) * 0.5f;
                }              
            }
            else
            {
                Debug.Log(d);
                delta = (d[0] + d[1]) * 8;
                if (Mathf.Abs(delta) > 8)
                {
                    delta = Mathf.Sign(delta) * 8;
                }
            }
            deltaOffset = Mathf.Min(Mathf.Max(minDelta, deltaOffset + delta), maxDelta);
        }
    }
}
