using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpriteBehavior : ObjectControl
{
    [Header("Rope Sprite")]
    public GameObject weightObj;
    public GameObject ropeObj;
    public float autoDeactiveCD = -1f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsActivated() && autoDeactiveCD > 0)
        {
            autoDeactiveCD -= Time.deltaTime;
            if (autoDeactiveCD <= 0)
            {
                Deactivate();
            }
        }
	}

    public override void Activate()
    {
        if ((IsActivated() && !canActivateMultipleTimes) || IsLocked())
        {
            return;
        }

        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rb in rbs)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.isKinematic = true;
        }

        base.Activate();
        weightObj.GetComponent<RopeSpriteWeightBehavior>().Activate();
    }

    public override void Deactivate()
    {
        if (!IsActivated())
        {
            return;
        }

        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rb in rbs)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.isKinematic = false;
        }

        base.Deactivate();
        weightObj.GetComponent<RopeSpriteWeightBehavior>().Deactivate();
    }
}
