using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSelectInputControl : InputControl
{
    protected override void DetectMouse()
    {
        base.DetectMouse();

        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);
            switch (touch0.phase)
            {
                case TouchPhase.Began:
                    Vector2 centerPos = (Input.GetTouch(0).position + Input.GetTouch(1).position) / 2;
                    Vector3 pos = Camera.main.ScreenToWorldPoint(
                        new Vector3(
                            centerPos.x,
                            centerPos.y,
                            Vector3.Distance(Camera.main.transform.position, GameObject.Find("Pivots").transform.position)
                            )
                        );
                    Services.cameraController.SetTranslate(pos.x, pos.y);
                    Services.cameraController.SetZoom(-15f);
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    Services.cameraController.ResetTranslate();
                    Services.cameraController.ResumeZoom();
                    break;
                default:
                    break;
            }
        }
    }

    protected override void MouseSingleClick()
    {
        base.MouseSingleClick();

        if (mouseClickObject == null)
        {
            return;
        }

        //if (mouseClickObject.CompareTag("Man"))
        //{
        //    if (orderMode == OrderMode.SINGLEMAN)
        //    {
        //        //Services.gameController.FreeMan(mouseClickObject);
        //    }
        //    else
        //    {

        //    }
        //}
        //else
        if (mouseClickObject.CompareTag("Prop"))
        {
            if (autoFocusCameraEnabled)
            {
                Services.cameraController.Focus(mouseClickPos);
            }

            Services.gameEvents.InteractMen(mouseClickObject, mouseClickPos);
        }
        else
        if (mouseClickObject.CompareTag("Object"))
        {
            Services.gameEvents.InteractObject(mouseClickObject);
        }
        else
        if (mouseClickObject.CompareTag("Ground"))
        {
            if (groundEnabled)
            {
                Services.gameEvents.MoveMenToPosition(mouseClickPos);
                Services.soundController.Play("clickOnWood1");

                Services.tileMarkerManager.Activate(Services.pathFindingManager.LastUnit());
            }
        }
        else
        {
            //BadClick(mouseClickPos);
        }      
    }
}
