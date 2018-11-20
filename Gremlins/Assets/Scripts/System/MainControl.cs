using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

// TODO: main menu & hints & ladder & look at camera & think about physics and make it real & metalness & level1 new ao
// & shaking char

public class MainControl : MonoBehaviour
{
    private GameObject[] men;
    private GameObject menParentObj = null;

    // nav mesh
    private Vector2 navMeshMinBound = new Vector3(float.MaxValue, float.MaxValue);
    private Vector2 navMeshMaxBound = new Vector3(-float.MaxValue, -float.MaxValue);

    private void Awake()
    {
        Services.Init();
    }

    // Use this for initialization
    void Start()
    {
        men = GameObject.FindGameObjectsWithTag("Man");
        menParentObj = GameObject.Find("Actors");
       
        // do a favor for outline shader
        Services.utils.RecalculateNormals();
        RegisterEvents();

        DetectNavMeshBounds();

        CheckPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        Services.Update();
    }

    void OnDestroy()
    {
        UnregisterEvents();

        Services.Destroy();
    }

    void RegisterEvents()
    {
        Services.eventManager.Register<ManArrives>(OnManArrives);
        Services.eventManager.Register<ManLeavesForObj>(OnManLeavesForObj);
        Services.eventManager.Register<ManLeavesFromObj>(OnManLeavesFromObj);
    }

