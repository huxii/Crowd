using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services : MonoBehaviour
{
    public static Crowd.EventManager eventManager = new Crowd.EventManager();
    public static Crowd.TaskManager taskManager = new Crowd.TaskManager();
    public static PathFindingManager pathFindingManager = GameObject.Find("PathFinder").GetComponent<PathFindingManager>();
    public static MainControl gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainControl>();
}
