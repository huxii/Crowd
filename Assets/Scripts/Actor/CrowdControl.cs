using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdControl : ActorControl
{
    enum CrowdState
    {
        IDLE,
        BUSY
    };

    CrowdState state = CrowdState.IDLE;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsBusy()
    {
        return (state == CrowdState.BUSY);
    }
}
