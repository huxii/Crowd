using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO: main menu & hints & ladder & look at camera & think about physics and make it real & metalness & level1 new ao
// & shaking char & water texture & ballon & level0 nails & level0 mechanic & level1 mechanic & deactivate all after level ends

public class MainControl : MonoBehaviour
{
    //public int velocityIter = 8;
    //public int positionIter = 3;

    private GameObject swipeObj = null;

    private void Awake()
    {
        Services.Init();
    }

    // Use this for initialization
    void Start()
    {
        //Physics2D.velocityIterations = velocityIter;
        //Physics2D.positionIterations = positionIter;

        // do a favor for outline shader
        Services.utils.RecalculateNormals();

        Services.utils.CheckPlatform();

        RegisterEvents();
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

    void OnManArrives(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrives;
        GameObject man = manArrivedEvent.man;
        GameObject obj = manArrivedEvent.obj;
        int slotId = manArrivedEvent.slotId;

        if (obj != null)
        {
            man.GetComponent<CrowdControl>().Flip(obj.GetComponent<PropControl>().changeScaleX);
            man.transform.SetParent(obj.GetComponent<PropControl>().GetSlotObject(slotId).transform);
            obj.GetComponent<PropControl>().ReadySlot(slotId, man);
            man.GetComponent<CrowdControl>().SwitchState(obj.GetComponent<PropControl>().changeState);

            if (obj.GetComponent<PropControl>().PropFeedbackController != null && obj.GetComponent<PropControl>().IsReady())
            {
                obj.GetComponent<PropControl>().PropFeedbackController.OnStateChange(PropControl.PropState.FULL);
                foreach (PropControl.SlotAttr slot in obj.GetComponent<PropControl>().slots)
                {
                    if (slot.man.GetComponent<CrowdControl>().CrowdFeedbackController != null)
                    {
                        slot.man.GetComponent<CrowdControl>().CrowdFeedbackController.OnStateChange(PropControl.PropState.FULL);
                    }
                }
            }            
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

        if (man.GetComponent<CrowdControl>().CrowdFeedbackController != null)
        {
            man.GetComponent<CrowdControl>().CrowdFeedbackController.Breathe();
        }
        if (obj.GetComponent<PropControl>().PropFeedbackController != null)
        {
            obj.GetComponent<PropControl>().PropFeedbackController.Breathe();
        }
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

        //Debug.Log(man + " " + obj);
        man.transform.SetParent(Services.menParentObj.transform);
        man.GetComponent<CrowdControl>().SetWorkingObject(null, -1);
        obj.GetComponent<PropControl>().FreeSlot(slotId);

        if (man.GetComponent<CrowdControl>().CrowdFeedbackController != null)
        {
            man.GetComponent<CrowdControl>().CrowdFeedbackController.OnStateChange(PropControl.PropState.EMPTY);
        }

        if (obj.GetComponent<PropControl>().PropFeedbackController != null)
        {
            if (obj.GetComponent<PropControl>().IsEmpty())
            {
                obj.GetComponent<PropControl>().PropFeedbackController.OnStateChange(PropControl.PropState.EMPTY);
            }
            else
            {
                obj.GetComponent<PropControl>().PropFeedbackController.OnStateChange(PropControl.PropState.NOTFULL);
            }
        }

        man.GetComponent<CrowdControl>().SwitchState(CrowdControl.CrowdState.IDLE);
    }

    public void InteractObject(GameObject obj)
    {
        if (!obj.GetComponent<ObjectControl>() || obj.GetComponent<ObjectControl>().IsCoolingDown())
        {
            return;
        }

        obj.GetComponent<ObjectControl>().Interact();
    }

    public void InteractMen(GameObject obj, Vector3 pos)
    {
        if (!obj.GetComponent<PropControl>() || obj.GetComponent<PropControl>().IsCoolingDown())
        {
            return;
        }

        PropControl.PropState propState = obj.GetComponent<PropControl>().Interact();
        if (propState == PropControl.PropState.NOTFULL || propState == PropControl.PropState.EMPTY)
        {
            SortedDictionary<float, GameObject> sortByDistance = new SortedDictionary<float, GameObject>();
            foreach (GameObject man in Services.men)
            {
                if (man.GetComponent<CrowdControl>().IsBusy() || man.GetComponent<CrowdControl>().IsLocked())
                {
                    man.GetComponent<CrowdControl>().OrderBusy();
                    continue;
                }

                sortByDistance.Add(Vector3.Distance(man.transform.position, obj.transform.position), man);
            }

            if (sortByDistance.Count != 0)
            {
                //Services.footprintsManager.ClearLastFootprints();
                //Services.footprintsManager.Clear();

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

                //Services.footprintsManager.Generate();
            }
            else
            {
                // no any avaliable men, release all the man to avoid dead lock
                obj.GetComponent<PropControl>().FreeAllMen();
            }
        }
        else
        if (propState == PropControl.PropState.FULL)
        {
            obj.GetComponent<PropControl>().FreeAllMen();
        }
        else
        if (propState == PropControl.PropState.PATH)
        {
            MoveMenToPosition(pos);
        }
        else
        if (propState == PropControl.PropState.DISABLE)
        {
            foreach (GameObject man in Services.men)
            {
                if (!man.GetComponent<CrowdControl>().IsBusy())
                {
                    man.GetComponent<CrowdControl>().OrderFailed();
                }
            }
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
        //Services.footprintsManager.Clear();
        //Services.footprintsManager.ClearLastFootprints();

        MoveManToPosition(man, targetPos, 0.2f);

        //Services.footprintsManager.Generate();
    }

    public void UnboundMan(GameObject man)
    {
        OnManLeavesFromObj(new ManLeavesFromObj(man));
    }

    public void ImmediateUnboundMan(GameObject man, GameObject obj, int slotId)
    {
        OnManLeavesFromObj(new ManLeavesFromObj(man, obj, slotId));

        Services.pathFindingManager.StopActor(man);
        Services.gameEvents.StopMan(man);
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
            Services.gameEvents.TurnMan(man, targetPos);
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
            Services.gameEvents.TurnMan(man, targetPos);
            Services.pathFindingManager.Move(man, tol, new ManArrives(man, null, -1));
            return true;
        }
        else
        {
            man.GetComponent<CrowdControl>().OrderFailed();
        }

        return false;
    }

    public void MoveMenToPosition(Vector3 targetPos)
    {
        //Services.footprintsManager.Clear();

        int reachableMenNum = 0;
        foreach (GameObject man in Services.men)
        {
            if (!man.GetComponent<CrowdControl>().IsBusy() && Services.pathFindingManager.FindPath(man, targetPos))
            {
                ++reachableMenNum;
            }
        }

        foreach (GameObject man in Services.men)
        {
            if (!man.GetComponent<CrowdControl>().IsBusy())
            {
                MoveManToPosition(man, targetPos, (reachableMenNum - 1) * 0.2f + 0.05f);
            }
            else
            {
                man.GetComponent<CrowdControl>().OrderBusy();
            }
        }

        //Services.footprintsManager.Generate();
    }

    public void MoveNearestManToPosition(Vector3 targetPos)
    {
        GameObject nearestMan = null;
        float maxDistance = float.MaxValue;
        foreach (GameObject man in Services.men)
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

    public bool DragOn(GameObject obj, Vector3 delta)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.GetComponent<PropControl>())
        {
            obj.GetComponent<PropControl>().Drag(delta * 0.05f);
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

    public void Swipe()
    {
        if (swipeObj == null)
        {
            return;
        }

        SwipeOn(swipeObj);
    }

    public void SwipeOn(GameObject obj)
    {
        if (obj != null && obj.GetComponent<InteractableControl>())
        {
            obj.GetComponent<InteractableControl>().Swipe();
        }
    }
}
