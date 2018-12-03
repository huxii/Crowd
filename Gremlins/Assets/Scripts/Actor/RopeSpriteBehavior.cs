using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpriteBehavior : ObjectControl
{
    public GameObject weightObj;
    public GameObject ropeObj;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override void Activate()
    {
        base.Activate();

        weightObj.GetComponent<RopeSpriteWeightBehavior>().Activate();
        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rb in rbs)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        weightObj.GetComponent<RopeSpriteWeightBehavior>().Deactivate();
        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rb in rbs)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
