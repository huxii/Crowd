using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 *  The objects with slots and directly related to the puzzles
 */

public abstract class PropControl : InteractableControl
{
    [System.Serializable]
    protected class SlotAttr
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

    protected enum SlotState
    {
        EMPTY,
        PLANNED,
        READY,
    }

    // the reaction when player interacts with it
    // eg. model bounces a little bit
    public UnityEvent onInteractionFeedback;
    //public Vector3 progressBarPosOffset = new Vector3(0, 0, 0);

    public float gizmoSize = 0.2f;

    // the point the men should head towards when they are released from the slots
    public Vector3 freeManSlotOffset = new Vector3(0, 0, 0);

    // men states will be changed when get on the working slots
    // eg. when a man gets on the merry go round, state: walk -> ride
    public CrowdControl.CrowdState changeState = CrowdControl.CrowdState.IDLE;

    protected GameObject slotsObj = null;
    [SerializeField]
    protected List<SlotAttr> slots = new List<SlotAttr>();
    [HideInInspector]
    [SerializeField]
    private float namingCounter = 0;
    private Vector3 localSpawnPos = new Vector3(0, 0, 0);

    // current number of slots occupied by the crowd
    protected int currentSlots = 0;

    // to simulate the effect of gravity
    // eg. merry go round sinks a bit when a man is on it
    public GameObject weightObj = null;
    public float deltaWeight = 0f;
    protected float origWeight;

    public enum PropState
    {
        DISABLE,
        NOTFULL,
        FULL,
        PATH,
    };

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
        Gizmos.DrawWireCube(transform.position + freeManSlotOffset, new Vector3(gizmoSize, gizmoSize, gizmoSize));
    }

    public bool IsReady()
    {
        return currentSlots >= slots.Count;
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
        if (slots[id].state == SlotState.READY)
        {
            --currentSlots;
            if (currentSlots == slots.Count - 1)
            {
                OnSlotsNotFull();
            }

            OnFreeASlot();
        }
        slots[id].man = null;
        slots[id].state = SlotState.EMPTY;
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
        if (currentSlots == 0 && weightObj != null)
        {
            origWeight = weightObj.transform.localPosition.y;
        }

        if (slots[id].state != SlotState.READY)
        {
            ++currentSlots;
            if (currentSlots == slots.Count)
            {
                OnSlotsFull();
            }
            slots[id].state = SlotState.READY;
            slots[id].man = man;

            OnFillASlot();
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

    public int GetEmptySlotNum()
    {
        return slots.Count - currentSlots;
    }

    public Vector3 GetFreeManSlotPos()
    {
        return transform.position + freeManSlotOffset;
    }

    public void FreeAllMen()
    {
        foreach (SlotAttr slot in slots)
        {
            if (slot.man != null)
            {
                Services.gameController.FreeMan(slot.man);
            }
        }
    }

    public void LockAllMen()
    {
        foreach (SlotAttr slot in slots)
        {
            if (slot.man != null)
            {
                Services.gameController.LockMan(slot.man);
            }
        }
    }

    public void UnlockAllMen()
    {
        foreach (SlotAttr slot in slots)
        {
            if (slot.man != null)
            {
                Services.gameController.UnlockMan(slot.man);
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
            float curWeight = deltaWeight * currentSlots;
            Services.dotweenEvents.MoveTo(weightObj.name + " y " + (origWeight - curWeight).ToString() + " 1 OutBounce");
        }
    }

    public virtual void OnFillASlot()
    {
        SetWeight();
    }

    public virtual void OnFreeASlot()
    {
        SetWeight();
    }

    public virtual void OnSlotsFull()
    {
    }

    public virtual void OnSlotsNotFull()
    {
        Deactivate();
    }

    // return the current state of this prop
    // so that MainControl can decide what it should do next when another interaction is required
    public virtual PropState Interact()
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
            onInteractionFeedback.Invoke();

            if (IsReady())
            {
                return PropState.FULL;
            }
            else
            {
                return PropState.NOTFULL;
            }
        }

        return PropState.DISABLE;
    }

    //public override void Click()
    //{
    //    base.Click();


    //    //Services.soundController.Play("objectClick");
    //}

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
                Services.gameController.ImmediateUnboundMan(slot.man, gameObject, i);
            }
        }
    }
}
