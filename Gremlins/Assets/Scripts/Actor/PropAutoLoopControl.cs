using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 *      Constantly invoke loopEvent according to the loopInterval
 */

public class PropAutoLoopControl : PropAutoControl
{
    [Header("Loop Settings")]
    public float loopInterval = 1f;
    public float startDelay = 0f;
    public UnityEvent loopEvent;
    public UnityEvent singleLoopEvent;
    public UnityEvent doubleLoopEvent;

    private float timer = 0;
    private int loopCounter = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if (IsActivated())
        {
            timer += Time.deltaTime;
            if (timer >= loopInterval)
            {
                loopEvent.Invoke();
                timer = 0;
                ++loopCounter;
                if (loopCounter - loopCounter / 2 * 2 == 1)
                {
                    singleLoopEvent.Invoke();
                }
                else
                {
                    doubleLoopEvent.Invoke();
                }
            }
        }
	}

    public override void Activate()
    {
        base.Activate();

        timer = loopInterval - Mathf.Min(startDelay, loopInterval);
    }
}
