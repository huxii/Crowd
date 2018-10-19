using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
    public static Crowd.EventManager eventManager = null;
    public static Crowd.TaskManager taskManager = null;
    public static Crowd.SceneManager sceneManager = null;
    public static PathFindingManager pathFindingManager = null;
    public static MainControl gameController = null;
    public static InputControl inputController = null;
    public static CameraControl cameraController = null;
    public static HUDControl hudController = null;
    public static SoundControl soundController = null;
    public static Utils utils = null;

    public static void Init()
    {
        eventManager = new Crowd.EventManager();
        taskManager = new Crowd.TaskManager();
        sceneManager = new Crowd.SceneManager();

        if (GameObject.Find("PathFinder"))
        {
            pathFindingManager = GameObject.Find("PathFinder").GetComponent<PathFindingManager>();
        }
        else
        {
            pathFindingManager = null;
        }

        if (GameObject.FindGameObjectWithTag("GameController"))
        {
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainControl>();
            inputController = gameController.gameObject.GetComponent<InputControl>();
            cameraController = gameController.gameObject.GetComponent<CameraControl>();
            hudController = gameController.gameObject.GetComponent<HUDControl>();
            soundController = gameController.gameObject.GetComponent<SoundControl>();
        }
        else
        {
            gameController = null;
            inputController = null;
            cameraController = null;
            hudController = null;
            soundController = null;
        }
        
        utils = new Utils();
    }

    public static void Update()
    {
        eventManager.ProcessQueuedEvents();
        taskManager.Update();
    }

    public static void Destroy()
    {
        eventManager = null;
        taskManager = null;
        sceneManager = null;
        pathFindingManager = null;
        gameController = null;
        inputController = null;
        cameraController = null;
        hudController = null;
        soundController = null;
        utils = null;
    }
}
