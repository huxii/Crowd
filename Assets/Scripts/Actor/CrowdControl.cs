using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrowdControl : ActorControl
{
    public UnityEvent onSelected;
    public UnityEvent onDeselected;

    public float speed = 5f;

    enum CrowdState
    {
        IDLE,
        BUSY
    };

    CrowdState state = CrowdState.IDLE;

    private GameObject workingObject = null;
    private int workingSlot = -1;

    private bool isMoving = false;
    private Vector3 targetPos;
    private float targetPosTol = 0f;
    private Rigidbody rb;

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
        //if (isMoving)
        {
            if (Vector3.Distance(targetPos, transform.position) > targetPosTol)
            {
                Debug.Log(gameObject.name + " " + transform.position + " " + targetPos);
                //rb.velocity = (targetPos - transform.position).normalized * speed;
                rb.MovePosition(transform.position + (targetPos - transform.position).normalized * speed * Time.deltaTime);
            }
            //else
            //{
            //    isMoving = false;
            //}
        }
    }

    void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, targetPosTol);
    }

    public bool IsBusy()
    {
        return (state == CrowdState.BUSY);
    }

    public void SetWorkingObject(GameObject obj, int slot)
    {
        workingObject = obj;
        workingSlot = slot;
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

    public void MoveTo(Vector3 pos, float tol)
    {
        isMoving = true;
        targetPos = pos;
        targetPosTol = tol;
    }
}
