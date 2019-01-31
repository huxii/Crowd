using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
    public static Crowd.EventManager eventManager = null;
    public static Crowd.TaskManager taskManager = null;
    public static PathFindingManager pathFindingManager = null;
    public static TileMarkerManager tileMarkerManager = null;
    public static MainControl mainController = null;
    public static InputControl inputController = null;
    public static CameraControl cameraController = null;
    public static HUDControl hudController = null;
    public static SoundControl soundController = null;
    public static SceneControl sceneController = null;
    public static SceneTransitionControl sceneTransitionController = null;
    public static LevelEventsControl levelEventsController = null;
    public static Utils utils = null;
    public static GameEvents gameEvents = null;
    public static ComicEvents comicEvents = null;
    public static DotweenEvents dotweenEvents = null;

    public static List<GameObject> men = null;
    public static GameObject menParentObj = null;

    // nav mesh
    public static Vector2 navMeshMinBound;
    public static Vector2 navMeshMaxBound;

    public static void Init()
    {
        if (eventManager == null)
        {
            eventManager = new Crowd.EventManager();
        }

        if (taskManager == null)
        {
            taskManager = new Crowd.TaskManager();
        }

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

        if (GameObject.Find("LevelEvents"))
        {
            levelEventsController = GameObject.Find("LevelEvents").GetComponent<LevelEventsControl>();
        }
        else
        {
            levelEventsController = null;
        }

        if (GameObject.FindGameObjectWithTag("GameController"))
        {
            mainController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainControl>();
            inputController = mainController.gameObject.GetComponent<InputControl>();
            sceneController = mainController.gameObject.GetComponent<SceneControl>();
            gameEvents = mainController.gameObject.GetComponent<GameEvents>();
            dotweenEvents = mainController.gameObject.GetComponent<DotweenEvents>();
        }
        else
        {
            mainController = null;
            inputController = null;
            sceneController = null;
            gameEvents = null;
            dotweenEvents = null;
        }

        if (GameObject.FindGameObjectWithTag("Transition"))
        {
            sceneTransitionController = GameObject.FindGameObjectWithTag("Transition").GetComponent<SceneTransitionControl>();
        }
        else
        {
            sceneTransitionController = null;
        }

        if (GameObject.FindGameObjectWithTag("Comic"))
        {
            comicEvents = GameObject.FindGameObjectWithTag("Comic").GetComponent<ComicEvents>();
        }
        else
        {
            comicEvents = null;
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

        men = new List<GameObject>(GameObject.FindGameObjectsWithTag("Man"));
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
        //eventManager = null;
        //taskManager = null;
        pathFindingManager = null;
        tileMarkerManager = null;
        levelEventsController = null;
        mainController = null;
        inputController = null;
        cameraController = null;
        hudController = null;
        soundController = null;
        sceneController = null;
        sceneTransitionController = null;
        utils = null;
        gameEvents = null;
        comicEvents = null;
        dotweenEvents = null;

        men = null;
        menParentObj = null;
    }
}
