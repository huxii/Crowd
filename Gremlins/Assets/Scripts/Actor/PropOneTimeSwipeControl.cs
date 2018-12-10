using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PropOneTimeSwipeControl : PropOneTimeControl
{
    [Header("Swipe Settings")]
    public Vector3 swipeOffset;
    public UnityEvent onStartSwipe;
    public UnityEvent onReachEnd;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Activate()
    {
        base.Activate();

        Services.gameController.StartSwipe(gameObject);
    }

    public override void Deactivate()
    {
        base.Deactivate();

        Services.gameController.EndSwipe();
    }

    public override void Swipe()
    {
        if (IsReady() && !IsLocked())
        {
            transform.DOMove(transform.position + swipeOffset, 0.5f)
                .OnStart(()=>
                {
                    onStartSwipe.Invoke();
                }
                )
                .OnComplete(() =>
                {
                    FreeAllMen();
                    Lock();
                    onReachEnd.Invoke();

                    Deactivate();
                }
                );
        }
    }
}
