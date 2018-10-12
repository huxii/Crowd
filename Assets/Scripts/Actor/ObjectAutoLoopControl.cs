using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectAutoLoopControl : ObjectAutoControl
{
    [Header("Loop Settings")]
    public float loopInterval = 1f;
    public UnityEvent loopEvent;
    public UnityEvent doubleLoopEvent;

    private float timer = 0;
    private float doubleTimer = 0;

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
            doubleTimer += Time.deltaTime;
            if (timer >= loopInterval)
            {
                loopEvent.Invoke();
                timer = 0;
            }

            if (doubleTimer >= 2 * loopInterval)
            {
                doubleLoopEvent.Invoke();
                doubleTimer = 0;
            }
        }
	}

    public override void Activate()
    {
        base.Activate();

        timer = loopInterval / 2;
        doubleTimer = 2 * loopInterval - loopInterval / 2;
    }
}
