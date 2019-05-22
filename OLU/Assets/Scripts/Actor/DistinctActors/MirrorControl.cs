using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControl : PropZeroOneControl
{
    [Header("Mirror Settings")]
    public GameObject mirroredMan;
    public GameObject mirroredFreeTile; 
    public GameObject crystal;
    public GameObject crystal2;
    public GameObject crystal3;
    public GameObject inner;
    public GameObject stone;

    protected override void Start()
    {
        base.Start();

        mirroredMan.GetComponentInChildren<MeshRenderer>().sharedMaterial.SetFloat("_Alpha", 0);
        inner.GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Radius", 0);
        stone.GetComponent<MeshRenderer>().material.SetFloat("_DitheringFactor", 1);
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
            //Services.dotweenEvents.ScaleTo(crystal.name + " 0.01, 0.01, 0.01, 1");

            Services.taskManager.Do(new TimedMaterialTask(stone, "_DitheringFactor", 0, 0.5f));
        }
    }

    public override void SetZeroOne(bool zeroOne)
    {
        base.SetZeroOne(zeroOne);

        if (zeroOne)
        {
            Services.taskManager
                .Do(new ActionTask(() => crystal.GetComponent<CrystalBehavior>().Activate()))
                .Then(new Wait(0.25f))
                .Then(new ActionTask(() => crystal2.GetComponent<CrystalBehavior>().Activate()))
                .Then(new Wait(0.25f))
                .Then(new ActionTask(() => crystal3.GetComponent<CrystalBehavior>().Activate()));

            if (!IsLocked())
            {
                Services.taskManager
                    .Do(new TimedMaterialTask(inner, "_Radius", 1, 0.5f));
            }
            //Services.gameEvents.SetMaterialColor(crystal, new Color(1, 1, 1, 1));
        }
        else
        {
            crystal.GetComponent<CrystalBehavior>().Deactivate();
            crystal2.GetComponent<CrystalBehavior>().Deactivate();
            crystal3.GetComponent<CrystalBehavior>().Deactivate();

            if (!IsLocked())
            {
                Services.taskManager
                    .Do(new TimedMaterialTask(inner, "_Radius", 0, 0.5f));
            }
            //Services.gameEvents.SetMaterialColor(crystal, new Color(1, 1, 1, 1));
        }
    }

    public void MirrorAnotherMan()
    {
        Services.gameEvents.RemoveAnchor(mirroredMan);
        //Services.dotweenEvents.ScaleTo(mirroredMan.name + " 1, 1, 1, 1");
        Services.dotweenEvents.MoveTo(mirroredMan.name + " " + mirroredFreeTile.transform.position + " 1");

        Services.taskManager
            .Do(new TimedMaterialTask(inner, "_Deform", 0.2f, 0.5f))
            .Then(new TimedMaterialTask(inner, "_Deform", 0, 0.5f))
            .Then(new TimedMaterialTask(inner, "_Radius", 0, 0.5f));

        Services.taskManager
            .Do(new TimedMaterialTask(mirroredMan.GetComponentInChildren<MeshRenderer>().sharedMaterial, "_Alpha", 0.01f, 1, 1))
            .Then(new ActionTask(() => mirroredMan.transform.SetParent(mirroredFreeTile.transform)))
            .Then(new ActionTask(() => Services.gameEvents.UnlockMan(mirroredMan)));
    }
}
