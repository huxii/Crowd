using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerThirdControl : CycleControl
{
    [Header("Third Floor Settings")]
    public List<GameObject> centerTiles;
    public List<GameObject> outerTiles;

    private PropAutoTimedDeactivateControl chest;
    private MirrorControl mirror;

    protected override void Start()
    {
        chest = GameObject.Find("Chest").GetComponent<PropAutoTimedDeactivateControl>();
        mirror = GameObject.Find("Mirror1").GetComponent<MirrorControl>();

        base.Start();
    }

    protected void ResetPaths()
    {
        Services.gameEvents.DisconnectPath(centerTiles[0].name + " " + outerTiles[curAbsCycle].name);
        Services.gameEvents.DisconnectPath(centerTiles[1].name + " " + outerTiles[(curAbsCycle + 1) % cycle].name);
    }

    protected void ReconnectPaths()
    {
        Services.gameEvents.ConnectPath(centerTiles[0].name + " " + outerTiles[curAbsCycle].name);
        Services.gameEvents.ConnectPath(centerTiles[1].name + " " + outerTiles[(curAbsCycle + 1) % cycle].name);
    }

    protected override void CheckCycle()
    {
        base.CheckCycle();

        if (chest.IsLocked() && curAbsCycle == 0)
        {
            mirror.SetZeroOne(true);
        }
        else
        {
            mirror.SetZeroOne(false);
        }
    }

    public override void GoClockwise()
    {
        ResetPaths();

        base.GoClockwise();

        ReconnectPaths();
    }

    public override void GoCounterClockwise()
    {
        ResetPaths();

        base.GoCounterClockwise();

        ReconnectPaths();       
    }
}
