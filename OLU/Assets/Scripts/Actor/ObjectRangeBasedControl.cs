using System.Collections;
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

    // Update is called once per frame
    void Update()
    {

    }

    protected override void RegisterEvents()
    {
        Services.eventManager.Register<ClickEvent>(OnRespondClick);
        Services.eventManager.Register<RotateEvent>(OnRespondRotate);
        Services.eventManager.Register<ZoomEvent>(OnRespondZoom);
    }

    protected override void UnregisterEvents()
    {
        Services.eventManager.Unregister<ClickEvent>(OnRespondClick);
        Services.eventManager.Unregister<RotateEvent>(OnRespondRotate);
        Services.eventManager.Unregister<ZoomEvent>(OnRespondZoom);
    }

    protected void OnRespondClick(Crowd.Event e)
    {
        if (IsLocked() || IsCoolingDown() || IsActivated())
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

    protected void OnRespondRotate(Crowd.Event e)
    {
        if (IsLocked() || IsCoolingDown() || IsActivated())
        {
            return;
        }

        var clicke = e as RotateEvent;
        float deltaX = clicke.delta.x;
        if (Mathf.Abs(deltaX) < 5f)
        {
            return;
        }

        if (deltaX > 0)
        {
            onRightRotate.Invoke();
        }
        else
        {
            onLeftRotate.Invoke();
        }

        CoolDown();
    }

    protected void OnRespondZoom(Crowd.Event e)
    {
        if (IsLocked() || IsCoolingDown() || IsActivated())
        {
            return;
        }

        onRightRotate.Invoke();
        CoolDown();
    }
}
