using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectAutoLoopControl : ObjectAutoControl
{
    [Header("Loop Settings")]
    public float loopInterval = 1f;
    public UnityEvent loopEvent;

    private float timer = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsActivated())
        {
            timer += Time.deltaTime;
            if (timer >= loopInterval)
            {
                loopEvent.Invoke();
                timer = 0;
            }
        }
	}

    public override void Activate()
    {
        base.Activate();

        timer = 0.5f;
    }
}
