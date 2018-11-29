using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBasicEventControl : LevelEventControl
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        Done();
    }

    public override void Do()
    {
        base.Do();

        beginEvent.Invoke();
    }
}
