using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSelectInputControl : InputControl
{
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
            Services.gameController.FillMan(mouseClickObject);
        }
        else
        if (mouseClickObject.CompareTag("Ground"))
        {
            Services.gameController.MoveMen(mouseClickPos);
        }
    }
}
