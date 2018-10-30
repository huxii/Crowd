using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintsManager : MonoBehaviour
{
    private bool hasNextOne = false;
    private Vector3 nextPos = new Vector3(0, 0, 0);
    private GameObject lastFootprint = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClearLastFootprints()
    {
        if (lastFootprint != null)
        {
            lastFootprint.GetComponent<FootprintsBehavior>().FadeOut();
        }
    }

    public void Clear()
    {
        hasNextOne = false;
        nextPos = new Vector3(0, 0, 0);
    }

    public void Take()
    {
        hasNextOne = true;
        if ((TileBasedPathFindingManager)Services.pathFindingManager)
        {
            nextPos = ((TileBasedPathFindingManager)Services.pathFindingManager).GetLastTilePos();
        }
    }

    public void Generate()
    {
        if (!hasNextOne)
        {
            return;
        }

        ClearLastFootprints();

        lastFootprint = Instantiate(Resources.Load("Prefabs/Footprints")) as GameObject;
        lastFootprint.transform.position = nextPos;
    }
}
