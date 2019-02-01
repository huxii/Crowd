using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    AsyncOperation thisAsync;
    AsyncOperation nextAsync;

    AsyncOperation async;

    void Awake()
    {
        thisAsync = null;
        nextAsync = null;
    }

    public int CurrentSceneIdx()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadCurrentScene()
    {
        if (thisAsync == null)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else
        {
            thisAsync.allowSceneActivation = true;
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        return;
    }

    public void PreloadNextScene()
    {
        string currentName = SceneManager.GetActiveScene().name;
        string[] nextNames = currentName.Split('_');
        name = nextNames[0];
        nextAsync = SceneManager.LoadSceneAsync(name);
        nextAsync.allowSceneActivation = false;
    }

    public void PreloadScene()
    {
        thisAsync = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        thisAsync.allowSceneActivation = false;
    }

    public void LoadNextSceneWithTransition()
    {
        Services.sceneTransitionController.GenerateTransitionScreen();
    }

    public void LoadNextScene()
    {
        nextAsync.allowSceneActivation = true;
    }

    public void PreloadScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
    }

    public void LoadSceneWithRecord(string sceneName)
    {
        PreloadScene(sceneName);

        Camera2DControl cam2D = (Camera2DControl)Services.cameraController;
        Services.taskManager
            .Do(new ActionTask(Services.sceneTransitionController.RecordScreen))
            .Then(new ActionTask(WaifForAsyncLoading));
    }

    public void LoadSceneWithZoomAndRecord(string sceneName)
    {
        PreloadScene(sceneName);

        Camera2DControl cam2D = (Camera2DControl)Services.cameraController;
        Services.taskManager
            .Do(new ActionTask(cam2D.ZoomToLevel))
            .Then(new Wait(1))
            .Then(new ActionTask(Services.sceneTransitionController.RecordScreen))
            .Then(new ActionTask(WaifForAsyncLoading));
    }

    public void LoadSceneWithLoadingScreen(string sceneName)
    {
        PreloadScene(sceneName);
        Services.sceneTransitionController.FadeIntoLoadingScreen();

        Services.taskManager
            .Do(new Wait(1))
            .Then(new ActionTask(WaifForAsyncLoading));   
    }

    private void WaifForAsyncLoading()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
            {
                Services.sceneTransitionController.FadeOutOfLoadingScreen();
                async.allowSceneActivation = true;               
            }

            yield return null;          
        }
    }
}