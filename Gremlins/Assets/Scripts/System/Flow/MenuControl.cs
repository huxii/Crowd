using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    private ScrollRectControl scrollController;

    private float setDraggingCD = 1f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        scrollController = GameObject.Find("LevelScroll").GetComponent<ScrollRectControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                scrollController.SetDragging(true);
                scrollController.NextScreen();
            }
        }
    }

    public void OnStartButtonClicked()
    {
        scrollController.SetDragging(false);
        scrollController.UnlockNextScreen();

        timer = setDraggingCD;
    }
}
