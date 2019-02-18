using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyBehavior : ObjectBasicControl
{
    [Header("Chimney Settings")]
    public int smokeBallNum = 3;
    public bool isAutoPlaying = false;

    private GameObject[] smokeBalls;
    private int smokeBallIdx = 0;

    void Awake()
    {
        smokeBalls = new GameObject[smokeBallNum];
        for (int i = 0; i < smokeBallNum; ++i)
        {
            smokeBalls[i] = Instantiate(Resources.Load("Prefabs/SmokeBall"), transform) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutoPlaying && !IsCoolingDown())
        {
            Activate();
        }
    }

    public void SetAutoPlaying(bool en)
    {
        isAutoPlaying = en;
    }

    public void Emit()
    {
        //Debug.Log("Emit " + smokeBallIdx);
        smokeBalls[smokeBallIdx].GetComponent<Animation>().Play();
        ++smokeBallIdx;
        if (smokeBallIdx >= smokeBallNum)
        {
            smokeBallIdx -= smokeBallNum;
        }
    }
}
