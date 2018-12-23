using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeFixBehavior : RopeBehavior
{
    public enum DirectionMode
    {
        X,
        Y
    };

    public DirectionMode axis = DirectionMode.Y;
    public float origValue = 0;
    public float targetValue = 0;
    public GameObject anchorObj = null;

    // Use this for initialization
    void Start()
    {
        Init();

        if (axis == DirectionMode.Y)
        {
            mat.SetFloat("_MinY", origValue);
            mat.SetFloat("_MinX", -20);
            mat.SetFloat("_MaxX", 20);
        }
        else
        if (axis == DirectionMode.X)
        {
            mat.SetFloat("_MinX", origValue);
            mat.SetFloat("_MinY", -20);
            mat.SetFloat("_MaxY", 20);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isPlaying || isReversing)
        {
            float curValue = 0;
            if (axis == DirectionMode.Y)
            {
                curValue = mat.GetFloat("_MinY");
                float delta = curSpeed * Time.deltaTime;
                curValue += delta;
                mat.SetFloat("_MinY", curValue);

                if (anchorObj)
                {
                    anchorObj.transform.position = new Vector3(anchorObj.transform.position.x, anchorObj.transform.position.y + delta, anchorObj.transform.position.z);
                }
            }
            else
            if (axis == DirectionMode.X)
            {
                curValue = mat.GetFloat("_MinX");
                float delta = curSpeed * Time.deltaTime;
                curValue += delta;
                mat.SetFloat("_MinX", curValue);

                if (anchorObj)
                {
                    anchorObj.transform.position = new Vector3(anchorObj.transform.position.x + delta, anchorObj.transform.position.y, anchorObj.transform.position.z);
                }
            }

            if (isPlaying)
            {
                curOffset += Time.deltaTime * curSpeed;
                mat.SetFloat("_Offset", curOffset);
                if ((curSpeed > 0 && curValue >= targetValue) || (curSpeed < 0 && curValue <= targetValue))
                {
                    isPlaying = false;
                }
            }
            else
            if (isReversing)
            {
                curOffset += Time.deltaTime * curSpeed;
                mat.SetFloat("_Offset", curOffset);
                if ((curSpeed > 0 && curValue >= origValue) || (curSpeed < 0 && curValue <= origValue))
                {
                    isReversing = false;
                }
            }
        }
	}

    public override void Play()
    {
        base.Play();

        float curValue = 0;
        if (axis == DirectionMode.Y)
        {
            curValue = mat.GetFloat("_MinY");
        }
        else
        if (axis == DirectionMode.X)
        {
            curValue = mat.GetFloat("_MinX");
        }

        curSpeed = (targetValue - curValue) / duration;
    }

    public override void Reverse()
    {
        base.Reverse();

        float curValue = 0;
        if (axis == DirectionMode.Y)
        {
            curValue = mat.GetFloat("_MinY");
        }
        else
        if (axis == DirectionMode.X)
        {
            curValue = mat.GetFloat("_MinX");
        }

        curSpeed = (origValue - curValue) / duration;
    }
}
