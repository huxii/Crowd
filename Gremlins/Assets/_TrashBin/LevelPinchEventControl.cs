using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPinchEventControl : LevelEventControl
{
    bool isActivated = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (isActivated && Services.cameraController.isZoomed())
        //{
        //    TriggerEvent();
        //}
    }

    //protected override void OnTriggerEnter(Collider other)
    //{
    //    base.OnTriggerEnter(other);

    //    if (other.gameObject.CompareTag("Man"))
    //    {
    //        isActivated = true;
    //    }
    //}
}
