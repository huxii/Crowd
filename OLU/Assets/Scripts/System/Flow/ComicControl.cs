using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicControl : MainControl
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        //Services.sceneController.PreloadNextScene();
    }

    public override void Ending(bool cleared)
    {
        base.Ending(cleared);

        Debug.Log("End");
        //Services.sceneController.LoadSceneWithRecord("Level0");
    }
}
