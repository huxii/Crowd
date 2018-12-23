using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPassiveElevatorControl : PropPassiveTimedDeactivateControl
{
    private bool parentPermission = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeUpdate();
    }

    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();

        if (parentPermission)
        {
            Activate();
        }
    }

    public override void Activate()
    {
        if (IsReady())
        {
            base.Activate();
        }
    }

    public void SetParentPermission(bool en)
    {
        parentPermission = en;
    }
}
