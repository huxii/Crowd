using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
* activate and deactivate by other props when slots are filled
*/

public abstract class PropPassiveControl : PropControl
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
}
