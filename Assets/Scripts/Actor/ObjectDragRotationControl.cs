using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragRotationControl : ObjectControl
{
    private Vector3 deltaEulerAngle = new Vector3(0, 0, 0);
    private Vector3 origEulerAngles;
    private float mouseEulerAngleSensity = 5f;

    // Use this for initialization
    void Start()
    {
        origEulerAngles = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Drag(Vector3 dp)
    {
        if (ObjectReady())
        {
            base.Drag(dp);

            float delta = dp.x * mouseEulerAngleSensity;
            dp = dp * 0.1f;
            deltaEulerAngle = new Vector3(
                Mathf.Max(Mathf.Min(deltaEulerAngle.x + delta, maxDelta.x), minDelta.x),
                Mathf.Max(Mathf.Min(deltaEulerAngle.y + delta, maxDelta.y), minDelta.y),
                Mathf.Max(Mathf.Min(deltaEulerAngle.z + delta, maxDelta.z), minDelta.z)
                );
            transform.eulerAngles = origEulerAngles + deltaEulerAngle;
        }
    }
}
