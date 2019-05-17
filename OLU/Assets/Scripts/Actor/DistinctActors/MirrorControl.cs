using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControl : PropZeroOneControl
{
    [Header("Mirror Settings")]
    public GameObject mirroredMan;
    public GameObject mirroredFreeTile; 
    public GameObject crystal; 

    protected override void Start()
    {
        base.Start();

        mirroredMan.GetComponentInChildren<MeshRenderer>().sharedMaterial.SetFloat("_Alpha", 0);
    }

    public override void Activate()
    {
        base.Activate();
        if (IsActivated())
        {
            Services.taskManager
                .Do(new Wait(1))
                .Then(new ActionTask(TryFreeAllMen));
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        if (isOne)
        {
            Lock();
            Services.dotweenEvents.ScaleTo(crystal.name + " 0.01, 0.01, 0.01, 1");
        }
    }

    public override void SetZeroOne(bool zeroOne)
    {
        base.SetZeroOne(zeroOne);

        if (zeroOne)
        {
            Services.gameEvents.SetMaterialColor(crystal, new Color(0, 1, 0));
        }
        else
        {
            Services.gameEvents.SetMaterialColor(crystal, new Color(1, 0, 0));
        }
    }

    public void MirrorAnotherMan()
    {
        Services.gameEvents.RemoveAnchor(mirroredMan);
        //Services.dotweenEvents.ScaleTo(mirroredMan.name + " 1, 1, 1, 1");
        Services.dotweenEvents.MoveTo(mirroredMan.name + " " + mirroredFreeTile.transform.position + " 1");
        Services.taskManager
            .Do(new TimedMaterialTask(mirroredMan.GetComponentInChildren<MeshRenderer>().material, "_Alpha", 0.01f, 1, 1))
            .Then(new ActionTask(() => mirroredMan.transform.SetParent(freeManTile.transform)))
            .Then(new ActionTask(() => Services.gameEvents.UnlockMan(mirroredMan)));
    }
}
