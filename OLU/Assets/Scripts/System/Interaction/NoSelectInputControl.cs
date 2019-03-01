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
            Debug.Log("--------------2 touch-------------");
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);
            switch (touch0.phase)
            {
                case TouchPhase.Began:
                    break;

                case TouchPhase.Moved:
                    //Debug.Log("--------------Moved-------------");
                    if (pinching)
                    {
                        Vector2 touchPrePos0 = touch0.position - touch0.deltaPosition;
                        Vector2 touchPrePos1 = touch1.position - touch1.deltaPosition;

                        float preMag = (touchPrePos0 - touchPrePos1).magnitude;
                        float deltaMag = (touch0.position - touch1.position).magnitude;
                        float magDiff = deltaMag - preMag;
                        float curDeltaPinchMag = Mathf.Clamp(deltaPinchMag + magDiff, 0, maxPinchMag);
                        float dd = curDeltaPinchMag - deltaPinchMag;
                        deltaPinchMag = curDeltaPinchMag;

                        if (Mathf.Abs(dd) > 1f)
                        {
                            Services.cameraController.FreeZoom(-dd);
                        }
                    }
                    else
                    {
                        //Debug.Log("--------------Began-------------");
                        pinching = true;
                        deltaPinchMag = 0;

                        Vector2 centerPos = (touch0.position + touch1.position) / 2;
                        float dis = Vector3.Distance(Camera.main.transform.position, GameObject.Find("Pivots").transform.position);
                        Vector2 pinchTranslatePos = Camera.main.ScreenToWorldPoint(
                            new Vector3(centerPos.x, centerPos.y, dis)
                            );
                        Services.cameraController.SetTranslate(pinchTranslatePos.x, pinchTranslatePos.y);
                        maxPinchMag = dis / 2;
                    }
                    break;

                case TouchPhase.Ended:
                    //Debug.Log("--------------Ended-------------");
                    pinching = false;
                    deltaPinchMag = 0;
                    Services.cameraController.ResetTranslate();
                    Services.cameraController.ResumeZoom();

                    CoolDown();
                    break;

                default:
                    break;
            }
        }
        else
        if (pinching)
        {
            pinching = false;
            deltaPinchMag = 0;
            Services.cameraController.ResetTranslate();
            Services.cameraController.ResumeZoom();

            CoolDown();
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
