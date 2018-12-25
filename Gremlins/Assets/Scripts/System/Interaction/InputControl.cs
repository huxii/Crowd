using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputControl : MonoBehaviour
{
    public bool resetCenterOnRelease = true;
    public bool gyroEnabled = false;

    protected bool locked = false;

    // single click
    protected GameObject mouseClickObject = null;
    protected Vector3 mouseClickPos;
    protected float singleClickTime = 0;

    // double click
    protected float doubleClickTime = 0;
    protected float doubleClickTolerence = 0.2f;
    protected bool oneClick = false;

    // hold 
    protected float holdTime = 1f;

    // drag
    protected Vector3 mouseDragScreenPos;
    protected Vector3 mouseClickScreenPos;
    protected float dragTimer = 0;
    private float dragCoolDown = 0.3f;

    // pinch
    protected bool pinchEnded = false;
    protected float deltaPinchMag = 0;

    protected bool autoFocusCameraEnabled = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void CoolDown()
    {
        if (dragTimer > 0)
        {
            dragTimer -= Time.deltaTime;
        }
    }

    protected void DetectMouse()
    {
        if (locked)
        {
            return;
        }

        if (Input.touchCount < 2)
        {
            if (Time.time - doubleClickTime > doubleClickTolerence)
            {
                // clicked one time but timed out, treated as a single click
                if (oneClick)
                {
                    oneClick = false;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                singleClickTime = Time.time;

                MouseDown();
            }

            if (Input.GetMouseButtonUp(0))
            {
                // get a second click before it's timed out, treated as a double click
                if (oneClick)
                {
                    MouseDoubleClick();
                    oneClick = false;
                }
                else
                {
                    // when it's not a drag
                    if (Time.time - singleClickTime < doubleClickTolerence)
                    {
                        oneClick = true;
                    }

                    doubleClickTime = Time.time;
                }
            }

            if (Input.GetMouseButton(0))
            {
                MouseHold();
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                MouseUp();
            }
        }
        //else
        //if (Input.touchCount == 2)
        //{
        //    Touch touch0 = Input.GetTouch(0);
        //    Touch touch1 = Input.GetTouch(1);
        //    switch (touch0.phase)
        //    {
        //        case TouchPhase.Began:
        //            pinchEnded = false;
        //            deltaPinchMag = 0;
        //            break;
        //        case TouchPhase.Moved:
        //            if (!pinchEnded)
        //            {
        //                Vector2 touchPrePos0 = touch0.position - touch0.deltaPosition;
        //                Vector2 touchPrePos1 = touch1.position - touch1.deltaPosition;

        //                float preMag = (touchPrePos0 - touchPrePos1).magnitude;
        //                float deltaMag = (touch0.position - touch1.position).magnitude;
        //                float magDiff = deltaMag - preMag;
        //                deltaPinchMag += magDiff;

        //                if (Mathf.Abs(deltaPinchMag) > 1f)
        //                {
        //                    Zoom(deltaPinchMag);
        //                    pinchEnded = true;
        //                }
        //            }
        //            break;
        //        case TouchPhase.Ended:
        //            pinchEnded = false;
        //            deltaPinchMag = 0;
        //            break;
        //        default:
        //            pinchEnded = false;
        //            deltaPinchMag = 0;
        //            break;
        //    }
        //}


        // only on PC
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButton(1))
            {
                TranslateViewport();
            }

            if (Input.GetMouseButtonUp(1))
            {
                if (resetCenterOnRelease)
                {
                    ResetTranslateViewport();
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                Zoom(Input.GetAxis("Mouse ScrollWheel"));
            }
        }

        if (gyroEnabled)
        {
            Services.cameraController.Orbit(Input.acceleration.x * 2500f, (Input.acceleration.y + 0.5f) * 1500f);
        }
    }

    private void MouseDown()
    {
        mouseDragScreenPos = Input.mousePosition;
        mouseClickScreenPos = Input.mousePosition;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 200f))
        {
            mouseClickObject = hit.collider.gameObject;
            mouseClickPos = hit.point;
        }
        else
        {
            mouseClickObject = null;
        }

        //Services.gameController.HoldStart(mouseClickObject);
    }

    private void MouseUp()
    {
        if (Vector3.Distance(Input.mousePosition, mouseClickScreenPos) > 1f)
        {
            Services.gameController.Swipe();
            //Services.gameController.SwipeOn(mouseClickObject);
        }
        else
        //if (Time.time - singleClickTime < 1f)
        {
            MouseSingleClick();
        }

        Services.eventManager.Fire(new ReleaseEvent());
        //Services.hudController.DestroyHoldIcon(mouseClickObject);
    }

    protected virtual void MouseSingleClick()
    {
        //Debug.Log("Single click " + mouseClickObject + " " + mouseClickPos);
        if (autoFocusCameraEnabled)
        {
            Services.gameController.FocusCamera(mouseClickPos);
        }

        Services.eventManager.Fire(new ClickEvent(mouseClickObject, mouseClickPos));
    }

    protected virtual void MouseDoubleClick()
    {
        //Debug.Log("Double click " + mouseClickObject);

        //Services.gameController.DoubleClickOn(mouseClickObject);
    }

    protected virtual void MouseHold()
    {
        if (mouseClickObject == null)
        {
            RotateViewport();
        }
        else
        {
            // drag object
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Vector3 mouseDelta = Input.mousePosition - mouseDragScreenPos;
                if ((mouseClickObject.CompareTag("Object") || mouseClickObject.CompareTag("Prop"))
                    && Services.gameController.DragOn(mouseClickObject, mouseDelta))
                {
                    mouseDragScreenPos = Input.mousePosition;
                }
                else
                {
                    RotateViewport();
                }
            }
        }
    }

    protected void TranslateViewport(float x, float y)
    {
        if (Services.cameraController == null)
        {
            return;
        }

        Services.cameraController.Translate(x, y);
    }

    protected void TranslateViewport()
    {
        Vector3 mouseDelta = Input.mousePosition - mouseDragScreenPos;
        if (mouseDelta.magnitude > 0.1f)
        {
            // kind of buggy there...
            TranslateViewport(mouseDelta.x * 0.3f, mouseDelta.y * 0.3f);
            mouseDragScreenPos = Input.mousePosition;
        }
    }

    protected void ResetTranslateViewport()
    {
        Services.cameraController.ResetTranslate();
    }

    protected void RotateViewport()
    {
        if (Services.cameraController == null)
        {
            return;
        }

        // rotate viewport
        Vector3 mouseDelta = Input.mousePosition - mouseDragScreenPos;
        if (mouseDelta.magnitude > 0.1f)
        {
            //Debug.Log(mouseDelta);
            Vector2 delta = Services.cameraController.Orbit(mouseDelta.x, mouseDelta.y);
            mouseDragScreenPos = Input.mousePosition;

            Services.eventManager.Fire(new RotateEvent(delta));
        }
    }

    protected void Zoom(float delta)
    {
        if (Services.cameraController == null)
        {
            return;
        }

        //Debug.Log("Pinch " + delta);
        Services.cameraController.Zoom(delta);
    }

    public void Lock(bool isLocked)
    {
        locked = isLocked;
    }

    public void SetAutoFocusCamera(bool en)
    {
        autoFocusCameraEnabled = en;
    }
}
