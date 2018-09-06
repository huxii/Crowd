using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdControl : ActorControl
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Services.pathFindingManager.GoTo(gameObject, new Vector3(-3, -3, 0), new Vector3(-3, 5, 0));
    }
}
