using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonBehavior : MonoBehaviour
{
    public float swingAngle = 5f;
    public float swingDuration = 1f;

    private bool activated = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated)
        {
            Services.dotweenEvents.Zigzag(gameObject.name + " y " + swingAngle.ToString() + " " + swingDuration.ToString() + " -1 true");
            activated = true;
        }
    }
}
