using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBehavior : ObjectControl
{
    public Color onColor;
    public Color offColor;
    public float onSpeed = 0;
    public float offSpeed = 0;
    public float onAmplitude = 0;
    public float offAmplitude = 0;

    private Material mat;

    protected override void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetColor("_Color", offColor);
        mat.SetFloat("_Speed", offSpeed);
        mat.SetFloat("_Amplitude", offAmplitude);
    }

    public override void Activate()
    {
        base.Activate();

        mat.SetColor("_Color", onColor);
        mat.SetFloat("_Speed", onSpeed);
        mat.SetFloat("_Amplitude", onAmplitude);

        Services.dotweenEvents.ScaleTo(gameObject.name + " 1.2, 1.2, 1.2, 0.5");
    }

    public override void Deactivate()
    {
        base.Deactivate();

        mat.SetColor("_Color", offColor);
        mat.SetFloat("_Speed", offSpeed);
        mat.SetFloat("_Amplitude", offAmplitude);

        Services.dotweenEvents.ScaleTo(gameObject.name + " 1, 1, 1, 0.5");
    }
}
