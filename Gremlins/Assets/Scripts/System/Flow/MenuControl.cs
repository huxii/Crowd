using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    private ScrollRectControl scrollController;

    // Start is called before the first frame update
    void Start()
    {
        scrollController = GameObject.Find("LevelScroll").GetComponent<ScrollRectControl>();
        scrollController.Init();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnStartButtonClicked()
    {
        scrollController.MoveToLevelSelect();        
    }
}
