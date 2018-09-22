using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    private GameObject mouseClickObject = null;
    private Vector3 mouseClickPos;
    private Vector3 mouseDragPos;
    private bool oneClick = false;
    private float doubleClickTime = 0;
    private float singleClickTime = 0;

    private float doubleClickTolerence = 0.2f;
    private float holdTime = 1f;
    private bool isHoldUp = false;
    private float deltaPinchMag = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DetectMouse()
    {
        if (Time.time - doubleClickTime > doubleClickTolerence)
        {
            // clicked one time but timed out, treated as a single click
            if (oneClick)
            {
                //MouseSingleClick();
                oneClick = false;
            }
        }

        if (Input.touchCount == 1)
        {
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

                if (Time.time - singleClickTime > holdTime)
                {
                    MouseHoldEnd();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                MouseUp();
            }

            // only on PC
            if (Input.GetMouseButton(1))
            {
                MouseRightHold();
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                Zoom(Input.GetAxis("Mouse ScrollWheel"));
            }
        }
        else
        // only on mobile
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touchPrePos0 = touch0.position - touch0.deltaPosition;
            Vector2 touchPrePos1 = touch1.position - touch1.deltaPosition;

            float preMag = (touchPrePos0 - touchPrePos1).magnitude;
            float deltaMag = (touch0.position - touch1.position).magnitude;
            float magDiff = preMag - deltaMag;
            deltaPinchMag += magDiff;

            if (Mathf.Abs(deltaPinchMag) > 200f)
            {
                Zoom(deltaPinchMag);
                deltaPinchMag = 0;
            }
        }
    }

    private void MouseSingleClick()
    {
        Debug.Log("Single click " + mouseClickObject);

        Services.gameController.ClickOn(mouseClickObject, mouseClickPos);
    }

    private void MouseDoubleClick()
    {
        //Debug.Log("Double click " + mouseClickObject);

        //Services.gameController.DoubleClickOn(mouseClickObject);
    }

    private void MouseDown()
    {
        isHoldUp = false;
        mouseDragPos = Input.mousePosition;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            mouseClickObject = hit.collider.gameObject;
            mouseClickPos = hit.point;
        }
        else
        {
            mouseClickObject = null;
        }

        Services.gameController.HoldStart(mouseClickObject);
    }

    private void MouseUp()
    {
        if (Time.time - singleClickTime < 0.5f)
        {
            MouseSingleClick();
        }

        isHoldUp = true;
        Services.gameController.HoldRelease(mouseClickObject);
    }

    private void MouseHoldEnd()
    {
        if (isHoldUp)
        {
            return;
        }

        Debug.Log("Hold " + mouseClickObject);

        isHoldUp = true;
        Services.gameController.HoldEnd(mouseClickObject);
    }

    private void MouseHold()
    {
        if (mouseClickObject == null)
        {
            TranslateViewport();
        }
        else
        {
            // drag object
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Vector3 newMouseClickPos = hit.point;
                Vector3 mouseDelta = newMouseClickPos - mouseClickPos;

                if (mouseClickObject.CompareTag("Object"))
                {
                    Services.gameController.DragOn(mouseClickObject, mouseDelta);
                }
                else
                {
                    TranslateViewport();
                }

                mouseClickPos = newMouseClickPos;
            }
        }
    }

    private void MouseRightHold()
    {
        RotateViewport();
    }

    public void TranslateViewport()
    {
        Vector3 mouseDelta = (Input.mousePosition - mouseDragPos) * Time.time;
        Services.cameraController.Translate(mouseDelta.x * 0.03f, mouseDelta.y * 0.03f);
        mouseDragPos = Input.mousePosition;
    }

    public void RotateViewport()
    {            
        // rotate viewport
        Vector3 mouseDelta = (Input.mousePosition - mouseDragPos) * Time.time;
        //Debug.Log(mouseDelta);
        Services.cameraController.Orbit(mouseDelta.x, mouseDelta.y);
        mouseDragPos = Input.mousePosition;
    }

    public void Zoom(float delta)
    {
        Debug.Log("Pinch " + delta);
        Services.cameraController.Zoom(delta);
    }
}
