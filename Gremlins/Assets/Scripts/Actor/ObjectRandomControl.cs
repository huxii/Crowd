using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectRandomControl : ObjectBasicControl
{
    public List<UnityEvent> randomClickEvents;
    public bool isAutoPlaying = false;

    private float autoPlayingCD;
    private float autoPlayingTimer;

    // Use this for initialization
    void Start()
    {
        base.Start();
        
        SetAutoPlayingCD();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutoPlaying)
        {
            if (CanActivate())
            {
                if (autoPlayingTimer > 0)
                {
                    autoPlayingTimer -= Time.deltaTime;
                    if (autoPlayingTimer <= 0)
                    {
                        DoRandomEvent();
                    }
                }
            }
        }
    }

    private void SetAutoPlayingCD()
    {
        autoPlayingCD = Random.Range(1, 3);
        autoPlayingTimer = autoPlayingCD;
    }

    private void DoRandomEvent()
    {
        CoolDown();
        SetAutoPlayingCD();

        int randomPick = Random.Range(0, randomClickEvents.Count);
        randomClickEvents[randomPick].Invoke();
    }

    public override void Click()
    {
        //base.Click();

        if (CanActivate())
        {
            onClick.Invoke();

            DoRandomEvent();
        }
    }
}
