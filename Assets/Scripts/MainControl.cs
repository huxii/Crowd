﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// TODO: main menu & MerryGoRound pause & camera readjust & postprocess

public class MainControl : MonoBehaviour
{
    //private GameObject selectedMan = null;
    private GameObject[] men;
    private GameObject menParentObj = null;

    // nav mesh
    private Vector2 navMeshMinBound = new Vector3(float.MaxValue, float.MaxValue);
    private Vector2 navMeshMaxBound = new Vector3(-float.MaxValue, -float.MaxValue);

    // Use this for initialization
    void Start()
    {
        men = GameObject.FindGameObjectsWithTag("Man");
        menParentObj = GameObject.Find("Actors");

        RegisterEvents();

        // do a favor for outline shader
        Services.utils.RecalculateNormals();

        DetectNavMeshBounds();

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
                Application.targetFrameRate = 30;
                break;
        }
    }

    private void DetectNavMeshBounds()
    {
        GameObject[] navs = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject nav in navs)
        {
            Collider collider = nav.GetComponent<BoxCollider>();
            if (collider != null)
            {
                Vector3 c_min = collider.bounds.min;
                Vector3 c_max = collider.bounds.max;

                navMeshMinBound = new Vector2(
                    Mathf.Min(c_min.x, navMeshMinBound.x),
                    Mathf.Min(c_min.y, navMeshMinBound.y)
                    );

                navMeshMaxBound = new Vector2(
                    Mathf.Max(c_max.x, navMeshMaxBound.x),
                    Mathf.Max(c_max.y, navMeshMaxBound.y)
                    );
            }
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

    public void InteractMan(GameObject obj, Vector3 pos, List<GameObject> selectedMen = null)
    {
        if (!obj.GetComponent<ObjectPrimaryControl>())
        {
            return;
        }

        // this obj is walkable
        if (obj.GetComponent<ObjectPrimaryControl>().IsLocked())
        {
            if (obj.GetComponent<ObjectPrimaryControl>().isWalkable)
            {
                MoveMen(pos, selectedMen);
            }

            return;
        }

        if (obj.GetComponent<ObjectPrimaryControl>().GetEmptySlotNum() == 0)
        {
            obj.GetComponent<ObjectPrimaryControl>().FreeAllMan();
        }
        else
        {
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

                if (Services.pathFindingManager.FindPath(man, obj.GetComponent<ObjectPrimaryControl>().GetSlotPos(slotId), 0.1f))
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

        //// no slots anymore
        //if (obj.GetComponent<ObjectPrimaryControl>().GetEmptySlotNum() == 0)
        //{
        //    if (selectedMen != null)
        //    {
        //        foreach (GameObject man in selectedMen)
        //        {
        //            man.GetComponent<CrowdControl>().OrderFailed();
        //        }
        //    }
        //    return;
        //}

    }

    public void InteractSingleMan(GameObject obj, Vector3 pos)
    {
        if (!obj.GetComponent<ObjectPrimaryControl>())
        {
            return;
        }

        // this obj is walkable
        if (obj.GetComponent<ObjectPrimaryControl>().IsLocked())
        {
            if (obj.GetComponent<ObjectPrimaryControl>().isWalkable)
            {
                MoveMen(pos);
            }

            return;
        }

        int slotId = obj.GetComponent<ObjectPrimaryControl>().FindEmptySlot();
        if (slotId == -1)
        {
            return;
        }

        GameObject nearestMan = null;
        float maxDistance = float.MaxValue;
        foreach (GameObject man in men)
        {
            if (!man.GetComponent<CrowdControl>().IsBusy() && !man.GetComponent<CrowdControl>().IsLocked() && 
                Vector3.Distance(man.transform.position, obj.transform.position) < maxDistance)
            {
                maxDistance = Vector3.Distance(man.transform.position, obj.transform.position);
                nearestMan = man;
            }
        }

        if (nearestMan == null)
        {
            return;
        }

        if (Services.pathFindingManager.FindPath(nearestMan, obj.GetComponent<ObjectPrimaryControl>().GetSlotPos(slotId), 0.1f))
        {
            UnboundMan(nearestMan);
            OnManLeavesForObj(new ManLeavesForObj(nearestMan, obj, slotId));
            Services.pathFindingManager.Move(nearestMan, 0.05f, new ManArrivesAtObj(nearestMan, obj, slotId));
        }
        else
        {
            nearestMan.GetComponent<CrowdControl>().OrderFailed();
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
        if (obj == null)
        {
            return;
        }

        Vector3 targetPos = obj.GetComponent<ObjectPrimaryControl>().GetFreeManSlotPos();
        //UnboundMan(man);
        //MoveManTo(man, targetPos, 0.1f);
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
        if (man == null || man.GetComponent<CrowdControl>().IsBusy() || man.GetComponent<CrowdControl>().IsLocked())
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

    public void MoveNearestMan(Vector3 targetPos)
    {
        GameObject nearestMan = null;
        float maxDistance = float.MaxValue;
        foreach (GameObject man in men)
        {
            if (Vector3.Distance(man.transform.position, targetPos) < maxDistance)
            {
                maxDistance = Vector3.Distance(man.transform.position, targetPos);
                nearestMan = man;
            }
        }

        if (nearestMan == null)
        {
            return;
        }

        if (Services.pathFindingManager.FindPath(nearestMan, targetPos))
        {
            UnboundMan(nearestMan);
            Services.pathFindingManager.Move(nearestMan, 0.15f);
        }
        else
        {
            nearestMan.GetComponent<CrowdControl>().OrderFailed();
        }
    }

    public void MoveMen(Vector3 targetPos, List<GameObject> selectedMen = null)
    {
        if (selectedMen != null)
        {
            foreach (GameObject man in selectedMen)
            {
                MoveMan(man, targetPos, (selectedMen.Count - 1) * 0.15f + 0.05f);
            }
        }
        else
        {
            foreach (GameObject man in men)
            {
                MoveMan(man, targetPos, (men.Length - 1) * 0.15f + 0.05f);
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

    public void SwipeOn(GameObject obj)
    {
        if (obj != null && obj.GetComponent<ObjectControl>())
        {
            obj.GetComponent<ObjectControl>().Swipe();
        }
    }

    public void FocusCamera(Vector3 pos)
    {
        float ratioX = Mathf.Clamp((pos.x - navMeshMinBound.x) / (navMeshMaxBound.x - navMeshMinBound.x), 0, 1);
        float ratioY = Mathf.Clamp((pos.y - navMeshMinBound.y) / (navMeshMaxBound.y - navMeshMinBound.y), 0, 1);
        Services.cameraController.SetOrbit(-1, Mathf.Sin(ratioY * 90f / 180f * Mathf.PI));

        Debug.Log(pos + " " + Mathf.Sin(ratioY * 90f) + " " + ratioY);
    }

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