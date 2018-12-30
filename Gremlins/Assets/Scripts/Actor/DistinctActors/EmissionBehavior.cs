using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionBehavior : ObjectControl
{
    [Header("Emission Settings")]
    [ColorUsageAttribute(true, true)]
    public Color emissionColor;
    public float duration = 1f;

    protected Material mat;
    protected float timer = -1;
    protected bool isStarting = false;
    protected bool isReversing = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    protected void UpdateEmission()
    {
        if (isStarting)
        {
            timer += Time.deltaTime;
            mat.SetColor("_EmissionColor", timer * emissionColor);

            if (timer >= 1f)
            {
                isStarting = false;
            }
        }
        else
        if (isReversing)
        {
            timer -= Time.deltaTime;
            mat.SetColor("_EmissionColor", timer * emissionColor);

            if (timer <= 0)
            {
                isReversing = false;
            }
        }
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
