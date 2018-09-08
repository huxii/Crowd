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
        RegisterEvents();

        crowd = GameObject.FindGameObjectsWithTag("Man");
    }

    // Update is called once per frame
    void Update()
    {
        Services.eventManager.ProcessQueuedEvents();
        Services.taskManager.Update();

        DetectMouse();
    }

    void OnDestroy()
    {
        UnregisterEvents();   
    }

    void RegisterEvents()
    {
        Services.eventManager.Register<ManArrivesAtObj>(OnManArrivesAtObj);
        Services.eventManager.Register<ManLeavesForObj>(OnManLeavesForObj);
        Services.eventManager.Register<ManLeavesFromObj>(OnManLeavesFromObj);
    }

    void UnregisterEvents()
    {
        Services.eventManager.Unregister<ManArrivesAtObj>(OnManArrivesAtObj);
        Services.eventManager.Unregister<ManLeavesForObj>(OnManLeavesForObj);
        Services.eventManager.Unregister<ManLeavesFromObj>(OnManLeavesFromObj);
    }

    void OnManArrivesAtObj(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrivesAtObj;
        GameObject man = manArrivedEvent.man;
        GameObject obj = manArrivedEvent.obj;
        int slotId = manArrivedEvent.slotId;

        man.transform.SetParent(obj.transform);
        selectedMan = null;
        obj.GetComponent<ObjectControl>().ReadySlot(slotId, man);
    }

    void OnManLeavesForObj(Crowd.Event e)
    {
        var manLeftForEvent = e as ManLeavesForObj;
        GameObject man = manLeftForEvent.man;
        GameObject obj = manLeftForEvent.obj;
        int slotId = manLeftForEvent.slotId;

        obj.GetComponent<ObjectControl>().PlanSlot(slotId);
    }

    void OnManLeavesFromObj(Crowd.Event e)
    {
        var manLeftFromEvent = e as ManLeavesFromObj;
        GameObject man = manLeftFromEvent.man;
        GameObject obj = manLeftFromEvent.obj;
        int slotId = manLeftFromEvent.slotId;

        man.transform.SetParent(null);
        obj.GetComponent<ObjectControl>().FreeSlot(slotId);
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

        Debug.Log("Double click");
        if (selectedMan && mouseClickObject.CompareTag("Object"))
        {
            FillMan(selectedMan, mouseClickObject);
        }
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

    public void FillMan(GameObject man, GameObject obj)
    {
        int slotId = obj.GetComponent<ObjectControl>().FindEmptySlot();
        if (slotId == -1)
        {
            return;
        }

        GameObject origObj = null;
        if (man.transform.parent != null)
        {
            origObj = man.transform.parent.gameObject;
        }

        if (Services.pathFindingManager.GoTo(man, obj.GetComponent<ObjectControl>().GetSlotPos(slotId), 5, new ManLeavesForObj(man, obj, slotId), new ManArrivesAtObj(man, obj, slotId)))
        {            
            if (origObj != null && origObj.CompareTag("Object"))
            {
                int origSlotId = origObj.GetComponent<ObjectControl>().GetSlotId(man);
                if (origSlotId != -1)
                {
                    Services.eventManager.QueueEvent(new ManLeavesFromObj(man, origObj, origSlotId));
                }
            }
        }
    }

    public void MoveMan(GameObject man, Vector3 targetPos)
    {
        GameObject origObj = null;
        if (man.transform.parent != null)
        {
            origObj = man.transform.parent.gameObject;
        }
        if (Services.pathFindingManager.GoTo(man, targetPos))
        {            
            if (origObj != null && origObj.CompareTag("Object"))
            {
                int origSlotId = origObj.GetComponent<ObjectControl>().GetSlotId(man);
                if (origSlotId != -1)
                {
                    Services.eventManager.QueueEvent(new ManLeavesFromObj(man, origObj, origSlotId));
                }
            }
        }
    }
}
