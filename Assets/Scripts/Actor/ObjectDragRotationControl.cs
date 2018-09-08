using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragRotationControl : ObjectControl
{
    private Vector3 deltaEulerAngle = new Vector3(0, 0, 0);
    private Vector3 origEulerAngles;
    private float mouseEulerAngleSensity = 60;

    // Use this for initialization
    void Start()
    {
        origEulerAngles = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //protected override void MouseDrag()
    //{
    //    base.MouseDrag();

    //    deltaEulerAngle = new Vector3(
    //        Mathf.Max(Mathf.Min(deltaEulerAngle.x + deltaMouseWorldPos.x * mouseEulerAngleSensity, maxDelta.x), minDelta.x),
    //        Mathf.Max(Mathf.Min(deltaEulerAngle.y + deltaMouseWorldPos.y * mouseEulerAngleSensity, maxDelta.y), minDelta.y),
    //        Mathf.Max(Mathf.Min(deltaEulerAngle.z + deltaMouseWorldPos.z * mouseEulerAngleSensity, maxDelta.z), minDelta.z)
    //        );
    //    transform.eulerAngles = origEulerAngles + deltaEulerAngle;
    //}
}
