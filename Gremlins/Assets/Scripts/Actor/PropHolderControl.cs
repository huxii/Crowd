using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropHolderControl : PropControl
{
    public UnityEvent onSlotFull;
    public UnityEvent onSlotNotFull;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();

        onSlotFull.Invoke();
    }

    protected override void OnSlotsNotFull()
    {
        base.OnSlotsNotFull();

        onSlotNotFull.Invoke();
    }

    public override void Activate()
    {
        base.Activate();

        if (!IsReady())
        {
            OnSlotsFull();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        if (!IsReady())
        {
            OnSlotsNotFull();
        }
    }
}
