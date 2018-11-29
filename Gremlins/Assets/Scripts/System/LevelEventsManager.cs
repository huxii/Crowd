using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEventsManager : MonoBehaviour
{
    public List<LevelEventControl> levelEvents;

    [SerializeField]
    private int curEventId = 0;

    // Use this for initialization
    void Start()
    {
        DoNextEvent();
        //MoveToNext();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToNext()
    {
        ++curEventId;
        //Debug.Log(curEventId);
    }

    public void DoNextEvent()
    {
        if (curEventId < levelEvents.Count)
        {
            levelEvents[curEventId].Do();
        }
    }
}
