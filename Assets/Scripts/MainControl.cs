using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// how to attach a task to a object (structure or xml)
// AI: pathfinding

public class MainControl : MonoBehaviour
{
    private GameObject[] crowd;
    private GameObject selectedMan = null;

    private GameObject mouseClickObject = null;
    private Vector3 mouseClickPos;
    private bool oneClick = false;
    private float doubleClickTime = 0;

    // Use this for initialization
    void Start()
    {
        crowd = GameObject.FindGameObjectsWithTag("Man");
    }

    // Update is called once per frame
    void Update()
    {
        Services.eventManager.ProcessQueuedEvents();
        Services.taskManager.Update();

        DetectMouse();
    }

    private void DetectMouse()
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
            // get a second click before it's timed out, treated as a double click
            if (oneClick)
            {
                MouseDoubleClick();
                oneClick = false;
            }
            else
            {
                oneClick = true;
                doubleClickTime = Time.time;

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    mouseClickObject = hit.collider.gameObject;
                    mouseClickPos = hit.point;
                }
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
    }

    private void MouseSingleClick()
    {
        if (mouseClickObject == null)
        {
            return;
        }

        Debug.Log("Single click");
        if (mouseClickObject.CompareTag("Man"))
        {
            SelectMan(mouseClickObject);
        }
        else
        if (mouseClickObject.CompareTag("Object"))
        {
            if (selectedMan)
            {
                Services.pathFindingManager.GoTo(selectedMan, mouseClickPos);
            }
        }
        else
        {
            if (selectedMan)
            {
                Services.pathFindingManager.GoTo(selectedMan, mouseClickPos);
            }
        }
    }

    private void MouseDoubleClick()
    {
        if (mouseClickObject == null)
        {
            return;
        }

        Debug.Log("Double click");
    }

    private void MouseDrag()
    {
        if (mouseClickObject == null)
        {
            return;
        }

        // mouse hold
        if (mouseClickObject.GetComponent<ObjectControl>())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Vector3 newMouseClickPos = hit.point;
                mouseClickObject.GetComponent<ObjectControl>().Drag(newMouseClickPos - mouseClickPos);
                mouseClickPos = newMouseClickPos;
            }
        }
    }

    public void SelectMan(GameObject man)
    {
        selectedMan = man;
    }

    //public void RequestNewMan(GameObject obj)
    //{
    //    if (selectedMan == null)
    //    {
    //        return;
    //    }

    //    Services.pathFindingManager.GoTo(selectedMan, obj);
    //}
}
