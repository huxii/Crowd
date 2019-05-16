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

    public override void EnableInput()
    {
        base.EnableInput();

        Services.hudController.SetInput(true);
    }

    public override void DisableInput()
    {
        base.DisableInput();

        Services.hudController.SetInput(false);
    }

    public override void OnCameraAngleUpdated()
    {
        base.OnCameraAngleUpdated();

        Vector2 value = scrollController.content.anchoredPosition;
        Services.eventManager.Fire(new ParallaxScrollingEvent(value));
    }

    public void OnStartButtonClicked()
    {
        scrollController.MoveToLevelSelect();        
    }

    public void NextScreen()
    {
        scrollController.NextScreen();
    }

    public void MenuOn(CanvasGroup canvasGroup)
    {
        Services.taskManager
            .Do(new TimedCanvasGroupTask(canvasGroup, canvasGroup.alpha, 1, 0.2f))
            .Then(new ActionTask(() => canvasGroup.interactable = true))
            .Then(new ActionTask(() => canvasGroup.blocksRaycasts = true));
    }

    public void MenuOff(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Services.taskManager
            .Do(new TimedCanvasGroupTask(canvasGroup, canvasGroup.alpha, 0, 0.2f));
    }
}
