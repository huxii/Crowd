using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSelectInputControl : InputControl
{
    public enum OrderMode
    {
        SINGLEMAN,
        ALLMAN,
    };

    public OrderMode orderMode = OrderMode.SINGLEMAN;

    private void Update()
    {
        CoolDown();
        DetectMouse();
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
            if (orderMode == OrderMode.SINGLEMAN)
            {
                Services.gameController.InteractMan(mouseClickObject, mouseClickPos);
            }
            else
            {
                Services.gameController.InteractMen(mouseClickObject, mouseClickPos);
            }
        }
        else
        if (mouseClickObject.CompareTag("Object"))
        {
            Services.gameController.InteractObject(mouseClickObject);
        }
        else
        if (mouseClickObject.CompareTag("Ground"))
        {
            //if (orderMode == OrderMode.SINGLEMAN)
            //{
            //    Services.gameController.MoveNearestMan(mouseClickPos);
            //}
            //else
            {
                Services.gameController.MoveMenToPosition(mouseClickPos);
            }

            Services.soundController.Play("clickOnWood1");
            Services.hudController.ShowIcon("GoodClickAnim", mouseClickPos, HUDControl.UISpace.CANVAS);
        }
        else
        {
            //BadClick(mouseClickPos);
        }
    }
}
