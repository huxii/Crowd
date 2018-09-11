using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrowdControl : ActorControl
{
    public UnityEvent onSelected;
    public UnityEvent onDeselected;

    enum CrowdState
    {
        IDLE,
        BUSY
    };

    CrowdState state = CrowdState.IDLE;

    private GameObject workingObject = null;
    private int workingSlot = -1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsBusy()
    {
        return (state == CrowdState.BUSY);
    }

    public void SetWorkingObject(GameObject obj, int slot)
    {
        workingObject = obj;
        workingSlot = slot;
    }

    public GameObject GetWorkingObject()
    {
        return workingObject;
    }

    public int GetWorkingSlot()
    {
        return workingSlot;
    }

    public void Selected()
    {
        onSelected.Invoke();
    }

    public void Deselected()
    {
        onDeselected.Invoke();
    }
}
