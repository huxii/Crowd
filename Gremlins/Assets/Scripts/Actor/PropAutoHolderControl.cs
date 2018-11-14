using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropAutoHolderControl : PropAutoControl
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Deactivate()
    {
        // only deactivate (eg.open door) when slots are not filled (eg.no man is in the holder)
        if (!IsReady())
        {
            base.Deactivate();
        }
    }
}
