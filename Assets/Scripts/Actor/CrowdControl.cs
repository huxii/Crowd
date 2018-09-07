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
        Services.eventManager.Register<ManArrivesAtObj>(OnManArrivesAtObj);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Services.eventManager.Unregister<ManArrivesAtObj>(OnManArrivesAtObj);
    }

    void OnManArrivesAtObj(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrivesAtObj;
        Debug.Log(manArrivedEvent.man + "...." + manArrivedEvent.obj);
        manArrivedEvent.man.transform.SetParent(manArrivedEvent.obj.transform);
    }

    //protected override void MouseDown()
    //{
    //    base.MouseDown();

    //    transform.parent = null;
    //    Services.gameController.SelectMan(gameObject);
    //    Debug.Log("Click on man");
    //}

    public bool IsBusy()
    {
        return (state == CrowdState.BUSY);
    }
}
