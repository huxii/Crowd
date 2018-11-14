using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorBehavior : MonoBehaviour
{
    public GameObject parentObject;
    public Vector3 offset;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = parentObject.transform.position + offset;
	}
}
