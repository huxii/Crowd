using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintsManager : MonoBehaviour
{
    private bool hasNextOne = false;
    private Vector3 nextPos = new Vector3(0, 0, 0);
    private Vector3 nextOri = new Vector3(0, 0, 0);
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

    public void Take(Vector3 pos, Vector3 ori)
    {
        hasNextOne = true;
        nextPos = pos;
        nextOri = ori;
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

        if (nextOri == Vector3.right)
        {
            lastFootprint.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        else
        if (nextOri == Vector3.left)
        {
            lastFootprint.transform.localEulerAngles = new Vector3(0, -90, 0);
        }
        else
        if (nextOri == Vector3.forward)
        {
            lastFootprint.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        if (nextOri == Vector3.back)
        {
            lastFootprint.transform.localEulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
        }
    }
}
