using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MonoBehaviour
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

    public void Swing()
    {
        if (!IsSwinging())
        {
            Services.dotweenEvents.Zigzag(gameObject.name + " x " + swingAngle.ToString() + " " + swingDuration.ToString() + " 1 true");
            swingTimer = swingDuration;
        }
    }
}
