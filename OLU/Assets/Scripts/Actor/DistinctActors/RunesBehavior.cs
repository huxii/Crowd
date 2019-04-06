using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunesBehavior : ObjectControl
{
    private Vector3 targetRot;
    private Vector3 curRot;
    private float speed = 5f;

    protected override void Start()
    {
        base.Start();

        targetRot = transform.localEulerAngles;
        curRot = transform.localEulerAngles;
    }

    private void Update()
    {
        curRot = Vector3.Lerp(curRot, targetRot, Time.deltaTime * speed);
        transform.localEulerAngles = curRot;
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();

        Services.eventManager.Register<CameraAngleEvent>(OnCameraAngleChanged);
    }

    protected override void UnregisterEvents()
    {
        base.UnregisterEvents();

        Services.eventManager.Unregister<CameraAngleEvent>(OnCameraAngleChanged);
    }

    private void OnCameraAngleChanged(Crowd.Event e)
    {
        CameraAngleEvent ce = (CameraAngleEvent)e;
        float y = ce.angle.x;
        if (y > 180)
        {
            y -= 360;
        }
        targetRot = new Vector3(0, y, 0);
    }
}
