using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameEvents : CustomEvents
{
    // unity events only allow one or zero parameter.
    // so combine two game objects into one by names (eg. "gameobject0, gameobject1")
    public void EnableUnit(string pointName)
    {
        ParseNewPara(pointName);

        GameObject p = ParseGameObject();
        if (p == null)
        {
            return;
        }
        Services.pathFindingManager.EnableUnit(p);
    }

    public void DisableUnit(string pointName)
    {
        ParseNewPara(pointName);

        GameObject p = ParseGameObject();
        if (p == null)
        {
            return;
        }
        Services.pathFindingManager.DisableUnit(p);
    }

    public void ConnectPath(string pointsName)
    {
        ParseNewPara(pointsName);

        GameObject p0 = ParseGameObject();
        GameObject p1 = ParseGameObject();
        if (p0 == null || p1 == null)
        {
            return;
        }
        Services.pathFindingManager.ConnectPath(p0, p1);
    }

    public void DisconnectPath(string pointsName)
    {
        ParseNewPara(pointsName);

        GameObject p0 = ParseGameObject();
        GameObject p1 = ParseGameObject();
        if (p0 == null || p1 == null)
        {
            return;
        }
        Services.pathFindingManager.DisconnectPath(p0, p1);
    }

    public void SetFollowPathPoint(string pointsName)
    {
        ParseNewPara(pointsName);

        GameObject p0 = ParseGameObject();
        GameObject p1 = ParseGameObject();

        p0.GetComponent<PathPoint>().followPoint = p1;
    }

    public void ClearFollowPathPoint(string pointsName)
    {
        ParseNewPara(pointsName);

        GameObject p0 = ParseGameObject();
        GameObject p1 = ParseGameObject();

        p0.GetComponent<PathPoint>().followPoint = null;
    }

    public void SetMaterialColor(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Color c = ParseColor();

        Material mat = obj.GetComponent<MeshRenderer>().material;
        mat.color = c;
    }

    public void PlayAnimation(GameObject obj)
    {
        Animation ani = obj.GetComponent<Animation>();
        ani.Play();
    }

    public void PlayAnimation(string animParas)
    {
        ParseNewPara(animParas);

        GameObject obj = ParseGameObject();
        string aniName = ParseAnimationName();

        Animation ani = obj.GetComponent<Animation>();
        if (aniName == null)
        {
            ani.Play();
        }
        else
        {
            ani.Play(aniName);
        }
    }

    public void StopAnimation(string animParas)
    {
        ParseNewPara(animParas);

        GameObject obj = ParseGameObject();
        string aniName = ParseAnimationName();

        Animation ani = obj.GetComponent<Animation>();
        if (aniName == null)
        {
            ani.Stop();
        }
        else
        {
            ani.Stop(aniName);
        }
    }

    public void RewindAnimation(string animParas)
    {
        ParseNewPara(animParas);

        GameObject obj = ParseGameObject();
        string aniName = ParseAnimationName();
        if (aniName == null)
        {
            return;
        }

        Animation ani = obj.GetComponent<Animation>();
        ani[aniName].speed = -1;
        if (!ani.isPlaying)
        {
            ani[aniName].time = ani[aniName].length;
        }
        ani.Play();
    }

    public void SetCrowdAnimation(GameObject man, string aniName, SpineAnimationControl.ClearPolicy clearPolicy = SpineAnimationControl.ClearPolicy.DONT)
    {
        man.GetComponent<SpineAnimationControl>().SetAnimation(aniName, clearPolicy);
    }

    public void AddAnchor(GameObject man, GameObject obj)
    {
        if (man == null)
        {
            return;
        }
        if (man.GetComponent<AnchorBehavior>() == null)
        {
            man.AddComponent<AnchorBehavior>();
        }
        man.GetComponent<AnchorBehavior>().parentObject = obj;
    }

    public void RemoveAnchor(GameObject man)
    {
        if (man == null)
        {
            return;
        }

        DestroyImmediate(man.GetComponent<AnchorBehavior>());
    }

    public void MoveActorTo(string para)
    {
        ParseNewPara(para);

        GameObject actor = ParseGameObject();
        if (actor == null)
        {
            return;
        }

        Vector3 pos = ParseIncrement();

        SetManTargetPosition(actor, pos, 0.1f);
    }

    public void MakeFloatMan(GameObject man, float height = 2f)
    {
        if (man == null)
        {
            return;
        }

        DisableMan(man);
        SetCrowdAnimation(man, "inflate_mouth_drift");

        //man.GetComponent<CrowdControl>().Lock();
        man.AddComponent<FloatBehavior>();
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

    public void DisableMan(GameObject man)
    {
        Destroy(man.GetComponent<CrowdControl>());
        //Destroy(man.GetComponent<CrowdFeedbackBehavior>());
        Services.men.Remove(man);
    }

    public void LockMan(GameObject man)
    {
        if (man == null)
        {
            return;
        }
        man.GetComponent<CrowdControl>().Lock();
    }

    public void UnlockMan(GameObject man)
    {
        if (man == null)
        {
            return;
        }
        man.GetComponent<CrowdControl>().Unlock();
    }

    public void StopMan(GameObject man)
    {
        man.GetComponent<CrowdControl>().Stop();
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

    public void TurnMan(GameObject man, Vector3 pos)
    {
        Vector3 dir = (pos - man.transform.position).normalized;
        if (Vector3.Dot(dir, Vector3.right) > Vector3.Dot(dir, -Vector3.right))
        {
            man.GetComponent<CrowdControl>().Flip(-1);
        }
        else
        {
            man.GetComponent<CrowdControl>().Flip(1);
        }
    }

    public void TurnMen(Vector3 pos)
    {
        foreach (GameObject man in Services.men)
        {
            TurnMan(man, pos);
        }
    }

    public void ResetMan(GameObject man)
    {
        if (man != null)
        {
            man.transform.SetParent(Services.menParentObj.transform);
        }
    }

    public void EndLevelCelebration()
    {
        foreach (GameObject man in Services.men)
        {
            man.GetComponent<CrowdControl>().SwitchState(CrowdControl.CrowdState.CELEBRATE);
            man.GetComponent<CrowdControl>().Lock();
        }
        Services.soundController.Play("levelEnd");
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

            int successManNum = 0;
            foreach (KeyValuePair<float, GameObject> pair in sortByDistance)
            {
                GameObject man = pair.Value;
                int slotId = obj.GetComponent<PropControl>().FindEmptySlot();
                if (slotId == -1)
                {
                    return;
                }

                if (MoveManToObject(man, obj, slotId, 0.1f))
                {
                    ++successManNum;
                }
            }

            if (successManNum == 0)
            {
                // no any avaliable men, release all the man to avoid dead lock
                obj.GetComponent<PropControl>().TryFreeAllMen();
            }
        }
        else
        if (propState == PropControl.PropState.FULL)
        {
            obj.GetComponent<PropControl>().TryFreeAllMen();
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
        Services.eventManager.Fire(new ManLeavesFromObj(man));
    }

    public void ImmediateUnboundMan(GameObject man, GameObject obj, int slotId)
    {
        Services.eventManager.Fire(new ManLeavesFromObj(man, obj, slotId));

        Services.pathFindingManager.StopActor(man);
        StopMan(man);
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
            Services.eventManager.Fire(new ManLeavesForObj(man, obj, slotId));
            man.GetComponent<CrowdControl>().LoadSucceeded();
            TurnMan(man, targetPos);
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
            TurnMan(man, targetPos);
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

    public void SwitchCrowdState(GameObject man, CrowdControl.CrowdState state)
    {
        if (man == null)
        {
            return;
        }

        man.GetComponent<CrowdControl>().SwitchState(state);
    }

    //public void Swipe()
    //{
    //    if (swipeObj == null)
    //    {
    //        return;
    //    }

    //    SwipeOn(swipeObj);
    //}

    //public void SwipeOn(GameObject obj)
    //{
    //    if (obj != null && obj.GetComponent<InteractableControl>())
    //    {
    //        obj.GetComponent<InteractableControl>().Swipe();
    //    }
    //}
}
