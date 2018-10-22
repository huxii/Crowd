using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    public float swingAngle = 5f;
    public float swingDuration = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Swing()
    {
        Services.dotweenEvents.Zigzag(gameObject.name + " x " + swingAngle.ToString() + " " + swingDuration.ToString());
    }
}
