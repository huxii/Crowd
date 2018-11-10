using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectBasicControl : ObjectControl
{
    [Header("Object Events")]
    public UnityEvent onClick;

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

        interactionTimer = Time.time;
        onClick.Invoke();
    }
}
