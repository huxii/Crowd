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

    public override void UpdateParallaxScrolling()
    {
        base.UpdateParallaxScrolling();

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
}
