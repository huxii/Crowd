using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    AsyncOperation thisAsync;
    AsyncOperation nextAsync;

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
}