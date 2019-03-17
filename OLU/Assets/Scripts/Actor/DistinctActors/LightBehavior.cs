using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : ObjectControl
{
    [Header("Light")]
    [ColorUsageAttribute(true, true)]
    public Color emissionColor;
    public float duration = 1f;

    protected Material mat;
    protected float timer = 0;
    protected bool isStarting = false;
    protected bool isReversing = false;

    void Awake()
    {
        RecreateMaterial();
    }

    protected virtual void Update()
    {
        if (isStarting)
        {
            timer += Time.deltaTime;
            mat.SetFloat("_EmissionIntensity", timer);

            if (timer >= 1f)
            {
                isStarting = false;
            }
        }
        else
        if (isReversing)
        {
            timer -= Time.deltaTime;
            mat.SetFloat("_EmissionIntensity", timer);

            if (timer <= 0)
            {
                isReversing = false;
            }
        }
    }

    protected void RecreateMaterial()
    {
        mat = null;
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            if (meshRenderer.sharedMaterial.name.ToLower().Contains("inner") || meshRenderer.sharedMaterial.name.ToLower().Contains("outer"))
            {
                if (mat == null)
                {
                    mat = Instantiate(meshRenderer.sharedMaterial);
                    mat.name += "(Instance)";
                }

                meshRenderer.material = mat;
            }
        }

        mat.SetColor("_EmissionColor", emissionColor);
        mat.SetFloat("_EmissionIntensity", timer);
    }

    public override void Activate()
    {
        base.Activate();

        isStarting = true;
        isReversing = false;
        timer = 0;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        isReversing = true;
        isStarting = false;
        timer = 1;
    }
}
