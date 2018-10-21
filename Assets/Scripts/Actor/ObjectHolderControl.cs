using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolderControl : ObjectControl
{
    public bool clearMenOnDeactivated = false;

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
        //base.Deactivate();

        //if (clearMenOnDeactivated && menOnThis != null && menOnThis.Count > 0)
        //{
        //    foreach (GameObject man in menOnThis)
        //    {
        //        Services.gameController.DropMan(man);
        //    }

        //    Unlock();
        //    menOnThis.Clear();
        //}
    }
}
