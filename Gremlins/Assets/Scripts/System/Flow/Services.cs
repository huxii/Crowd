using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
    public static Crowd.EventManager eventManager = null;
    public static Crowd.TaskManager taskManager = null;
    public static Crowd.SceneManager sceneManager = null;
    public static PathFindingManager pathFindingManager = null;
    public static TileMarkerManager tileMarkerManager = null;
    public static LevelEventsManager levelEventsManager = null;
    public static MainControl gameController = null;
    public static InputControl inputController = null;
    public static CameraControl cameraController = null;
    public static HUDControl hudController = null;
    public static SoundControl soundController = null;
    public static Utils utils = null;
    public static GameEvents gameEvents = null;
    public static DotweenEvents dotweenEvents = null;

    public static GameObject[] men = null;
    public static GameObject menParentObj = null;

    // nav mesh
    public static Vector2 navMeshMinBound;
    public static Vector2 navMeshMaxBound;

    public static void Init()
    {
        eventManager = new Crowd.EventManager();
        taskManager = new Crowd.TaskManager();
        sceneManager = new Crowd.SceneManager();

        if (GameObject.Find("PathFinder"))
        {
            pathFindingManager = GameObject.Find("PathFinder").GetComponent<PathFindingManager>();

            if (GameObject.Find("TileMarkerManager"))
            {
                tileMarkerManager = GameObject.Find("TileMarkerManager").GetComponent<TileMarkerManager>();
            }
        }
        else
        {
            pathFindingManager = null;
        }

        if (GameObject.Find("LevelEventsManager"))
        {
            levelEventsManager = GameObject.Find("LevelEventsManager").GetComponent<LevelEventsManager>();
        }
        else
        {
            levelEventsManager = null;
        }

        if (GameObject.FindGameObjectWithTag("GameController"))
        {
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainControl>();
            inputController = gameController.gameObject.GetComponent<InputControl>();
            gameEvents = gameController.gameObject.GetComponent<GameEvents>();
            dotweenEvents = gameController.gameObject.GetComponent<DotweenEvents>();
        }
        else
        {
            gameController = null;
            inputController = null;
            gameEvents = null;
            dotweenEvents = null;
        }

        if (GameObject.Find("CameraSystem"))
        {
            cameraController = GameObject.Find("CameraSystem").GetComponent<CameraControl>();
        }
        else
        {
            cameraController = null;
        }

        if (GameObject.Find("SoundSystem"))
        {
            soundController = GameObject.Find("SoundSystem").GetComponent<SoundControl>();
        }
        else
        {
            soundController = null;
        }

        if (GameObject.Find("Canvas"))
        {
            hudController = GameObject.Find("Canvas").GetComponent<HUDControl>();
        }
        else
        {
            hudController = null;
        }

        utils = new Utils();

        men = GameObject.FindGameObjectsWithTag("Man");
        menParentObj = GameObject.Find("Actors");

        navMeshMinBound = new Vector3(float.MaxValue, float.MaxValue);
        navMeshMaxBound = new Vector3(-float.MaxValue, -float.MaxValue);
        GameObject[] navs = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject nav in navs)
        {
            Collider collider = nav.GetComponent<BoxCollider>();
            if (collider != null)
            {
                Vector3 c_min = collider.bounds.min;
                Vector3 c_max = collider.bounds.max;

                navMeshMinBound = new Vector2(
                    Mathf.Min(c_min.x, navMeshMinBound.x),
                    Mathf.Min(c_min.y, navMeshMinBound.y)
                    );

                navMeshMaxBound = new Vector2(
                    Mathf.Max(c_max.x, navMeshMaxBound.x),
                    Mathf.Max(c_max.y, navMeshMaxBound.y)
                    );
            }
        }
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
        tileMarkerManager = null;
        levelEventsManager = null;
        gameController = null;
        inputController = null;
        cameraController = null;
        hudController = null;
        soundController = null;
        utils = null;
        gameEvents = null;
        dotweenEvents = null;

        men = null;
        menParentObj = null;
    }
}
