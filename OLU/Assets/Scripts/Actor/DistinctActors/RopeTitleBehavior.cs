using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTitleBehavior : MonoBehaviour
{
    public GameObject startAnchor;
    public GameObject endAnchor;

    private GameObject firstSegment;
    private GameObject lastSegment;

    private void Start()
    {
        firstSegment = transform.GetChild(0).gameObject;
        lastSegment = transform.GetChild(transform.childCount - 1).gameObject;

        firstSegment.GetComponent<Rigidbody2D>().isKinematic = true;
        lastSegment.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void Update()
    {
        if (startAnchor != null)
        {
            firstSegment.GetComponent<Rigidbody2D>().MovePosition(startAnchor.transform.position);
        }

        if (endAnchor != null)
        {
            
            lastSegment.GetComponent<Rigidbody2D>().MovePosition(endAnchor.transform.position);
        }
    }

    //bool simulated = true;

    //public void SetSimulated(bool en)
    //{
    //    if (simulated != en)
    //    {
    //        simulated = en;
    //        if (!simulated)
    //        {
    //            SetRigidbodySimulated(en);
    //        }
    //        else
    //        {
    //            Services.taskManager
    //                .Do(new Wait(0.5f))
    //                .Then(new ActionTask(() => SetRigidbodySimulated(en)));
    //        }
    //    }
    //}

    //public void SetRigidbodySimulated(bool en)
    //{
    //    if (simulated == en)
    //    {
    //        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
    //        foreach (Rigidbody2D rb in rbs)
    //        {
    //            rb.simulated = en;
    //            rb.constraints = en ? RigidbodyConstraints2D.None : RigidbodyConstraints2D.FreezeAll;
    //        }

    //        //if (!en)
    //        //{
    //        //    GetComponent<Rope>().UpdateRope(GetComponent<Rope>());
    //        //}

    //        if (!en)
    //        {
    //            foreach (Rigidbody2D rb in rbs)
    //            {
    //                rb.mass = 0.0001f;
    //            }
    //        }
    //        else
    //        {
    //            foreach (Rigidbody2D rb in rbs)
    //            {
    //                rb.mass = 0.1f;
    //            }
    //        }
    //    }
    //}
}
