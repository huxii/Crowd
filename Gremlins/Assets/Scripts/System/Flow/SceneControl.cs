using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    AsyncOperation async;

    void Awake()
    {
        async = null;
    }

    public int CurrentSceneIdx()
    {
        return SceneManager.GetActiveScene().buildIndex;
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
    public void LoadSceneWithRecord(string sceneName)
    {
        PreloadScene(sceneName);

        Services.taskManager
            .Do(new ActionTask(Services.mainController.DisableInput))
            .Then(new ActionTask(Services.sceneTransitionController.RecordScreen))
            .Then(new ActionTask(WaifForAsyncLoadingWithFade));
    }

    public void LoadSceneWithZoomAndRecord(string sceneName)
    {
        PreloadScene(sceneName);

        //Services.taskManager
        //    .Do(new ActionTask(ZoomToLevel))
        //    .Then(new Wait(1))
        //    .Then(new ActionTask(Services.sceneTransitionController.RecordScreen))
        //    .Then(new ActionTask(WaifForAsyncLoadingWithFade));

        Services.taskManager
            .Do(new ActionTask(Services.mainController.DisableInput))
            .Then(new ActionTask(Services.sceneTransitionController.RecordScreen))
            .Then(new ActionTask(Services.sceneTransitionController.ZoomInTransitionScreen))
            .Then(new Wait(1))
            .Then(new ActionTask(WaifForAsyncLoadingWithFade));
    }

    public void LoadSceneWithLoadingScreen(string sceneName)
    {
        PreloadScene(sceneName);

        Services.taskManager
            .Do(new ActionTask(Services.mainController.DisableInput))
            .Then(new ActionTask(Services.sceneTransitionController.FadeIntoLoadingScreen))
            .Then(new Wait(1))
            .Then(new ActionTask(WaifForAsyncLoadingWithFade));   
    }
    
    /*
    * 3d -> 2d
    */
    public void ReloadSceneWithRecord(string sceneName)
    {
        PreloadScene(sceneName);

        Services.taskManager
            .Do(new ActionTask(Services.mainController.DisableInput))
            .Then(new ActionTask(Services.sceneTransitionController.FadeIntoTransitionScreen))
            .Then(new Wait(1f))
            .Then(new ActionTask(WaifForAsyncLoadingWithFade));
    }

    public void LoadSceneWithRecordAndZoom(string sceneName)
    {
        PreloadScene(sceneName);

        Services.taskManager
            .Do(new ActionTask(Services.mainController.DisableInput))
            .Then(new ActionTask(Services.sceneTransitionController.FadeIntoTransitionScreen))
            .Then(new Wait(1f))
            .Then(new ActionTask(WaifForAsyncLoadingWithZoom));
    }

    private void WaifForAsyncLoadingWithFade()
    {
        StartCoroutine(AsyncLoadingWithFade());
    }

    IEnumerator AsyncLoadingWithFade()
    {
        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
            {
                Services.taskManager
                    .Do(new ActionTask(Services.sceneTransitionController.FadeOutOfLoadingScreen))
                    .Then(new Wait(1f))
                    .Then(new ActionTask(Services.mainController.EnableInput));
              
                async.allowSceneActivation = true;
            }

            yield return null;          
        }
    }

    private void WaifForAsyncLoadingWithZoom()
    {
        StartCoroutine(AsyncLoadingWithZoom());
    }

    IEnumerator AsyncLoadingWithZoom()
    {
        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
            {
                Services.taskManager
                    .Do(new ActionTask(Services.sceneTransitionController.ZoomOutTransitionScreen))
                    .Then(new Wait(1f))
                    .Then(new ActionTask(Services.mainController.EnableInput));

                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}