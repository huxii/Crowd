using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MouseResponseBehavior
{
    public float swingAngle = 5f;
    public float swingDuration = 1f;

    private float swingTimer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (swingTimer > 0)
        {
            swingTimer -= Time.deltaTime;
        }
    }

    private bool IsSwinging()
    {
        return swingTimer > 0;
    }

    public override void React()
    {
        if (!IsSwinging())
        {
            Services.dotweenEvents.Shock(gameObject.name + " x " + swingAngle.ToString() + " " + swingDuration.ToString() + " 4 true");
            swingTimer = swingDuration;
        }
    }
}
