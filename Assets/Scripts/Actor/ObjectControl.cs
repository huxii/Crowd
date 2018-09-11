using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectControl : ActorControl
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

    [SerializeField]
    public float slotGizmoSize = 1f;
    [SerializeField]
    protected List<SlotAttr> slots;
    [HideInInspector]
    [SerializeField]
    private float namingCounter = 0;
    private Vector3 localSpawnPos = new Vector3(0, 0, 0);

    // the range of dragging
    public Vector3 minDelta = new Vector3(0, 0, 0);
    public Vector3 maxDelta = new Vector3(0, 0, 0);

    // current slots occupied by the crowd
    protected int currentSlots = 0;

    protected bool locked = false;

    protected enum SlotState
    {
        EMPTY,
        PLANNED,
        READY,
    }

    public UnityEvent onSlotFullfilled;
    public UnityEvent onSlotQuitFullfilled;
    public UnityEvent onArriveMinPosition;
    public UnityEvent onArriveMaxPosition;
    public UnityEvent onLeaveMinPosition;
    public UnityEvent onLeaveMaxPosition;

    //public enum ObjectControlScheme
    //{
    //    DRAG_TRANSFORMATION,
    //    DRAG_ROTATION,
    //    CLICK,
    //    // HOLD,
    //    // SMASH,
    //    // SWIPE,
    //    // OTHEROBJECT
    //};

    //public ObjectControlScheme controlScheme = ObjectControlScheme.DRAG_TRANSFORMATION;
    //public bool deltaLimited = false;

    // Use this for initialization
    void Start ()
    {       
    }
	
	// Update is called once per frame
	void Update ()
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
                Gizmos.DrawWireSphere(slot.obj.transform.position, slotGizmoSize);
            }
        }
    }

    public GameObject AddSlot()
    {
        GameObject newSlot = new GameObject();
        newSlot.name = "Slot" + namingCounter;
        newSlot.transform.SetParent(transform);
        newSlot.transform.localPosition = localSpawnPos;
        ++namingCounter;

        slots.Add(new SlotAttr(newSlot));
        return newSlot;
    }

    protected bool ObjectReady()
    {
        return currentSlots >= slots.Count;
    }

    public void FreeSlot(int id)
    {
        if (slots[id].state == SlotState.READY)
        {
            if (currentSlots == slots.Count)
            {
                //Debug.Log("not fullfill");
                onSlotQuitFullfilled.Invoke();
            }
            --currentSlots;            
        }
        slots[id].man = null;
        slots[id].state = SlotState.EMPTY;
    }

    public void PlanSlot(int id)
    {
        slots[id].state = SlotState.PLANNED;
    }

    public void ReadySlot(int id, GameObject man)
    {
        if (slots[id].state != SlotState.READY)
        {
            ++currentSlots;
            if (currentSlots == slots.Count)
            {
                //Debug.Log("fullfill");
                onSlotFullfilled.Invoke();
            }
            slots[id].state = SlotState.READY;
            slots[id].man = man;
        }
    }

    public Vector3 GetSlotPos(int id)
    {
        return slots[id].obj.transform.position;
    }

    public void Lock()
    {
        locked = true;
    }

    public void Unlock()
    {
        locked = false;
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

    public virtual void Drag(Vector3 deltaPos)
    {
    }

    public virtual int FindEmptySlot()
    {
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
}
