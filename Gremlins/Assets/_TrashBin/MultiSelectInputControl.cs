using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSelectInputControl : InputControl
{
    //protected List<GameObject> selectedMen = new List<GameObject>();

    //private void Start()
    //{
    //    RegisterEvents();
    //}

    //private void Update()
    //{
    //    DetectMouse();
    //}

    //private void OnDestroy()
    //{
    //    UnregisterEvents();
    //}
    
    //private void RegisterEvents()
    //{
    //    Services.eventManager.Register<ManArrives>(OnManArrives);
    //}

    //private void UnregisterEvents()
    //{
    //    Services.eventManager.Unregister<ManArrives>(OnManArrives);
    //}

    //void OnManArrives(Crowd.Event e)
    //{
    //    var manArrivedEvent = e as ManArrives;
    //    GameObject man = manArrivedEvent.man;

    //    if (selectedMen.Contains(man))
    //    {
    //        Services.gameController.DeselectMan(man);
    //        selectedMen.Remove(man);
    //    }
    //}

    ////void OnManDrop(Crowd.Event e)
    ////{
    ////    var manDropEvent = e as ManDrop;
    ////    GameObject man = manDropEvent.man;

    ////    if (selectedMen.Contains(man))
    ////    {
    ////        Services.gameController.DeselectMan(man);
    ////        selectedMen.Remove(man);
    ////    }
    ////}

    //protected override void MouseSingleClick()
    //{
    //    base.MouseSingleClick();

    //    if (mouseClickObject == null)
    //    {
    //        Services.gameController.DeselectMan(selectedMen);
    //        selectedMen.Clear();
    //    }
    //    else
    //    if (mouseClickObject.CompareTag("Man"))
    //    {
    //        if (!selectedMen.Contains(mouseClickObject))
    //        {
    //            Services.gameController.SelectMan(mouseClickObject);
    //            selectedMen.Add(mouseClickObject);
    //        }
    //        else
    //        {
    //            Services.gameController.DeselectMan(mouseClickObject);
    //            selectedMen.Remove(mouseClickObject);
    //        }
    //    }
    //    else
    //    if (mouseClickObject.CompareTag("Object"))
    //    {
    //        Services.gameController.InteractMen(mouseClickObject, mouseClickPos, selectedMen);
    //    }
    //    else
    //    if (mouseClickObject.CompareTag("Ground"))
    //    {
    //        Services.gameController.MoveMenToPosition(mouseClickPos, selectedMen);
    //    }
    //    else
    //    {
    //        foreach (GameObject man in selectedMen)
    //        {
    //            Services.gameController.OrderFailed(man);
    //        }
    //    }
    //}
}
