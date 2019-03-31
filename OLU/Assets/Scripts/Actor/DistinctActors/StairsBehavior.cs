using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsBehavior : ObjectControl
{
    [Header("Stairs Settings")]
    public List<Tile> stairTiles;

    private int stairsCount = 9;
    private float step = -7.5f;

    protected override void Start()
    {
        base.Start();

        foreach (Tile t in stairTiles)
        {
            t.enabled = false;
        }
    }

    private void OnDraggingStairs(Crowd.Event e)
    {
        DragEvent de = (DragEvent)e;
        float deltaRot = step * stairsCount * de.progress;
        for (int i = 0; i < stairsCount; ++i)
        {
            transform.GetChild(i).localEulerAngles = new Vector3(0, step * (stairsCount - i) - deltaRot * (stairsCount - i) / stairsCount, 0);
        }
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        Services.eventManager.Register<DragEvent>(OnDraggingStairs);
    }

    protected override void UnregisterEvents()
    {
        base.UnregisterEvents();
        Services.eventManager.Unregister<DragEvent>(OnDraggingStairs);
    }

    public void EnalbePathPoints()
    {
        foreach (Tile t in stairTiles)
        {
            t.enabled = true;
        }
    }
}
