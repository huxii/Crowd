using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLoopBehavior : RopeBehavior
{
    public float speed = 10f;
    public float minX = 0;
    public float maxX = 0;
    public float minY = 0;
    public float maxY = 0;

    [SerializeField]
    private float timer = 0;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        mat.SetFloat("_MinY", minY);
        mat.SetFloat("_maxY", maxY);
        mat.SetFloat("_MinX", minX);
        mat.SetFloat("_MaxX", maxX);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isPlaying || isReversing)
        {
            curOffset += curSpeed * Time.deltaTime;
            mat.SetFloat("_Offset", curOffset);

            timer += Time.deltaTime;
            if (timer >= duration)
            {
                isPlaying = false;
                isReversing = false;
            }
        }
	}

    public override void Play()
    {
        base.Play();

        curSpeed = speed;
        timer = 0;
    }

    public override void Reverse()
    {
        base.Reverse();

        curSpeed = -speed;
        timer = 0;
    }
}
