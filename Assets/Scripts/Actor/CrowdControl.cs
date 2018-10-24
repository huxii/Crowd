using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CrowdControl : ActorControl
{
    public UnityEvent onIdle;
    public UnityEvent onSelected;
    public UnityEvent onDeselected;
    public UnityEvent onOrderFailed;
    public UnityEvent onReadyToPush;

    public float speed = 5f;

    private GameObject workingObject = null;
    private int workingSlot = -1;

    private bool isMoving = false;
    private Vector3 targetPos;
    private float targetPosTol = 0f;
    private Rigidbody rb;

    private GameObject onObj = null;
    private Sequence matSeq = null;

    private float stateTimer = 0;
    private float stateInterval = 2.0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateTimer > 0)
        {
            stateTimer -= Time.deltaTime;
            if (stateTimer <= 0)
            {
                Idle();
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 0);
        if (isMoving)
        {
            if (Vector3.Distance(targetPos, transform.position) > targetPosTol)
            {
                Debug.Log(gameObject.name + " " + transform.position + " " + targetPos + " " + (targetPos - transform.position).normalized * speed);
                //rb.velocity = (targetPos - transform.position).normalized * speed; 
                rb.MovePosition(transform.position + (targetPos - transform.position).normalized * speed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
            }
        }
    }

    void OnDrawGizmos()
    {
        //Handles.color = Color.yellow;
        //Handles.DrawWireDisc(transform.position, Vector3.up, targetPosTol);
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

    public void Selected()
    {
        onSelected.Invoke();
    }

    public void Deselected()
    {
        onDeselected.Invoke();
    }

    //public void WalkAcross(GameObject obj)
    //{
    //    if (onObj == obj)
    //    {
    //        onObj = null;
    //        SetKinematic(false);
    //    }
    //    else
    //    {
    //        onObj = obj;
    //        SetKinematic(true);
    //    }
    //}
    public void LoadSucceeded()
    {
        int id = Random.Range(0, 3) + 1;
        Services.soundController.Play("canDo" + id);
    }

    public void WalkSucceeded()
    {
        int id = Random.Range(0, 2) + 1;
        Services.soundController.Play("walkTo" + id);
    }

    public void OrderFailed()
    {
        stateTimer = stateInterval;
        onOrderFailed.Invoke();

        int id = Random.Range(0, 2) + 1;
        Services.soundController.Play("noWay" + id);
    }

    public void ReadyToPush()
    {
        //stateTimer = stateInterval;
        onReadyToPush.Invoke();
    }

    public void Idle()
    {
        onIdle.Invoke();
    }
}