    void UnregisterEvents()
    {
        Services.eventManager.Unregister<ManArrives>(OnManArrives);
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

    void OnManArrives(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrives;
        GameObject man = manArrivedEvent.man;
        GameObject obj = manArrivedEvent.obj;
        int slotId = manArrivedEvent.slotId;

        if (obj != null)
        {
            man.transform.SetParent(obj.GetComponent<PropControl>().GetSlotObject(slotId).transform);
            obj.GetComponent<PropControl>().ReadySlot(slotId, man);
            man.GetComponent<CrowdControl>().SwitchState(obj.GetComponent<PropControl>().changeState);
        }
        else
        {
            man.GetComponent<CrowdControl>().SwitchState(CrowdControl.CrowdState.IDLE);          
        }
    }

    void OnManLeavesForObj(Crowd.Event e)
    {
        var manLeftForEvent = e as ManLeavesForObj;
        GameObject man = manLeftForEvent.man;
        GameObject obj = manLeftForEvent.obj;
        int slotId = manLeftForEvent.slotId;

        man.GetComponent<CrowdControl>().SetWorkingObject(obj, slotId);
        obj.GetComponent<PropControl>().PlanSlot(man, slotId);
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

        Debug.Log(man + " " + obj);
        man.transform.SetParent(menParentObj.transform);
        man.GetComponent<CrowdControl>().SetWorkingObject(null, -1);
        obj.GetComponent<PropControl>().FreeSlot(slotId);

        man.GetComponent<CrowdControl>().SwitchState(CrowdControl.CrowdState.IDLE);
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

    public void InteractObject(GameObject obj)
    {
        if (!obj.GetComponent<ObjectControl>() || obj.GetComponent<ObjectControl>().IsCoolingDown())
        {
            return;
        }

        obj.GetComponent<ObjectControl>().Click();
    }

    public void InteractMen(GameObject obj, Vector3 pos, List<GameObject> selectedMen = null)
    {
        if (!obj.GetComponent<PropControl>() || obj.GetComponent<PropControl>().IsCoolingDown())
        {
            return;
        }

        // this is a prop
        // this prop is settled & walkable
        if (obj.GetComponent<PropControl>().IsLocked() && obj.GetComponent<PropControl>().isWalkableAfterDeactivated)
        {
            MoveMenToPosition(pos, selectedMen);
            return;
        }

        // click on prop feedback
        obj.GetComponent<PropControl>().Click();

        // this prop is full, release all the men
        if (obj.GetComponent<PropControl>().GetEmptySlotNum() == 0)
        {
            obj.GetComponent<PropControl>().FreeAllMan();
        }
        else
        {
            // this prop has empty slots but locked
            if (obj.GetComponent<PropControl>().IsLocked())
            {
                foreach (GameObject man in men)
                {
                    if (!man.GetComponent<CrowdControl>().IsBusy())
                    {
                        man.GetComponent<CrowdControl>().OrderFailed();
                    }
                }
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

                if (sortByDistance.Count != 0)
                {
                    Services.footprintsManager.ClearLastFootprints();
                    Services.footprintsManager.Clear();

                    foreach (KeyValuePair<float, GameObject> pair in sortByDistance)
                    {
                        GameObject man = pair.Value;
                        int slotId = obj.GetComponent<PropControl>().FindEmptySlot();
                        if (slotId == -1)
                        {
                            return;
                        }

                        MoveManToObject(man, obj, slotId, 0.1f);
                    }

                    Services.footprintsManager.Generate();
                }
                else
                {
                    // no any avaliable men, release all the man to avoid dead lock
                    obj.GetComponent<PropControl>().FreeAllMan();
                }
            }
        }
    }

    public void InteractMan(GameObject obj, Vector3 pos)
    {
        if (!obj.GetComponent<PropControl>() || obj.GetComponent<PropControl>().IsCoolingDown())
        {
            return;
        }

        // this obj is walkable
        if (obj.GetComponent<PropControl>().IsLocked() && obj.GetComponent<PropControl>().isWalkableAfterDeactivated)
        {
            MoveMenToPosition(pos);
            return;
        }

        // click on object feedback
        obj.GetComponent<PropControl>().Click();

        int slotId = obj.GetComponent<PropControl>().FindEmptySlot();
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

        MoveManToObject(nearestMan, obj, slotId, 0.1f);
    }

    public void OrderFailed(GameObject man)
    {
        if (man != null && man.GetComponent<CrowdControl>() && !man.GetComponent<CrowdControl>().IsBusy())
        {
            man.GetComponent<CrowdControl>().OrderFailed();
        }
    }

    public void FreeMan(GameObject man)
    {
        if (man.GetComponent<CrowdControl>().IsLocked())
        {
            man.GetComponent<CrowdControl>().OrderFailed();
            return;
        }

        GameObject obj = man.GetComponent<CrowdControl>().GetWorkingObject();
        if (obj == null)
        {
            return;
        }

        Vector3 targetPos = obj.GetComponent<PropControl>().GetFreeManSlotPos();
        //UnboundMan(man);
        //MoveManTo(man, targetPos, 0.1f);
        Services.footprintsManager.Clear();
        Services.footprintsManager.ClearLastFootprints();

        MoveManToPosition(man, targetPos, 0.2f);

        Services.footprintsManager.Generate();
    }

    public void UnboundMan(GameObject man)
    {
        OnManLeavesFromObj(new ManLeavesFromObj(man));
    }

    public void ImmediateUnboundMan(GameObject man, GameObject obj, int slotId)
    {
        OnManLeavesFromObj(new ManLeavesFromObj(man, obj, slotId));

        Services.pathFindingManager.StopActor(man);
        StopMan(man);
    }

    public void StopMan(GameObject man)
    {
        man.GetComponent<CrowdControl>().Stop();
    }

    public void SetManTargetPosition(GameObject man, Vector3 targetPos, float tol, TileEdge.MovementType type = TileEdge.MovementType.WALK)
    {
        switch (type)
        {
            case TileEdge.MovementType.WALK:
                man.GetComponent<CrowdControl>().MoveTo(targetPos, tol, CrowdControl.CrowdState.WALK);
                break;
            case TileEdge.MovementType.CLIMB:
                man.GetComponent<CrowdControl>().MoveTo(targetPos, tol, CrowdControl.CrowdState.CLIMB);
                break;
            default:
                man.GetComponent<CrowdControl>().MoveTo(targetPos, tol, CrowdControl.CrowdState.WALK);
                break;
        }
    }

    public bool MoveManToObject(GameObject man, GameObject obj, int slotId, float tol)
    {
        if (man == null || man.GetComponent<CrowdControl>().IsLocked())
        {
            return false;
        }

        Vector3 targetPos = obj.GetComponent<PropControl>().GetSlotPos(slotId);
        if (Services.pathFindingManager.FindPath(man, targetPos, tol))
        {
            UnboundMan(man);
            OnManLeavesForObj(new ManLeavesForObj(man, obj, slotId));
            man.GetComponent<CrowdControl>().LoadSucceeded();

            Services.pathFindingManager.Move(man, tol, new ManArrives(man, obj, slotId));
            return true;
        }
        else
        {
            man.GetComponent<CrowdControl>().OrderFailed();
        }

        return false;
    }

    public bool MoveManToPosition(GameObject man, Vector3 targetPos, float tol)
    {
        if (man == null || man.GetComponent<CrowdControl>().IsLocked())
        {
            return false;
        }

        if (Services.pathFindingManager.FindPath(man, targetPos))
        {
            UnboundMan(man);
            man.GetComponent<CrowdControl>().WalkSucceeded();

            Services.pathFindingManager.Move(man, tol, new ManArrives(man, null, -1));
            return true;
        }
        else
        {
            man.GetComponent<CrowdControl>().OrderFailed();
        }

        return false;
    }

    public void MoveMenToPosition(Vector3 targetPos, List<GameObject> selectedMen = null)
    {
        Services.footprintsManager.Clear();

        if (selectedMen != null)
        {
            foreach (GameObject man in selectedMen)
            {
                if (!man.GetComponent<CrowdControl>().IsBusy())
                {
                    MoveManToPosition(man, targetPos, (selectedMen.Count - 1) * 0.2f + 0.05f);
                }
            }
        }
        else
        {
            int reachableMenNum = 0;
            foreach (GameObject man in men)
            {
                if (!man.GetComponent<CrowdControl>().IsBusy() && Services.pathFindingManager.FindPath(man, targetPos))
                {
                    ++reachableMenNum;
                }
            }

            foreach (GameObject man in men)
            {
                if (!man.GetComponent<CrowdControl>().IsBusy())
                {
                    MoveManToPosition(man, targetPos, (reachableMenNum - 1) * 0.2f + 0.05f);
                }
            }
        }

        Services.footprintsManager.Generate();
    }

    public void MoveNearestManToPosition(Vector3 targetPos)
    {
        GameObject nearestMan = null;
        float maxDistance = float.MaxValue;
        foreach (GameObject man in men)
        {
            if (!man.GetComponent<CrowdControl>().IsBusy() && Vector3.Distance(man.transform.position, targetPos) < maxDistance)
            {
                maxDistance = Vector3.Distance(man.transform.position, targetPos);
                nearestMan = man;
            }
        }

        if (nearestMan == null)
        {
            return;
        }

        MoveManToPosition(nearestMan, targetPos, 0.15f);
    }

    public void DropMan(GameObject man)
    {
        //Services.eventManager.Fire(new ManDrop(man));

        StopMan(man);
        Services.pathFindingManager.StopActor(man);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(man.transform.position, Vector3.down, 100f);
        if (hits != null)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    Vector3 landPos = hit.point;
                    man.GetComponent<Rigidbody>().DOMove(landPos, 1f).SetEase(Ease.InCubic);
                    break;
                }
            }
        }
    }

    public bool DragOn(GameObject obj, Vector3 delta)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.GetComponent<PropControl>())
        {
            obj.GetComponent<PropControl>().Drag(delta);
            return true;
        }
        else
        if (obj.GetComponent<ObjectControl>())
        {
            if (!obj.GetComponent<ObjectControl>().IsDragOverride())
            {
                obj.GetComponent<InteractableControl>().Drag(delta);
                return true;
            }
        }

        return false;
    }

    public void SwipeOn(GameObject obj)
    {
        if (obj != null && obj.GetComponent<InteractableControl>())
        {
            obj.GetComponent<InteractableControl>().Swipe();
        }
    }

    public void FocusCamera(Vector3 pos)
    {
        float ratioX = Mathf.Clamp((pos.x - navMeshMinBound.x) / (navMeshMaxBound.x - navMeshMinBound.x), 0, 1);
        float ratioY = Mathf.Clamp((pos.y - navMeshMinBound.y) / (navMeshMaxBound.y - navMeshMinBound.y), 0.5f, 1);
        Services.cameraController.SetOrbit(-1, Mathf.Sin(ratioY * 90f / 180f * Mathf.PI));

        //Debug.Log(pos + " " + Mathf.Sin(ratioY * 90f) + " " + ratioY);
    }

    public void SpawnNewActor(Vector3 pos)
    {
        GameObject newActor = Instantiate(Resources.Load("Prefabs/Actor"), menParentObj.transform) as GameObject;
        newActor.transform.position = pos;
    }
}
