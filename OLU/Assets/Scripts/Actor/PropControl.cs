﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 *  The objects with slots and directly related to the puzzles
 */

[RequireComponent(typeof(PropFeedbackBehavior))]

public abstract class PropControl : InteractableControl
{
    public PropFeedbackBehavior PropFeedbackController
    {
        get { return (PropFeedbackBehavior)feedbackController; }
        set { feedbackController = value; }
    }

    public enum PropState
    {
        DISABLE,
        PATH,
        EMPTY,
        NOTFULL,
        FULL,
    };

    [System.Serializable]
    public class SlotAttr
    {
        public SlotState state;
        public GameObject obj;
        public GameObject man;

        public SlotAttr(GameObject o, GameObject m = null)
        {
            state = SlotState.EMPTY;
            obj = o;
            man = m;
        }
    };

    public enum SlotState
    {
        EMPTY,
        PLANNED,
        READY,
    }

    public float gizmoSize = 0.2f;

    // the point the men should head towards when they are released from the slots
    public GameObject freeManTile;
    public Vector3 freeManOffset;

    // men states will be changed when get on the working slots
    // eg. when a man gets on the merry go round, state: walk -> ride
    public CrowdControl.CrowdState changeState = CrowdControl.CrowdState.IDLE;

    public float changeScaleX = 1;

    public List<SlotAttr> slots = new List<SlotAttr>();
    protected GameObject slotsObj = null;

    [HideInInspector][SerializeField]
    private float namingCounter = 0;
    private Vector3 localSpawnPos = new Vector3(0, 0, 0);

    // current number of slots occupied by the crowd
    protected int currentReadySlotNum = 0;

    // to simulate the effect of gravity
    // eg. merry go round sinks a bit when a man is on it
    public GameObject weightObj = null;
    public float deltaWeight = 0f;
    protected float origWeight;

