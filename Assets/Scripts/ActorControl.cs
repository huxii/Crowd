using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorControl : MonoBehaviour
{
    protected Vector3 actorScreenPos;
    protected Vector3 mouseWorldPos;
    protected Vector3 deltaMouseWorldPos;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    protected virtual void MouseDown()
    {
    }

    protected virtual void MouseUp()
    {
    }

    protected virtual void MouseDrag()
    {
    }

    public void OnMouseDown()
    {
        actorScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, actorScreenPos.z));

        MouseDown();
    }

    public void OnMouseUp()
    {
        MouseUp();
    }

    public void OnMouseDrag()
    {
        Vector3 curMouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, actorScreenPos.z));
        deltaMouseWorldPos = curMouseWorldPos - mouseWorldPos;
        mouseWorldPos = curMouseWorldPos;

        MouseDrag();
    }
}
