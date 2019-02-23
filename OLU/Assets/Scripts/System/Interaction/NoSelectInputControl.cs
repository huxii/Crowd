using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSelectInputControl : InputControl
{
    public bool resetCenterOnRelease = true;
    public bool gyroEnabled = false;

    private void Update()
    {
        CoolDown();
        DetectMouse();
        DetectMousePC();
    }

    private void DetectMousePC()
    {
        if (locked)
        {
            return;
        }

        // only on PC
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButton(1))
            {
                TranslateViewport();
            }

            if (Input.GetMouseButtonUp(1))
            {
                if (resetCenterOnRelease)
                {
                    ResetTranslateViewport();
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                Zoom(Input.GetAxis("Mouse ScrollWheel"));
            }
        }

        if (gyroEnabled)
        {
            Services.cameraController.Orbit(Input.acceleration.x * 2500f, (Input.acceleration.y + 0.5f) * 1500f);
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
