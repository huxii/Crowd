using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicEvents : CustomEvents
{
    private Animation anim;
    private List<string> animNames;
    private int animIdx;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

        animNames = new List<string>();
        foreach (AnimationState animState in anim)
        {
            animNames.Add(animState.clip.name);
        }
        animIdx = 0;

        anim.Play(animNames[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
        //    Resume();
        //}
    }

    public void Pause()
    {
        if (animIdx < animNames.Count)
        {
            anim[animNames[animIdx]].speed = 0;
        }
    }

    public void Resume()
    {
        if (animIdx < animNames.Count)
        {
            anim[animNames[animIdx]].speed = 1;
        }
    }

    public void Next()
    {
        ++animIdx;
        if (animIdx < animNames.Count)
        {
            anim.Play(animNames[animIdx]);
        }
        else
        {
            Services.mainController.Ending();
        }
    }
}
