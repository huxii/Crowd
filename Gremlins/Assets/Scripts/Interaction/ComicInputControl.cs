using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicInputControl : InputControl
{

    // Use this for initialization
    void Start()
    {
        autoFocusCameraEnabled = false;
    }

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

        if (mouseClickObject.CompareTag("Comic"))
        {
            Services.levelEventsManager.DoCurrentEvent();
        }
    }
}
