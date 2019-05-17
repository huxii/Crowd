using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelCrystalBehavior : ObjectControl
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
            .Do(new TimedMaterialTask(gameObject, "_Offset", mat.GetFloat("_Offset"), -0.5f, 0.5f));

        mat.SetFloat("_Amplitude", 0);
        mat.SetFloat("_Speed", 0);
    }

    public override void Deactivate()
    {
        base.Deactivate();

        Services.taskManager
            .Do(new TimedMaterialTask(gameObject, "_Offset", mat.GetFloat("_Offset"), 0, 0.5f));

        mat.SetFloat("_Amplitude", 0.05f);
        mat.SetFloat("_Speed", 50);
    }
}
