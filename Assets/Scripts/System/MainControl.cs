using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// TODO: main menu & MerryGoRound pause & camera readjust & postprocess

public class MainControl : MonoBehaviour
{
    //private GameObject selectedMan = null;
    private GameObject[] men;
    private GameObject menParentObj = null;

    // Use this for initialization
    void Start()
    {
        men = GameObject.FindGameObjectsWithTag("Man");
        menParentObj = GameObject.Find("Actors");

        RegisterEvents();

        // do a favor for outline shader
        //Services.utils.RecalculateNormals();

        CheckPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        Services.eventManager.ProcessQueuedEvents();
        Services.taskManager.Update();
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

    void CheckPlatform()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                Application.targetFrameRate = 60;
                break;
        }
    }

    void OnManArrivesAtObj(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrivesAtObj;
        GameObject man = manArrivedEvent.man;
        GameObject obj = manArrivedEvent.obj;
        int slotId = manArrivedEvent.slotId;

        man.transform.SetParent(obj.GetComponent<ObjectPrimaryControl>().GetSlotObject(slotId).transform);
        obj.GetComponent<ObjectPrimaryControl>().ReadySlot(slotId, man);
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

        man.transform.SetParent(menParentObj.transform);
        man.GetComponent<CrowdControl>().SetWorkingObject(null, -1);
        obj.GetComponent<ObjectPrimaryControl>().FreeSlot(slotId);
    }

    public void SelectMan(GameObject man)
    {
        if (man != null && man.GetComponent<CrowdControl>())
        {
            man.GetComponent<CrowdControl>().Selected();
        }
    }

    public void DeselectMan(GameObject man)
    {
        if (man != null && man.GetComponent<CrowdControl>())
        {
            man.GetComponent<CrowdControl>().Deselected();
        }
    }

    public void DeselectMan(List<GameObject> selectedMen)
    {
        foreach (GameObject man in selectedMen)
        {
            man.GetComponent<CrowdControl>().Deselected();
        }
    }

    public void FillMan(GameObject obj, List<GameObject> selectedMen = null)
    {
        if (!obj.GetComponent<ObjectPrimaryControl>() || obj.GetComponent<ObjectPrimaryControl>().GetEmptySlotNum() == 0)
        {
            if (selectedMen != null)
            {
                foreach (GameObject man in selectedMen)
                {
                    man.GetComponent<CrowdControl>().OrderFailed();
                }
            }
            return;
        }

        SortedDictionary<float, GameObject> sortByDistance = new SortedDictionary<float, GameObject>();
        if (selectedMen != null)
        {
            float diffKey = 0;
            foreach (GameObject selectedMan in selectedMen)
            {
                sortByDistance.Add(diffKey, selectedMan);
                diffKey += 1e-12f;
            }
        }

        foreach (GameObject man in men)
        {
            if (!sortByDistance.ContainsValue(man) && man.GetComponent<CrowdControl>().IsBusy() == false && !man.GetComponent<CrowdControl>().IsLocked())
            {
                sortByDistance.Add(Vector3.Distance(man.transform.position, obj.transform.position), man);
            }
        }

        foreach (KeyValuePair<float, GameObject> pair in sortByDistance)
        {
            GameObject man = pair.Value;
            int slotId = obj.GetComponent<ObjectPrimaryControl>().FindEmptySlot();
            if (slotId == -1)
            {
                return;
            }

            if (Services.pathFindingManager.FindPath(man, obj.GetComponent<ObjectPrimaryControl>().GetSlotPos(slotId)))
            {
                UnboundMan(man);
                OnManLeavesForObj(new ManLeavesForObj(man, obj, slotId));
                Services.pathFindingManager.Move(man, 0.05f, new ManArrivesAtObj(man, obj, slotId));
            }
            else
            {
                man.GetComponent<CrowdControl>().OrderFailed();
            }
        }
    }

    public void OrderFailed(GameObject man)
    {
        if (man != null && man.GetComponent<CrowdControl>())
        {
            man.GetComponent<CrowdControl>().OrderFailed();
        }
    }

    public void FreeMan(GameObject man)
    {
        if (man.GetComponent<CrowdControl>().IsLocked())
        {
            return;
        }

        GameObject obj = man.GetComponent<CrowdControl>().GetWorkingObject();
        Vector3 targetPos = obj.GetComponent<ObjectPrimaryControl>().GetFreeManSlotPos();
        if (Services.pathFindingManager.FindPath(man, targetPos))
        {
            UnboundMan(man);
            Services.pathFindingManager.Move(man, 0.05f);
        }
        else
        {
            //man.GetComponent<CrowdControl>().OrderFailed();
            Debug.Log("Should never happen though");
        }
    }

    public void UnboundMan(GameObject man)
    {
        OnManLeavesFromObj(new ManLeavesFromObj(man));
    }

    public void StopMan(GameObject man)
    {
        man.GetComponent<CrowdControl>().Stop();
    }

    public void MoveManTo(GameObject man, Vector3 targetPos, float tol)
    {
        man.GetComponent<CrowdControl>().MoveTo(targetPos, tol);
    }

    public bool MoveMan(GameObject man, Vector3 targetPos, float tol)
    {
        if (man.GetComponent<CrowdControl>().IsLocked())
        {
            return false;
        }

        if (Services.pathFindingManager.FindPath(man, targetPos))
        {
            UnboundMan(man);
            Services.pathFindingManager.Move(man, tol);
            return true;
        }
        else
        {
            man.GetComponent<CrowdControl>().OrderFailed();
        }

        return false;
    }

    public void MoveMen(Vector3 targetPos, List<GameObject> selectedMen = null)
    {
        if (selectedMen != null)
        {
            foreach (GameObject man in selectedMen)
            {
                MoveMan(man, targetPos, selectedMen.Count * 0.15f);
            }
        }
        else
        {
            foreach (GameObject man in men)
            {
                MoveMan(man, targetPos, men.Length * 0.15f);
            }
        }
    }

    public void DropMan(GameObject man)
    {
        Services.eventManager.Fire(new ManDrop(man));

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

    //public void ClickOn(GameObject mouseClickObject, Vector3 mouseClickPos)
    //{
    //    if (mouseClickObject == null)
    //    {
    //        DeselectMan();
    //        return;
    //    }

    //    if (mouseClickObject.CompareTag("Man"))
    //    {
    //        SelectMan(mouseClickObject);
    //    }
    //    else
    //    if (mouseClickObject.CompareTag("Object"))
    //    {
    //        FillMan(mouseClickObject);
    //    }
    //    else
    //    if (mouseClickObject.CompareTag("Ground"))
    //    {
    //        MoveMen(mouseClickPos);
    //    }
    //    else
    //    {
    //        foreach (GameObject man in selecetedMen)
    //        {
    //            man.GetComponent<CrowdControl>().OrderFailed();
    //        }
    //    }
    //}

    //public void DoubleClickOn(GameObject mouseClickObject)
    //{
    //    if (mouseClickObject == null)
    //    {
    //        return;
    //    }

    //    //if (selectedMan && mouseClickObject.CompareTag("Object"))
    //    //{
    //    //    FillMan(selectedMan, mouseClickObject);
    //    //}
    //}

    //public void HoldStart(GameObject mouseClickObject)
    //{
    //    if (mouseClickObject == null)
    //    {
    //        return;
    //    }

    //    //if (selectedMan && mouseClickObject.GetComponent<ObjectPrimaryControl>() && !mouseClickObject.GetComponent<ObjectPrimaryControl>().IsReady())
    //    //{
    //    //    Services.hudController.CreateHoldIcon(mouseClickObject, mouseClickObject.GetComponent<ObjectPrimaryControl>().progressBarPosOffset);
    //    //}
    //}

    //public void HoldRelease(GameObject mouseClickObject)
    //{
    //    if (mouseClickObject == null)
    //    {
    //        return;
    //    }

    //    Services.hudController.DestroyHoldIcon(mouseClickObject);
    //}

    //public void HoldEnd(GameObject mouseClickObject)
    //{
    //    if (mouseClickObject == null)
    //    {
    //        return;
    //    }

    //    //if (selectedMan && mouseClickObject.CompareTag("Object"))
    //    //{
    //    //    Services.hudController.DestroyHoldIcon(mouseClickObject);
    //    //    FillMan(selectedMan, mouseClickObject);
    //    //}
    //}

    public void ManAcrossBorder(GameObject man, GameObject obj)
    {
        if (obj != null && obj.GetComponent<ObjectControl>())
        {
            obj.GetComponent<ObjectControl>().ManAcrossBorder(man);
        }

        if (man != null && man.GetComponent<CrowdControl>())
        {
            man.GetComponent<CrowdControl>().WalkAcross(obj);
        }
    }
}
