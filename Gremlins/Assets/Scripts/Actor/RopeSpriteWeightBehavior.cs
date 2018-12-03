using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpriteWeightBehavior : ObjectRangeBasedControl
{
    public float resetSpeed = 1f;
    public float resetCD = 0.5f;
    public float swingForce = 1f;

    private Rigidbody2D rb;
    private Vector3 origPos;
    private float resetTimer;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origPos = transform.position;
        RegisterEvents();
    }

    // excute before OnDestroy
    private void OnApplicationQuit()
    {
        UnregisterEvents();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActivated())
        {
            if (rb.isKinematic)
            {
                if (Vector2.Distance(origPos, transform.position) > 0.01f)
                {
                    rb.MovePosition(transform.position + (origPos - transform.position).normalized * Time.deltaTime * resetSpeed);
                }

                resetTimer -= Time.deltaTime;
                if (resetTimer <= 0)
                {
                    rb.isKinematic = false;
                }
            }
        }
        //if (!IsActivated())
        //{
        //    if (rb.isKinematic)
        //    {
        //        if (Vector2.Distance(origPos, transform.position) > 0.01f)
        //        {
        //            rb.MovePosition(transform.position + (origPos - transform.position).normalized * Time.deltaTime * resetSpeed);
        //        }
        //        resetTimer -= Time.deltaTime;
        //        if (resetTimer <= 0)
        //        {
        //            rb.isKinematic = false;
        //        }
        //    }
        //    else
        //    {
        //        if (activeTimer > 0)
        //        {
        //            activeTimer -= Time.deltaTime;
        //        }
        //    }
        //}
    }

    public void LeftSwing()
    {
        if (!IsActivated() && !IsLocked() && !IsCoolingDown())
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.AddForce(-transform.right * swingForce, ForceMode2D.Impulse);

            CoolDown();
        }
    }

    public void RightSwing()
    {
        if (!IsActivated() && !IsLocked() && !IsCoolingDown())
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.AddForce(transform.right * swingForce, ForceMode2D.Impulse);

            CoolDown();
        }
    }

    public void ResetSwing()
    {
        //Debug.Log(")))");
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        rb.isKinematic = true;

        resetTimer = resetCD;
        CoolDown();
    }

    public override void Activate()
    {
        base.Activate();

        ResetSwing();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}
