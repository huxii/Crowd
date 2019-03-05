using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ASRBehavior))]
public class PropOneTimeDragControl : PropOneTimeControl
{
    public enum DragAxis
    {
        X,
        Y
    };

    [Header("Drag Settings")]
    public DragAxis dragAxis;
    public float dragOffset;
    public UnityEvent onDragging;
    public UnityEvent onReachEnd;

    protected float deltaOffset;
    protected Vector3 origPos;
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
    protected override void Start ()
    {
        base.Start();

        origPos = transform.position;
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
    void Update ()
    {
        if (!IsLocked())
        {
            Vector3 targetPos = origPos;
            targetPos[(int)dragAxis] += deltaOffset;
            Vector3 newPos = transform.position;
            // only invoke onDragging when it's actually being dragged
            if (Vector3.Distance(targetPos, newPos) > 0.001f)
            {
                if (!isMoving)
                {
                    isMoving = true;
                    asr.Attack();
                }

                newPos = Vector3.Lerp(newPos, targetPos, Time.deltaTime * speed);
                transform.position = newPos;

                //if (Vector3.Distance(targetPos, newPos) > 0.05f)
                //{
                //    onDragging.Invoke();
                //}

                // syncing animation
                Services.eventManager.Fire(new DragEvent(deltaOffset / dragOffset));
            }
            else
            {
                if (isMoving)
                {
                    isMoving = false;
                    asr.Release();
                }

                Vector3 finalPos = origPos;
                finalPos[(int)dragAxis] += dragOffset;

                // has reached the end
                if (Vector3.Distance(newPos, finalPos) < 0.001f)
                {
                    onReachEnd.Invoke();
                    FreeAllMen();
                    Lock();

                    asr.End();
                }
                else
                {
                    if (IsActivated())
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

            deltaOffset = Mathf.Min(Mathf.Max(minDelta, deltaOffset + Mathf.Min(d[(int)dragAxis], 0.5f)), maxDelta);
        }
    }
}
