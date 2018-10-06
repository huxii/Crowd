using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CrowdControl : ActorControl
{
    public UnityEvent onSelected;
    public UnityEvent onDeselected;

    public float speed = 5f;

    private GameObject workingObject = null;
    private int workingSlot = -1;

    private bool isMoving = false;
    private Vector3 targetPos;
    private float targetPosTol = 0f;
    private Rigidbody rb;

    private GameObject onObj = null;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            if (Vector3.Distance(targetPos, transform.position) > targetPosTol)
            {
                Debug.Log(gameObject.name + " " + transform.position + " " + targetPos);
                //rb.velocity = (targetPos - transform.position).normalized * speed;
                rb.MovePosition(transform.position + (targetPos - transform.position).normalized * speed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnDrawGizmos()
    {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.up, targetPosTol);
    }

    private void SetKinematic(bool isKinematic)
    {
        rb.isKinematic = isKinematic;
    }

    public bool IsBusy()
    {
        return (workingObject != null);
    }

    public void SetWorkingObject(GameObject obj, int slot)
    {
        workingObject = obj;
        workingSlot = slot;

        if (obj == null)
        {
            SetKinematic(false);
        }
        else
        {
            SetKinematic(true);
        }
    }

    public GameObject GetWorkingObject()
    {
        return workingObject;
    }

    public int GetWorkingSlot()
    {
        return workingSlot;
    }

    public void Selected()
    {
        onSelected.Invoke();
    }

    public void Deselected()
    {
        onDeselected.Invoke();
    }

    public void Stop()
    {
        isMoving = false;
    }

    public void MoveTo(Vector3 pos, float tol)
    {
        isMoving = true;
        targetPos = pos;
        targetPosTol = tol;
    }

    public void WalkAcross(GameObject obj)
    {
        //if (onObj == obj)
        //{
        //    onObj = null;
        //    SetKinematic(false);
        //}
        //else
        //{
        //    onObj = obj;
        //    SetKinematic(true);
        //}
    }

    public void OrderFailed()
    {
        Color origColor = GetComponentInChildren<MeshRenderer>().material.color;
        Sequence newSeq = DOTween.Sequence();
        newSeq.Append(GetComponentInChildren<MeshRenderer>().material.DOColor(new Color(1.0f, 0.0f, 0.0f), 0.1f));
        newSeq.Append(GetComponentInChildren<MeshRenderer>().material.DOColor(origColor, 0.1f).SetDelay(0.3f));
    }
}
