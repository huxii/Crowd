using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragControl : ObjectControl
{
    // the range of dragging
    public Vector3 minDelta = new Vector3(0, 0, 0);
    public Vector3 maxDelta = new Vector3(0, 0, 0);

    //protected Vector3 objectScreenPos;
    //protected Vector3 mouseWorldPos;
    //protected Vector3 deltaMouseWorldPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //protected override void MouseDown()
    //{
    //    base.MouseDown();

    //    // clip mouse world pos to the z plane of object screen
    //    objectScreenPos = Camera.main.WorldToScreenPoint(transform.position);
    //    mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectScreenPos.z));
    //}

    //protected override void MouseDrag()
    //{
    //    base.MouseDrag();

    //    //if (currentSlots > totalSlots)
    //    //{
    //    //    // should never happen
    //    //    print("currentSlots > totalSlots");
    //    //}
    //    //else
    //    //if (currentSlots == totalSlots)
    //    {
    //        // happen when slots are fullfilled
    //        Vector3 curMouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectScreenPos.z));
    //        deltaMouseWorldPos = curMouseWorldPos - mouseWorldPos;
    //        mouseWorldPos = curMouseWorldPos;
    //    }

    //}
}
