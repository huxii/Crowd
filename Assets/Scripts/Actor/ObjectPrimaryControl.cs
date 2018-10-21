using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// the object with certain amount of slots that can be filled with crowd
// player will directly operate those objects
public abstract class ObjectPrimaryControl : ObjectControl
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

    [Header("Slots")]
    //public Vector3 progressBarPosOffset = new Vector3(0, 0, 0);
    public float gizmoSize = 0.2f;
    public Vector3 freeManSlotOffset = new Vector3(0, 0, 0);

    protected GameObject slotsObj = null;
    [SerializeField]
    protected List<SlotAttr> slots = new List<SlotAttr>();
    [HideInInspector]
    [SerializeField]
    private float namingCounter = 0;
    private Vector3 localSpawnPos = new Vector3(0, 0, 0);

    // current slots occupied by the crowd
    protected int currentSlots = 0;

    [Header("Interaction")]
    public UnityEvent onClick;

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

    public void FreeSlot(int id)
    {
        if (slots[id].state == SlotState.READY)
        {
            if (currentSlots == slots.Count)
            {
                OnSlotsNotFull();
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
                OnSlotsFull();
            }
            slots[id].state = SlotState.READY;
            slots[id].man = man;
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

    public int GetEmptySlotNum()
    {
        return slots.Count - currentSlots;
    }

    public Vector3 GetFreeManSlotPos()
    {
        return transform.position + freeManSlotOffset;
    }

    public void FreeAllMan()
    {
        foreach (SlotAttr slot in slots)
        {
            if (slot.man != null)
            {
                Services.gameController.FreeMan(slot.man);
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

    public virtual void OnSlotsFull()
    {
    }

    public virtual void OnSlotsNotFull()
    {
        Deactivate();
    }

    public override void Click()
    {
        base.Click();

        Services.soundController.Play("objectClick");
        onClick.Invoke();
    }
}
