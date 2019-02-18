using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : PropPassiveTimedDeactivateControl
{
    public CrowdControl.CrowdState noActiveState;

    private bool parentPermission = false;

    // Use this for initialization
    void Start()
    {

    }

    protected override void OnSlotsFull()
    {
        base.OnSlotsFull();

        GameObject man = GetSlotMan(0);
        if (parentPermission)
        {
            Services.gameEvents.SwitchCrowdState(man, changeState);
            Activate();
        }
        else
        {
            Services.gameEvents.SwitchCrowdState(man, noActiveState);
        }
    }

    public override void Activate()
    {
        if (IsReady())
        {
            GameObject man = GetSlotMan(0);
            Services.gameEvents.SwitchCrowdState(man, changeState);

            base.Activate();
        }
    }

    public override void TryFreeAllMen()
    {
        FreeAllMen();
    }

    public void SetParentPermission(bool en)
    {
        parentPermission = en;
    }
}
