using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// how to attach a task to a object (structure or xml)
// AI: pathfinding

public class MainControl : MonoBehaviour
{
    public GameObject tmpActor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Services.eventManager.ProcessQueuedEvents();
        Services.taskManager.Update();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        //    mouseWorldPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);
        //    Debug.Log(mouseWorldPos);
        //    Services.pathFindingManager.GoTo(tmpActor, tmpActor.transform.position, mouseWorldPos);            
        //}
    }
}
