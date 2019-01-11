using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicControl : MainControl
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Services.sceneController.PreloadNextScene();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public override void Ending()
    {
        base.Ending();

        Debug.Log("End");
        Services.sceneController.LoadNextSceneWithTransition();
    }
}
