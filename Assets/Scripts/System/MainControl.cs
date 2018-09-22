using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// TODO: zoom in/zoom out and open lids & hold icon & ferris wheel models

public class MainControl : MonoBehaviour
{
    private GameObject selectedMan = null;
    private GameObject menObj = null;

    // Use this for initialization
    void Start()
    {
        menObj = GameObject.Find("Actors");

        RegisterEvents();

        // do a favor for outline shader
        Services.utils.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        Services.eventManager.ProcessQueuedEvents();
        Services.taskManager.Update();
        Services.inputController.DetectMouse();
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
        Services.eventManager.Register<ManAcrossBorder>(OnManAcrossBorder);
    }

    void UnregisterEvents()
    {
        Services.eventManager.Unregister<ManArrivesAtObj>(OnManArrivesAtObj);
        Services.eventManager.Unregister<ManLeavesForObj>(OnManLeavesForObj);
        Services.eventManager.Unregister<ManLeavesFromObj>(OnManLeavesFromObj);
        Services.eventManager.Unregister<ManAcrossBorder>(OnManAcrossBorder);
    }

    void OnManArrivesAtObj(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrivesAtObj;
        GameObject man = manArrivedEvent.man;
        GameObject obj = manArrivedEvent.obj;
        int slotId = manArrivedEvent.slotId;

        man.transform.SetParent(obj.GetComponent<ObjectPrimaryControl>().GetSlotObject(slotId).transform);
        obj.GetComponent<ObjectPrimaryControl>().ReadySlot(slotId, man);

        if (man == selectedMan)
        {
            DeselectMan();
        }
    }

    void OnManLeavesForObj(Crowd.Event e)
    {
        var manLeftForEvent = e as ManLeavesForObj;
        GameObject man = manLeftForEvent.man;
        GameObject obj = manLeftForEvent.obj;
        int slotId = manLeftForEvent.slotId;

        man.GetComponent<CrowdControl>().SetWorkingObject(obj, slotId);
        obj.GetComponent<ObjectPrimaryControl>().PlanSlot(slotId);
    }

    void OnManLeavesFromObj(Crowd.Event e)
    {
        var manLeftFromEvent = e as ManLeavesFromObj;
        GameObject man = manLeftFromEvent.man;
        GameObject obj = manLeftFromEvent.obj;
        int slotId = manLeftFromEvent.slotId;

        if (obj == null)
        {
            obj = man.GetComponent<CrowdControl>().GetWorkingObject();
            slotId = man.GetComponent<CrowdControl>().GetWorkingSlot();
        }

        if (obj == null || slotId == -1)
        {
            return;
        }

        man.transform.SetParent(menObj.transform);
        man.GetComponent<CrowdControl>().SetWorkingObject(null, -1);
        obj.GetComponent<ObjectPrimaryControl>().FreeSlot(slotId);
    }

    void OnManAcrossBorder(Crowd.Event e)
    {
        var manAcrossBorderEvent = e as ManAcrossBorder;
        GameObject man = manAcrossBorderEvent.man;
        GameObject obj = manAcrossBorderEvent.obj;

        if (obj != null && obj.GetComponent<ObjectControl>())
        {
            obj.GetComponent<ObjectControl>().ManAcrossBorder(man);
        }
    }

    private void SelectMan(GameObject man)
    {
        DeselectMan();

        selectedMan = man;
        selectedMan.GetComponent<CrowdControl>().Selected();
    }

    private void DeselectMan()
    {
        if (selectedMan == null)
        {
            return;
        }
        selectedMan.GetComponent<CrowdControl>().Deselected();
        selectedMan = null;
    }

    private void FillMan(GameObject man, GameObject obj)
    {
        if (!obj.GetComponent<ObjectPrimaryControl>() || man.GetComponent<CrowdControl>().IsLocked())
        {
            return;
        }

        int slotId = obj.GetComponent<ObjectPrimaryControl>().FindEmptySlot();
        if (slotId == -1)
        {
            return;
        }

        if (Services.pathFindingManager.FindPath(man, obj.GetComponent<ObjectPrimaryControl>().GetSlotPos(slotId)))
        {
            UnboundMan(man);
            Services.pathFindingManager.Move(man, 5, new ManLeavesForObj(man, obj, slotId), new ManArrivesAtObj(man, obj, slotId));
        }
    }

    public void UnboundMan(GameObject man)
    {
        Services.eventManager.QueueEvent(new ManLeavesFromObj(man));
    }

    private void MoveMan(GameObject man, Vector3 targetPos)
    {
        if (man.GetComponent<CrowdControl>().IsLocked())
        {
            return;
        }

        if (Services.pathFindingManager.FindPath(man, targetPos))
        {
            UnboundMan(man);
            Services.pathFindingManager.Move(man);
        }
    }

    public void DropMan(GameObject man)
    {
        if (selectedMan == man)
        {
            DeselectMan();
        }

        RaycastHit[] hits;
        hits = Physics.RaycastAll(man.transform.position, Vector3.down, 100f);
        if (hits != null)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    Vector3 landPos = hit.point;
                    man.transform.DOMove(landPos, 1f).SetEase(Ease.InCubic);
                    break;
                }
            }
        }
    }

    public void DragOn(GameObject obj, Vector3 delta)
    {
        if (obj != null && obj.GetComponent<ObjectControl>())
        {
            obj.GetComponent<ObjectControl>().Drag(delta);
        }
    }

    public void ClickOn(GameObject mouseClickObject, Vector3 mouseClickPos)
    {
        if (mouseClickObject == null)
        {
            DeselectMan();
            return;
        }

        if (mouseClickObject.CompareTag("Man"))
        {
            SelectMan(mouseClickObject);
        }
        else
        if (mouseClickObject.CompareTag("Object"))
        {
            if (selectedMan && mouseClickObject.GetComponent<ObjectControl>().isWalkable)
            {
                MoveMan(selectedMan, mouseClickPos);
            }
            else
            {
                mouseClickObject.GetComponent<ObjectControl>().Click();
            }
        }
        else
        if (mouseClickObject.CompareTag("Ground"))
        {
            if (selectedMan)
            {
                MoveMan(selectedMan, mouseClickPos);
            }
        }
    }

    public void DoubleClickOn(GameObject mouseClickObject)
    {
        if (mouseClickObject == null)
        {
            return;
        }

        if (selectedMan && mouseClickObject.CompareTag("Object"))
        {
            FillMan(selectedMan, mouseClickObject);
        }
    }

    public void HoldStart(GameObject mouseClickObject)
    {
        Services.hudController.CreateHoldIcon(mouseClickObject);
    }

    public void HoldRelease(GameObject mouseClickObject)
    {
        Services.hudController.DestroyHoldIcon(mouseClickObject);
    }

    public void HoldEnd(GameObject mouseClickObject)
    {
        if (mouseClickObject == null)
        {
            return;
        }

        if (selectedMan && mouseClickObject.CompareTag("Object"))
        {
            FillMan(selectedMan, mouseClickObject);
        }
    }
}
