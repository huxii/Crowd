﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO: main menu & hints & ladder & look at camera & think about physics and make it real & metalness & level1 new ao
// & shaking char & water texture & ballon & level0 nails & level0 mechanic & level1 mechanic & deactivate all after level ends

public class GameControl : MainControl
{
    //public int velocityIter = 8;
    //public int positionIter = 3;

    //private GameObject swipeObj = null;

    // Use this for initialization
    //protected override void Start()
    //{
    //    base.Start();

    //    //Services.sceneTransitionController.FadeIn();
    //    //Services.sceneController.PreloadScene();

    //    //Physics2D.velocityIterations = velocityIter;
    //    //Physics2D.positionIterations = positionIter;

    //    // do a favor for outline shader
    //    //Services.utils.RecalculateNormals();
    //}

    //protected override void Update()
    //{
    //    base.Update();

    //    if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        Services.sceneController.LoadNextScene();
    //    }
    //}

    protected override void RegisterEvents()
    {
        Services.eventManager.Register<ManArrives>(OnManArrives);
        Services.eventManager.Register<ManLeavesForObj>(OnManLeavesForObj);
        Services.eventManager.Register<ManLeavesFromObj>(OnManLeavesFromObj);
    }

    protected override void UnregisterEvents()
    {
        Services.eventManager.Unregister<ManArrives>(OnManArrives);
        Services.eventManager.Unregister<ManLeavesForObj>(OnManLeavesForObj);
        Services.eventManager.Unregister<ManLeavesFromObj>(OnManLeavesFromObj);
    }

    void OnManArrives(Crowd.Event e)
    {
        var manArrivedEvent = e as ManArrives;
        GameObject man = manArrivedEvent.man;
        GameObject obj = manArrivedEvent.obj;
        int slotId = manArrivedEvent.slotId;

        if (obj != null)
        {
            man.GetComponent<CrowdControl>().Flip(obj.GetComponent<PropControl>().changeScaleX);
            man.GetComponent<CrowdControl>().SwitchState(obj.GetComponent<PropControl>().changeState);
            man.transform.SetParent(obj.GetComponent<PropControl>().GetSlotObject(slotId).transform);
            Services.gameEvents.SetCrowdAnimation(man, "busy_forever");
            obj.GetComponent<PropControl>().ReadySlot(slotId, man);           

            if (obj.GetComponent<PropControl>().PropFeedbackController != null && obj.GetComponent<PropControl>().IsReady())
            {
                obj.GetComponent<PropControl>().PropFeedbackController.OnStateChange(PropControl.PropState.FULL);
                foreach (PropControl.SlotAttr slot in obj.GetComponent<PropControl>().slots)
                {
                    if (slot.man.GetComponent<CrowdControl>().CrowdFeedbackController != null)
                    {
                        slot.man.GetComponent<CrowdControl>().CrowdFeedbackController.OnStateChange(PropControl.PropState.FULL);
                    }
                }
            }            
        }
        else
        {
            man.GetComponent<CrowdControl>().SwitchState(CrowdControl.CrowdState.IDLE);          
        }
    }

    void OnManLeavesForObj(Crowd.Event e)
    {
        var manLeftForEvent = e as ManLeavesForObj;
        GameObject man = manLeftForEvent.man;
        GameObject obj = manLeftForEvent.obj;
        int slotId = manLeftForEvent.slotId;

        man.GetComponent<CrowdControl>().SetWorkingObject(obj, slotId);
        obj.GetComponent<PropControl>().PlanSlot(man, slotId);

        if (man.GetComponent<CrowdControl>().CrowdFeedbackController != null)
        {
            man.GetComponent<CrowdControl>().CrowdFeedbackController.Breathe();
        }
        if (obj.GetComponent<PropControl>().PropFeedbackController != null)
        {
            obj.GetComponent<PropControl>().PropFeedbackController.Breathe();
        }
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

        //Debug.Log(man + " " + obj);
        man.transform.SetParent(Services.menParentObj.transform);
        man.GetComponent<CrowdControl>().SetWorkingObject(null, -1);
        Services.gameEvents.ClearCrowdAnimation(man, "busy_forever");
        obj.GetComponent<PropControl>().FreeSlot(slotId);

        if (man.GetComponent<CrowdControl>().CrowdFeedbackController != null)
        {
            man.GetComponent<CrowdControl>().CrowdFeedbackController.OnStateChange(PropControl.PropState.EMPTY);
        }

        if (obj.GetComponent<PropControl>().PropFeedbackController != null)
        {
            if (obj.GetComponent<PropControl>().IsEmpty())
            {
                obj.GetComponent<PropControl>().PropFeedbackController.OnStateChange(PropControl.PropState.EMPTY);
            }
            else
            {
                obj.GetComponent<PropControl>().PropFeedbackController.OnStateChange(PropControl.PropState.NOTFULL);
            }
        }

        man.GetComponent<CrowdControl>().SwitchState(CrowdControl.CrowdState.IDLE);
    }

    public override void Ending(bool cleared)
    {
        if (!hasEnded)
        {
            base.Ending(cleared);

            Services.cameraController.SetZoom(0);
            Services.gameEvents.DissolveBackShell(false);
            GameObject.Find("BackShell").GetComponent<ObjectControl>().Deactivate();

            DataSet.recentQuitLevelName = Services.sceneController.CurrentSceneName();

            if (cleared)
            {
                // go back to title
                DataSet.recentCompletedLevelIdx = Services.sceneController.CurrentSceneIdx();
                Services.taskManager
                    .Do(new Wait(3f))
                    .Then(new ActionTask(() => Services.sceneController.LoadSceneWithRecordAndAnimation("Title")));
            }
            else
            {
                Services.taskManager
                    .Do(new Wait(0.1f))
                    .Then(new ActionTask(() => Services.sceneController.LoadSceneWithRecordAndAnimation("Title")));
            }

            //Services.sceneController.LoadSceneWithRecordAndZoom("Title");
        }
    }

    public override void EnableInput()
    {
        base.EnableInput();

        Services.hudController.SetInput(true);
        Services.inputController.Lock(false);
    }

    public override void DisableInput()
    {
        base.DisableInput();

        Services.hudController.SetInput(false);
        Services.inputController.Lock(true);
    }

    public override void OnCameraAngleUpdated()
    {
        base.OnCameraAngleUpdated();

        Vector2 value = Services.cameraController.CurrentOrbit();
        Services.eventManager.Fire(new CameraAngleEvent(value));

        if (value.x > 180)
        {
            value = new Vector2(360 - value.x, value.y);
        }
        Services.eventManager.Fire(new ParallaxScrollingEvent(value));
    }
}
