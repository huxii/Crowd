using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpriteBehavior : ObjectControl
{
    [Header("Rope Sprite")]
    public GameObject weightObj;
    public GameObject ropeObj;
    public float autoDeactiveCD = -1f;
    public GameObject anchorObject = null;

    private GameObject firstSegment;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();

        firstSegment = ropeObj.transform.GetChild(0).gameObject;
        firstSegment.GetComponent<Rigidbody2D>().isKinematic = true;
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

        if (anchorObject != null)
        {
            Vector3 pos = new Vector3(
                anchorObject.transform.position.x,
                anchorObject.transform.position.y,
                transform.position.z
                );

            if (Vector3.Distance(pos, transform.position) > 0.01f)
            {
                firstSegment.GetComponent<Rigidbody2D>().MovePosition(pos);
            }
        }
	}

    public void MoveRope(string para)
    {
        Services.dotweenEvents.MoveRb(firstSegment, para);
    }

    public void MoveRopeTo(string para)
    {
        Services.dotweenEvents.MoveRbTo(firstSegment, para);
    }

    public override void Activate()
    {
        if ((IsActivated() && !canActivateMultipleTimes) || IsLocked())
        {
            return;
        }

        //Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        //foreach (Rigidbody2D rb in rbs)
        //{
        //    //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //    rb.isKinematic = true;
        //}

        base.Activate();
        weightObj.GetComponent<RopeSpriteWeightBehavior>().Activate();
    }

    public override void Deactivate()
    {
        if (!IsActivated())
        {
            return;
        }

        //Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        //foreach (Rigidbody2D rb in rbs)
        //{
        //    //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //    rb.isKinematic = false;
        //}

        base.Deactivate();
        weightObj.GetComponent<RopeSpriteWeightBehavior>().Deactivate();
    }
}
