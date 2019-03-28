using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerSubControl : CycleControl
{
    public List<GameObject> centerTiles;
    public List<GameObject> outerTiles;

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
}
