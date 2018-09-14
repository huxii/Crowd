using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    private GameObject selectedMan = null;
    private GameObject mouseClickObject = null;
    private Vector3 mouseClickPos;
    private Vector3 mouseDragPos;
    private bool oneClick = false;
    private float doubleClickTime = 0;
    private float singleClickTime = 0;

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
        if (Time.time - doubleClickTime > 0.3f)
        {
            // clicked one time but timed out, treated as a single click
            if (oneClick)
            {
                MouseSingleClick();
                oneClick = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseDragPos = Input.mousePosition;
            singleClickTime = Time.time;

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
                if (Time.time - singleClickTime < 0.3f)
                {
                    oneClick = true;
                }

                doubleClickTime = Time.time;
            }
        }

        if (Input.GetMouseButton(0))
        {
            MouseDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            // mouse up
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Services.cameraController.Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    private void MouseSingleClick()
    {
        if (mouseClickObject == null)
        {
            DeselectMan();
            return;
        }

        Debug.Log("Single click " + mouseClickObject);
        if (mouseClickObject.CompareTag("Man"))
        {
            SelectMan(mouseClickObject);
        }
        else
        if (mouseClickObject.CompareTag("Object"))
        {
            if (selectedMan)
            {
                MoveMan(selectedMan, mouseClickPos);
            }
        }
        else
        {
            if (selectedMan)
            {
                MoveMan(selectedMan, mouseClickPos);
            }
        }
    }

    private void MouseDoubleClick()
    {
        if (mouseClickObject == null)
        {
            return;
        }

        Debug.Log("Double click " + selectedMan + " " + mouseClickObject);
        if (selectedMan && mouseClickObject.CompareTag("Object"))
        {
            FillMan(selectedMan, mouseClickObject);
        }
    }

    private void MouseDrag()
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
                Vector3 newMouseClickPos = hit.point;
                Vector3 mouseDelta = newMouseClickPos - mouseClickPos;

                if (mouseClickObject.GetComponent<ObjectControl>())
                {
                    mouseClickObject.GetComponent<ObjectControl>().Drag(mouseDelta);
                }

                mouseClickPos = newMouseClickPos;
            }
            else
            {
                RotateViewport();
            }
        }
    }

    public void RotateViewport()
    {            
        // rotate viewport
        Vector3 mouseDelta = (Input.mousePosition - mouseDragPos) * Time.time;
        //Debug.Log(mouseDelta);
        Services.cameraController.Orbit(mouseDelta.x, mouseDelta.y);
        mouseDragPos = Input.mousePosition;
    }

    public void SelectMan(GameObject man)
    {
        DeselectMan();

        selectedMan = man;
        selectedMan.GetComponent<CrowdControl>().Selected();
    }

    public void DeselectMan()
    {
        if (selectedMan == null)
        {
            return;
        }
        selectedMan.GetComponent<CrowdControl>().Deselected();
        selectedMan = null;
    }

    public void FillMan(GameObject man, GameObject obj)
    {
        int slotId = obj.GetComponent<ObjectControl>().FindEmptySlot();
        if (slotId == -1)
        {
            return;
        }

        if (Services.pathFindingManager.FindPath(man, obj.GetComponent<ObjectControl>().GetSlotPos(slotId)))
        {
            UnboundMan(man);
            Services.pathFindingManager.Move(man, 5, new ManLeavesForObj(man, obj, slotId), new ManArrivesAtObj(man, obj, slotId));
        }
    }

    public void UnboundMan(GameObject man)
    {
        Services.eventManager.QueueEvent(new ManLeavesFromObj(man));
    }

    public void MoveMan(GameObject man, Vector3 targetPos)
    {
        if (Services.pathFindingManager.FindPath(man, targetPos))
        {
            UnboundMan(man);
            Services.pathFindingManager.Move(man);
        }
    }

    public GameObject SelectedMan()
    {
        return selectedMan;
    }
}
