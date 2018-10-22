using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehavior : MonoBehaviour
{
    public float origY = 0;
    public float targetY = 0;
    public float duration = 0;
    public GameObject anchorObj = null;

    private bool isPlaying = false;
    private bool isReversing = false;
    private Material mat;
    private float curSpeed;
    private float timer = 0;

	// Use this for initialization
	void Start ()
    {
        mat = GetComponentInChildren<MeshRenderer>().material;
        mat.SetFloat("_MinY", origY);
        mat.SetFloat("_Offset", 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isPlaying || isReversing)
        {
            float minY = mat.GetFloat("_MinY");
            float deltaY = curSpeed * Time.deltaTime;
            minY += deltaY;
            mat.SetFloat("_MinY", minY);
            anchorObj.transform.position = new Vector3(anchorObj.transform.position.x, anchorObj.transform.position.y + deltaY, anchorObj.transform.position.z);         

            if (isPlaying)
            {
                timer += Time.deltaTime * curSpeed * 0.1f;
                mat.SetFloat("_Offset", timer);
                if ((curSpeed > 0 && minY >= targetY) || (curSpeed < 0 && minY <= targetY))
                {
                    isPlaying = false;
                }
            }
            else
            if (isReversing)
            {
                timer += Time.deltaTime * curSpeed * 0.1f;
                mat.SetFloat("_Offset", timer);
                if ((curSpeed > 0 && minY >= origY) || (curSpeed < 0 && minY <= origY))
                {
                    isReversing = false;
                }
            }
        }
	}

    public void Play()
    {
        isPlaying = true;

        float curY = mat.GetFloat("_MinY");
        curSpeed = (targetY - curY) / duration;
    }

    public void Reverse()
    {
        isReversing = true;

        float curY = mat.GetFloat("_MinY");
        curSpeed = (origY - curY) / duration;
    }
}
