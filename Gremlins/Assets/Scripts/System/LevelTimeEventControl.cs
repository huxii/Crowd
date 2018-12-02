using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimeEventControl : LevelEventControl
{
    public float delayTime = 0f;

    protected float timer = -1;

    // Use this for initialization
    //void Start()
    //{
    //    if (happenOnAwake)
    //    {
    //        TriggerEvent();
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                TriggerEvent();
            }
        }
    }

    public override void Do()
    {
        base.Do();

        timer = delayTime;
    }
}
