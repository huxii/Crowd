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
        NextEvent();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextEvent()
    {
        if (curEventId < levelEvents.Count)
        {
            levelEvents[curEventId].Do();
            ++curEventId;
        }
    }
}
