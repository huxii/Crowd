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
        if (Services.sceneTransitionController)
        {
            PreloadScene(sceneName);

            Services.taskManager
                .Do(new ActionTask(Services.mainController.DisableInput))
                .Then(new ActionTask(Services.sceneTransitionController.RecordScreen))
                .Then(new ActionTask(() => WaifForAsyncLoadingWithFade(SceneTransitionControl.TransitionStyle.DOTS)));
        }
        else
        {
            LoadScene(sceneName);
        }
    }

    public void LoadSceneWithZoomAndRecord(string sceneName)
    {
        if (Services.sceneTransitionController)
        {
            PreloadScene(sceneName);

            Services.taskManager
                .Do(new ActionTask(Services.mainController.DisableInput))
                .Then(new ActionTask(Services.sceneTransitionController.RecordScreen))
                .Then(new ActionTask(() => Services.sceneTransitionController.ZoomInTransitionScreen(SceneTransitionControl.TransitionStyle.DOTS)))
                .Then(new Wait(1))
                .Then(new ActionTask(() => WaifForAsyncLoadingWithFade(SceneTransitionControl.TransitionStyle.DOTS)));
        }
        else
        {
            LoadScene(sceneName);
        }
    }

    public void LoadSceneWithLoadingScreen(string sceneName)
    {
        if (Services.sceneTransitionController)
        {
            PreloadScene(sceneName);

            Services.taskManager
                .Do(new ActionTask(Services.mainController.DisableInput))
                .Then(new ActionTask(() => Services.sceneTransitionController.FadeIntoLoadingScreen(SceneTransitionControl.TransitionStyle.DOTS)))
                .Then(new Wait(1))
                .Then(new ActionTask(() => WaifForAsyncLoadingWithFade(SceneTransitionControl.TransitionStyle.DOTS)));
        }
        else
        {
            LoadScene(sceneName);
        }
    }

    /*
    * 3d -> 2d
    */
    public void ReloadSceneWithRecord(string sceneName)
    {
        if (Services.sceneTransitionController)
        {
            PreloadScene(sceneName);

            Services.taskManager
                .Do(new ActionTask(Services.mainController.DisableInput))
                .Then(new ActionTask(() => Services.sceneTransitionController.FadeIntoTransitionScreen(SceneTransitionControl.TransitionStyle.CIRCLE)))
                .Then(new Wait(0.5f))
                .Then(new ActionTask(() => WaifForAsyncLoadingWithFade(SceneTransitionControl.TransitionStyle.CIRCLE)));
        }
        else
        {
            LoadScene(sceneName);
        }
    }

    public void LoadSceneWithRecordAndZoom(string sceneName)
    {
        if (Services.sceneTransitionController)
        {
            PreloadScene(sceneName);

            Services.taskManager
                .Do(new ActionTask(Services.mainController.DisableInput))
                .Then(new ActionTask(() => Services.sceneTransitionController.FadeIntoTransitionScreen(SceneTransitionControl.TransitionStyle.DOTS)))
                .Then(new Wait(1f))
                .Then(new ActionTask(() => WaifForAsyncLoadingWithZoom(SceneTransitionControl.TransitionStyle.DOTS)));
        }
        else
        {
            LoadScene(sceneName);
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
                Services.taskManager
                    .Do(new ActionTask(() => Services.sceneTransitionController.FadeOutOfLoadingScreen(style)))
                    .Then(new Wait(1f))
                    .Then(new ActionTask(Services.mainController.EnableInput));
              
                async.allowSceneActivation = true;
            }

            yield return null;          
        }
    }

    private void WaifForAsyncLoadingWithZoom(SceneTransitionControl.TransitionStyle style)
    {
        StartCoroutine(AsyncLoadingWithZoom(style));
    }

    IEnumerator AsyncLoadingWithZoom(SceneTransitionControl.TransitionStyle style)
    {
        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
            {
                Services.taskManager
                    .Do(new ActionTask(() => Services.sceneTransitionController.ZoomOutTransitionScreen(style)))
                    .Then(new Wait(1f))
                    .Then(new ActionTask(Services.mainController.EnableInput));

                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}