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
        DetectMouse();
    }

    protected override void MouseSingleClick()
    {
        base.MouseSingleClick();

        if (mouseClickObject == null)
        {
            return;
        }
        
        if (mouseClickObject.CompareTag("Man"))
        {
            Services.gameController.FreeMan(mouseClickObject);
        }
        else
        if (mouseClickObject.CompareTag("Object"))
        {
            if (orderMode == OrderMode.SINGLEMAN)
            {
                Services.gameController.FillSingleMan(mouseClickObject);
            }
            else
            {
                Services.gameController.FillMan(mouseClickObject);
            }
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
                Services.gameController.MoveMen(mouseClickPos);
            }
        }
    }
}
