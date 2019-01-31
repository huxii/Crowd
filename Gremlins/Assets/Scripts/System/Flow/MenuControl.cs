using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MainControl
{
    private ScrollRectControl scrollController;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        scrollController = GameObject.Find("LevelScroll").GetComponent<ScrollRectControl>();
        scrollController.Init();
    }

    protected override void RegisterEvents()
    {
        Services.eventManager.Register<TransitionFadeOut>(OnTransitionFadeOut);
    }

    protected override void UnregisterEvents()
    {
        Services.eventManager.Unregister<TransitionFadeOut>(OnTransitionFadeOut);
    }

    void OnTransitionFadeOut(Crowd.Event e)
    {
        Debug.Log("fade out");
        Services.sceneController.ContinueLoadingSceneWithTransition();
    }

    public void OnStartButtonClicked()
    {
        scrollController.MoveToLevelSelect();        
    }

    public void NextScreen()
    {
        scrollController.NextScreen();
    }
}
