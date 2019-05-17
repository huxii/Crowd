using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelRopeBehavior : ObjectControl
{
    Material mat;

    protected override void Start()
    {
        base.Start();

        mat = GetComponent<MeshRenderer>().material;
    }

    public override void Activate()
    {
        base.Activate();

        Services.taskManager
            .Do(new TimedMaterialTask(gameObject, "_Width", mat.GetFloat("_Width"), 0, 0.3f))
            .Then(new ActionTask(() => Services.gameEvents.PlayAnimation("MovingPlatform, FoldedPlatformOff")));
    }

    public override void Deactivate()
    {
        base.Deactivate();

        Services.taskManager
            .Do(new ActionTask(() => Services.gameEvents.PlayAnimation("MovingPlatform, FoldedPlatformOn")))
            .Then(new Wait(1))
            .Then(new TimedMaterialTask(gameObject, "_Width", mat.GetFloat("_Width"), 0.015f, 0.3f));
    }
}
