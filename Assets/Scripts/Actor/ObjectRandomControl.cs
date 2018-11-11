using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectRandomControl : ObjectControl
{
    public List<UnityEvent> onClicks;

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

            int randomPick = Random.Range(0, onClicks.Count);
            onClicks[randomPick].Invoke();
        }
    }
}
