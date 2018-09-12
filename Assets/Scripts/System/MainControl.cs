using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: on ladder / off ladder path & zoom in/zoom out and open lids

public class MainControl : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        RegisterEvents();
    }

    // Update is called once per frame
    void Update()
    {
        Services.eventManager.ProcessQueuedEvents();
        Services.taskManager.Update();
        Services.inputController.DetectMouse();
    }

    void OnDestroy()
    {
        UnregisterEvents();   
    }

    void RegisterEvents()
    {
        Services.eventManager.Register<ManArrivesAtObj>(OnManArrivesAtObj);
        Services.eventManager.Register<ManLeavesForObj>(OnManLeavesForObj);
        Services.eventManager.Register<ManLeavesFromObj>(OnManLeavesFromObj);
    }

    void UnregisterEvents()
    {
        Services.eventManager.Unregister<ManArrivesAtObj>(OnManArrivesAtObj);
        Services.eventManager.Unregister<ManLeavesForObj>(OnManLeavesForObj);
        Services.eventManager.Unregister<ManLeavesFromObj>(OnManLeavesFromObj);
    }

    void OnManArrivesAtObj(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrivesAtObj;
        GameObject man = manArrivedEvent.man;
        GameObject obj = manArrivedEvent.obj;
        int slotId = manArrivedEvent.slotId;

        man.transform.SetParent(obj.transform);
        obj.GetComponent<ObjectControl>().ReadySlot(slotId, man);

        if (man == Services.inputController.SelectedMan())
        {
            Services.inputController.DeselectMan();
        }
    }

    void OnManLeavesForObj(Crowd.Event e)
    {
        var manLeftForEvent = e as ManLeavesForObj;
        GameObject man = manLeftForEvent.man;
        GameObject obj = manLeftForEvent.obj;
        int slotId = manLeftForEvent.slotId;

        man.GetComponent<CrowdControl>().SetWorkingObject(obj, slotId);
        obj.GetComponent<ObjectControl>().PlanSlot(slotId);
    }

    void OnManLeavesFromObj(Crowd.Event e)
    {
        var manLeftFromEvent = e as ManLeavesFromObj;
        GameObject man = manLeftFromEvent.man;
        GameObject obj = manLeftFromEvent.obj;
        int slotId = manLeftFromEvent.slotId;

        if (obj == null)
        {
            obj = man.GetComponent<CrowdControl>().GetWorkingObject();
            slotId = man.GetComponent<CrowdControl>().GetWorkingSlot();
        }

        if (obj == null || slotId == -1)
        {
            return;
        }

        man.transform.SetParent(null);
        man.GetComponent<CrowdControl>().SetWorkingObject(null, -1);
        obj.GetComponent<ObjectControl>().FreeSlot(slotId);
    }
}
