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

    public void OnStartButtonClicked()
    {
        scrollController.MoveToLevelSelect();        
    }

    public void NextScreen()
    {
        scrollController.NextScreen();
    }
}
