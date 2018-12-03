using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorBehavior : MonoBehaviour
{
    public GameObject parentObject;
    public Vector3 offset;

    public bool copyRotation = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = parentObject.transform.position + offset;
        if (copyRotation)
        {
            transform.rotation = parentObject.transform.rotation;
        }
	}
}