    private void OnDrawGizmos()
    {
        foreach (SlotAttr slot in slots.ToArray())
        {
            if (slot.obj == null)
            {
                slots.Remove(slot);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(slot.obj.transform.position, gizmoSize);
            }
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(GetFreeManSlotPos(), new Vector3(gizmoSize, gizmoSize, gizmoSize));
    }

    public bool IsReady()
    {
        return currentReadySlotNum >= slots.Count;
    }

    public bool IsEmpty()
    {
        return GetEmptySlotNum() == slots.Count;
    }

    public GameObject AddSlot()
    {
        if (slotsObj == null)
        {
            slotsObj = new GameObject();
            slotsObj.name = "Slots";
            slotsObj.transform.SetParent(transform);
            slotsObj.transform.localPosition = localSpawnPos;
        }

        GameObject newSlot = new GameObject();
        newSlot.name = "Slot" + namingCounter;
        newSlot.transform.SetParent(slotsObj.transform);
        newSlot.transform.localPosition = localSpawnPos;
        ++namingCounter;

        slots.Add(new SlotAttr(newSlot));
        return newSlot;
    }

    // free the men from the slots
    public void FreeSlot(int id)
    {
        SlotState state = slots[id].state;
        if (state == SlotState.PLANNED || state == SlotState.READY)
        {
            slots[id].man = null;
            slots[id].state = SlotState.EMPTY;

            if (state == SlotState.READY)
            {
                --currentReadySlotNum;
                if (currentReadySlotNum == slots.Count - 1)
                {
                    OnSlotsNotFull();
                }             
            }

            OnSlotChange();
        }
    }

    // a man is planning to get on the slot but not arrived yet
    public void PlanSlot(GameObject man, int id)
    {
        slots[id].state = SlotState.PLANNED;
        slots[id].man = man;
    }

    // a man arrives at the slot
    public void ReadySlot(int id, GameObject man)
    {
        if (currentReadySlotNum == 0 && weightObj != null)
        {
            origWeight = weightObj.transform.localPosition.y;
        }

        if (slots[id].state != SlotState.READY)
        {
            ++currentReadySlotNum;
            if (currentReadySlotNum == slots.Count)
            {
                OnSlotsFull();
            }
            slots[id].state = SlotState.READY;
            slots[id].man = man;

            OnSlotChange();
        }
    }

    public Vector3 GetSlotPos(int id)
    {
        return slots[id].obj.transform.position;
    }

    public GameObject GetSlotObject(int id)
    {
        return slots[id].obj;
    }

    public GameObject GetSlotMan(int id)
    {
        return slots[id].man;
    }

    public SlotState GetSlotState(int id)
    {
        return slots[id].state;
    }

    public int GetEmptySlotNum()
    {
        int emptySlotNum = 0;
        foreach(SlotAttr slot in slots)
        {
            if (slot.state == SlotState.EMPTY)
            {
                ++emptySlotNum;
            }
        }
        return emptySlotNum;
    }

    public int GetReadySlotNum()
    {
        return currentReadySlotNum;
    }

    public Vector3 GetFreeManSlotPos()
    {
        if (freeManTile)
        {
            return freeManTile.transform.position;
        }
        else
        {
            Vector3 sumPos = new Vector3(0, 0, 0);
            foreach (SlotAttr slot in slots)
            {
                sumPos += slot.obj.transform.position;
            }
            return sumPos / slots.Count + freeManOffset;
        }
    }

    public void FreeAllMen()
    {
        foreach (SlotAttr slot in slots)
        {
            if (slot.man != null)
            {
                Services.gameEvents.FreeMan(slot.man);
            }
        }
    }

    public void LockMan(int i)
    {
        GameObject man = GetSlotMan(i);
        if (man != null && GetSlotState(i) == SlotState.READY)
        {
            man.GetComponent<CrowdControl>().Lock();
        }
    }

    public void LockAllMen()
    {
        foreach (SlotAttr slot in slots)
        {
            if (slot.man != null && slot.state == SlotState.READY)
            {
                Services.gameEvents.LockMan(slot.man);
            }
        }
    }

    public void UnlockMan(int i)
    {
        GameObject man = GetSlotMan(i);
        if (man != null)
        {
            man.GetComponent<CrowdControl>().Unlock();
        }
    }

    public void UnlockAllMen()
    {
        foreach (SlotAttr slot in slots)
        {
            if (slot.man != null)
            {
                Services.gameEvents.UnlockMan(slot.man);
            }
        }
    }

    //public int GetSlotId(GameObject man)
    //{
    //    for (int i = 0; i < slots.Count; ++i)
    //    {
    //        if (slots[i].man == man)
    //        {
    //            return i;
    //        }
    //    }

    //    return -1;
    //}

    public virtual int FindEmptySlot()
    {
        if (IsLocked())
        {
            return -1;
        }

        for (int i = 0; i < slots.Count; ++i)
        {
            SlotAttr slot = slots[i];
            if (slot.state == SlotState.EMPTY)
            {
                return i;
            }
        }

        return -1;
    }

    protected void SetWeight()
    {
        if (weightObj != null)
        {
            float curWeight = deltaWeight * currentReadySlotNum;
            Services.dotweenEvents.MoveTo(weightObj.name + " y " + (origWeight - curWeight).ToString() + " 1 OutBounce");
        }
    }

    protected PropState UpdateState()
    {
        if (IsLocked())
        {
            if (isWalkableAfterDeactivated)
            {
                return PropState.PATH;
            }
            else
            {
                return PropState.DISABLE;
            }
        }
        else
        {
            if (IsReady())
            {
                return PropState.FULL;
            }
            else
            if (GetEmptySlotNum() == slots.Count)
            {
                return PropState.EMPTY;
            }
            else
            {
                return PropState.NOTFULL;
            }
        }
    }

    protected virtual void OnSlotsFull()
    {
    }

    protected virtual void OnSlotsNotFull()
    {
    }

    protected virtual void OnSlotChange()
    {
        SetWeight();
    }

    // return the current state of this prop
    // so that MainControl can decide what it should do next when another interaction is required
    public virtual PropState Interact()
    {
        PropState state = UpdateState();
        if (state != PropState.PATH)
        {
            feedbackController.OnInteract();
        }
        return state;
    }

    //public override void Click()
    //{
    //    base.Click();


    //    //Services.soundController.Play("objectClick");
    //}

    public virtual void TryFreeAllMen()
    {
    }

    // if this prop is locked, the men on it will be locked as well
    // and the men who are heading to it will be dismissed
    public override void Lock()
    {
        base.Lock();

        for (int i = 0; i < slots.Count; ++i)
        {
            SlotAttr slot = slots[i];
            if (slot.state == SlotState.PLANNED)
            {
                Services.gameEvents.ImmediateUnboundMan(slot.man, gameObject, i);
            }
        }
    }
}
