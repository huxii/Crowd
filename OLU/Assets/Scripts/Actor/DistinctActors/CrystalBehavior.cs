using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBehavior : ObjectControl
{
    public Color onColor;
    public Color offColor;
    public float onOffset;
    public float offOffset;
    public float onAmplitude;
    public float offAmplitude;
    public float onSpeed;
    public float offSpeed;

    Material mat;

    private void Awake()
    {
        base.Start();

        mat = GetComponent<MeshRenderer>().material;
        mat.SetColor("_Color", offColor);
        mat.SetFloat("_Offset", offOffset);
        mat.SetFloat("_Amplitude", offAmplitude);
        mat.SetFloat("_Speed", offSpeed);
    }

    public override void Activate()
    {
        base.Activate();

        Services.taskManager
            .Do(new TimedMaterialTask(mat, "_Offset", onOffset, 0.5f));

        mat.SetColor("_Color", onColor);
        mat.SetFloat("_Amplitude", onAmplitude);
        mat.SetFloat("_Speed", onSpeed);
        mat.SetFloat("_MotionStrength", 1);
    }

    public override void Deactivate()
    {
        base.Deactivate();

        Services.taskManager
            .Do(new TimedMaterialTask(mat, "_Offset", offOffset, 0.5f));

        mat.SetColor("_Color", offColor);
        mat.SetFloat("_Amplitude", offAmplitude);
        mat.SetFloat("_Speed", offSpeed);
        mat.SetFloat("_MotionStrength", 0);
    }
}
