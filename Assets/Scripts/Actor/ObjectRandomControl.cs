using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectRandomControl : ObjectControl
{
    public UnityEvent onClick;
    public List<UnityEvent> randomClickEvents;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Click()
    {
        base.Click();

        if (!IsCoolingDown() && !IsActivated())
        {
            CoolDown();

            onClick.Invoke();

            int randomPick = Random.Range(0, randomClickEvents.Count);
            randomClickEvents[randomPick].Invoke();
        }
    }
}
