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

    public void LoadSceneWithLoadingScreen(string sceneName)
    {
        PreloadScene(sceneName);
        Services.sceneTransitionController.FadeIntoLoadingScreen();

        // wait for fade out
        StartCoroutine(WaitForTransition(1));        
    }

    IEnumerator WaitForTransition(float time)
    {
        yield return new WaitForSeconds(time);

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