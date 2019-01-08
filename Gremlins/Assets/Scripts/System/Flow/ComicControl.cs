using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicControl : MainControl
{
    AsyncOperation async;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        string currentName = SceneManager.GetActiveScene().name;
        string[] nextNames = currentName.Split('_');
        async = SceneManager.LoadSceneAsync(nextNames[0]);
        async.allowSceneActivation = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public override void Ending()
    {
        base.Ending();

        async.allowSceneActivation = true;
    }
}
