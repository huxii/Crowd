using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RopeBehavior : MonoBehaviour
{
    public float duration = 1f;

    protected bool isPlaying = false;
    protected bool isReversing = false;
    protected Material mat;
    protected float curSpeed;
    protected float curOffset = 0;

    protected virtual void Start()
    {
        mat = GetComponentInChildren<MeshRenderer>().material;
        mat.SetFloat("_Offset", 0);
    }

	// Update is called once per frame
	void Update ()
    {
	}

    public virtual void Play()
    {
        isPlaying = true;
    }

    public virtual void Reverse()
    {
        isReversing = true;
    }
}
