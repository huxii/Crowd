using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    AsyncOperation async;

    private float transitionAnimTime = 1f;
    private float transitionFadeTime = 0.5f;
    private float transitionButtonTime = 0.5f;

    void Awake()
    {
        async = null;
    }
    
    private void OnLevelWasLoaded(int level)
    {
        //Debug.Log(level + " loaded.");
        if (Services.sceneTransitionController)
        {
            if (level == 0)
            {
                //Debug.Log(DataSet.recentQuitLevelName);
                if (Services.sceneTransitionController.isTransiting)
                {
                    GameObject panel = GameObject.Find(DataSet.recentQuitLevelName + "SelectPanel");
                    Services.taskManager
                        .Do(new ActionTask(() => Services.gameEvents.TriggerAnimation(panel, "Back")))
                        .Then(new ActionTask(() => Services.gameEvents.PauseAnimation(panel)))
                        .Then(new Wait(transitionAnimTime))
                        .Then(new ActionTask(() => Services.sceneTransitionController.FadeOutOfLoadingScreen()))
                        .Then(new Wait(transitionFadeTime))
                        .Then(new ActionTask(() => Services.gameEvents.ResumeAnimation(panel)));
                }
            }
            else
            {
                Services.sceneTransitionController.FadeOutOfLoadingScreen();
            }
        }
    }

    public int CurrentSceneIdx()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public string CurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;

        // return SceneManager.GetSceneByBuildIndex(idx).name;
        // not working
    }

    public void ReloadCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void PreloadScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
    }

    /*
     * 2d -> 3d
    */
    public void LegacyLoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Services.mainController.EnableInput();
    }

    public void LoadSceneWithAnimationAndRecord(string sceneName)
    {
        if (Services.sceneTransitionController)
        {
            LoadingStarted();
            PreloadScene(sceneName);

            Services.mainController.DisableInput();

            Services.taskManager
                .Do(new Wait(transitionButtonTime))
                .Then(new ActionTask(() => Services.gameEvents.TriggerAnimation(GameObject.Find(sceneName + "SelectPanel"), "Select")))
                //.Then(new ActionTask(() => Services.gameEvents.PlayAnimation(sceneName + "SelectPanel " + sceneName + "Select")))
                .Then(new Wait(transitionAnimTime))
                .Then(new ActionTask(Services.sceneTransitionController.RecordScreen))
                .Then(new Wait(transitionFadeTime))
                .Then(new ActionTask(() => WaifForAsyncLoadingWithFade(SceneTransitionControl.TransitionStyle.FADE)));
        }
        else
        {
            LegacyLoadScene(sceneName);
        }
    }

    /*
    * 3d -> 2d
    */
    public void ReloadSceneWithRecord()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        ReloadSceneWithRecord(sceneName);
    }

    public void ReloadSceneWithRecord(string sceneName)
    {
        if (Services.sceneTransitionController)
        {
            LoadingStarted();
            PreloadScene(sceneName);

            Services.taskManager
                .Do(new Wait(transitionButtonTime))
                .Then(new ActionTask(() => Services.sceneTransitionController.FadeIntoLoadingScreen(SceneTransitionControl.TransitionStyle.BLACK)))
                .Then(new Wait(transitionFadeTime))
                .Then(new ActionTask(() => WaifForAsyncLoadingWithFade(SceneTransitionControl.TransitionStyle.BLACK)));
        }
        else
        {
            LegacyLoadScene(sceneName);
        }
    }

    public void LoadSceneWithRecordAndAnimation(string sceneName)
    {
        if (Services.sceneTransitionController)
        {
            LoadingStarted();
            PreloadScene(sceneName);

            Services.taskManager
                .Do(new Wait(transitionButtonTime))
                .Then(new ActionTask(() => Services.sceneTransitionController.FadeIntoLoadingScreen(SceneTransitionControl.TransitionStyle.FADE)))
                .Then(new Wait(transitionFadeTime))
                .Then(new ActionTask(() => WaifForAsyncLoadingWithFade(SceneTransitionControl.TransitionStyle.FADE)));
        }
        else
        {
            LegacyLoadScene(sceneName);
        }
    }

    private void WaifForAsyncLoadingWithFade(SceneTransitionControl.TransitionStyle style)
    {
        StartCoroutine(AsyncLoadingWithFade(style));
    }

    IEnumerator AsyncLoadingWithFade(SceneTransitionControl.TransitionStyle style)
    {
        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
            {
                async.allowSceneActivation = true;
            }

            yield return null;          
        }
    }

    public void LoadingStarted()
    {
        Services.mainController.DisableInput();
    }

    public void LoadingEnded()
    {
        Services.mainController.EnableInput();
    }
}