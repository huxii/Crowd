using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputControl : MonoBehaviour
{
    public bool autoFocusCameraEnabled = false;
    public bool resetCenterOnRelease = true;
    public bool groundEnabled = true;
    public bool gyroEnabled = false;

    protected bool locked = false;
    protected float coolDownTimer = 0;
    protected float coolDown = 0.3f;

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

    // pinch
    protected bool pinching = false;
    protected float deltaPinchMag = 0;
    protected float maxPinchMag = 15;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (!locked && coolDownTimer <= 0)
        {
            DetectMouse();
            DetectMousePC();

            if (gyroEnabled)
            {
                Services.cameraController.Orbit(Input.acceleration.x * 2500f, (Input.acceleration.y + 0.5f) * 1500f);
            }
        }
    }

    protected void CoolDown()
    {
        coolDownTimer = coolDown;
    }

    protected virtual void DetectMouse()
    {
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
    }

    private void DetectMousePC()
    {
        // only on PC
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            if (Input.touchCount < 2)
            {
                if (Input.GetMouseButton(1))
                {
                    TranslateViewport();
                }

                if (Input.GetMouseButtonUp(1))
                {
                    if (resetCenterOnRelease)
                    {
                        Services.cameraController.ResetTranslate();
                    }
                }

                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    Zoom(Input.GetAxis("Mouse ScrollWheel"));
                }
            }

            //if (Input.GetMouseButtonDown(2))
            //{
            //    Vector3 pos = Camera.main.ScreenToWorldPoint(
            //        new Vector3(
            //            Input.mousePosition.x, 
            //            Input.mousePosition.y, 
            //            Vector3.Distance(Camera.main.transform.position, GameObject.Find("Pivots").transform.position)
            //            )
            //        );
            //    Services.cameraController.SetTranslate(pos.x, pos.y);
            //    Services.cameraController.SetZoom(-15f);
            //    //Debug.Log(pos);
            //}

            //if (Input.GetMouseButtonUp(2))
            //{
            //    Services.cameraController.ResetTranslate();
            //    Services.cameraController.ResumeZoom();
            //}
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
            //Services.gameEvents.Swipe();
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
                    && Services.gameEvents.DragOn(mouseClickObject, mouseDelta, mouseClickPos))
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
