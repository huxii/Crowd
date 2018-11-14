﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// objects will response the mouse action in a certain range,
// which is not related to the collider
public class ObjectRangeBasedControl : ObjectControl
{
    [Header("Mouse Response")]    
    public float maxClickRange = 0f;
    public UnityEvent onClick;
    public float maxRotateScale = 1f;
    public UnityEvent onRightRotate;
    public UnityEvent onLeftRotate;

    // Use this for initialization
    void Start()
    {
        Services.eventManager.Register<ClickEvent>(OnRespondClick);
        Services.eventManager.Register<RotateEvent>(OnRespondRotate);
        Services.eventManager.Register<ZoomEvent>(OnRespondZoom);
    }

    // excute before OnDestroy
    private void OnApplicationQuit()
    {
        Services.eventManager.Unregister<ClickEvent>(OnRespondClick);
        Services.eventManager.Unregister<RotateEvent>(OnRespondRotate);
        Services.eventManager.Unregister<ZoomEvent>(OnRespondZoom);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnRespondClick(Crowd.Event e)
    {
        if (IsCoolingDown() || IsActivated())
        {
            return;
        }

        var clicke = e as ClickEvent;
        GameObject obj = clicke.mouseClickObj;
        Vector3 pos = clicke.mouseClickPos;
        if (Vector3.Distance(transform.position, pos) < maxClickRange)
        {
            onClick.Invoke();
            CoolDown();
        }
    }

    private void OnRespondRotate(Crowd.Event e)
    {
        if (IsCoolingDown() || IsActivated())
        {
            return;
        }

        var clicke = e as RotateEvent;
        float deltaX = clicke.delta.x;
        if (Mathf.Abs(deltaX) < 10f)
        {
            return;
        }

        CoolDown();
        if (deltaX > 0)
        {
            onRightRotate.Invoke();
        }
        else
        {
            onLeftRotate.Invoke();
        }
    }

    private void OnRespondZoom(Crowd.Event e)
    {
        if (IsCoolingDown() || IsActivated())
        {
            return;
        }

        CoolDown();
        onRightRotate.Invoke();
    }
}