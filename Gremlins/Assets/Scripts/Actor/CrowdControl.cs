using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using BehaviorTree;

public class CrowdControl : ActorControl
{
    public enum CrowdState
    {
        IDLE,
        WALK,
        CLIMB,
        DROP,
        PUSH,
        CONFUSED,
    };

    public UnityEvent onSelected;
    public UnityEvent onDeselected;

    public float speed = 5f;

    private Tree<CrowdControl> btree;
    [SerializeField]
    private CrowdState state = CrowdState.IDLE;
    private float stateCoolingDown = 0;
    private float stateInterval = 2.0f;

    private GameObject workingObject = null;
    private int workingSlot = -1;

    private bool isMoving = false;
    private Vector3 targetPos;
    private float targetPosTol = 0f;
    private Rigidbody rb;

    private GameObject onObj = null;
    private Sequence matSeq = null;

    private float voiceCoolDown = 3f;
    private float[] voiceTimer = new float[3];

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPos = transform.position;

        InitBehaviorTree();
    }

    // Update is called once per frame
    void Update()
    {
        btree.Update(this);
        CoolDown();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 0);
        if (isMoving)
        {
            if (Vector3.Distance(targetPos, transform.position) > targetPosTol)
            {
                //Debug.Log(gameObject.name + " " + transform.position + " " + targetPos + " " + (targetPos - transform.position).normalized * speed);
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

    private void InitBehaviorTree()
    {
        btree = new Tree<CrowdControl>(
            new Selector<CrowdControl>(

                // Special case: it's on the puddle

                // Decide if it's dropping

                // Decide if it's climbing by the target y position
                new Sequence<CrowdControl>(
                    new IsClimbing(),
                    new Climbing()
                    ),

                // Decide if it's climbing by the target position
                new Sequence<CrowdControl>(
                    new IsMoving(),
                    new Moving()
                    ),

                new Sequence<CrowdControl>(
                    new IsPushing(),
                    new Pushing()
                    ),

                new Sequence<CrowdControl>(
                    new IsConfused(),
                    new Confused()
                    ),

                new Sequence<CrowdControl>(
                    new Idling()
                    )
                )
            );
    }

    private void CoolDown()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (voiceTimer[i] > 0)
            {
                voiceTimer[i] -= Time.deltaTime;
            }
        }
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

    public void MoveTo(Vector3 pos, float tol, CrowdState s)
    {
        isMoving = true;
        targetPos = pos;
        targetPosTol = tol;
        state = s;
    }

    public void Selected()
    {
        onSelected.Invoke();
    }

    public void Deselected()
    {
        onDeselected.Invoke();
    }

    public void LoadSucceeded()
    {
        if (voiceTimer[0] <= 0)
        {
            int id = Random.Range(0, 4) + 1;
            Services.soundController.Play("canDo" + id);
            voiceTimer[0] = voiceCoolDown;
        }
    }

    public void WalkSucceeded()
    {
        if (voiceTimer[1] <= 0)
        {
            int id = Random.Range(0, 3) + 1;
            //Debug.Log("walkTo" + id);
            Services.soundController.Play("walkTo" + id);
            voiceTimer[1] = voiceCoolDown;
        }
    }

    public void OrderFailed()
    {
        stateCoolingDown = stateInterval;
        SwitchState(CrowdState.CONFUSED);

        if (voiceTimer[2] <= 0)
        {
            int id = Random.Range(0, 3) + 1;
            Services.soundController.Play("noWay" + id);
            voiceTimer[2] = voiceCoolDown;
        }
    }

    public void SwitchState(CrowdState s)
    {
        state = s;
    }

    ////////////////////
    // Conditions
    ////////////////////
    private class IsMoving : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.WALK;
        }
    }

    private class IsClimbing : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.CLIMB;
        }
    }

    private class IsPushing : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.PUSH;
        }
    }

    private class IsConfused : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.CONFUSED;
        }
    }

    private class IsIdling : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.IDLE;
        }
    }

    ///////////////////
    /// Actions
    ///////////////////
    private class Moving : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/Character/idle");
            man.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            return true;
        }
    }

    private class Climbing : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/Character/idle");
            man.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            return true;
        }
    }

    private class Pushing : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/Character/push");
            man.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            return true;
        }
    }

    private class Confused : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            if (man.stateCoolingDown > 0)
            {
                man.stateCoolingDown -= Time.deltaTime;

                Sprite sprite = Resources.Load<Sprite>("Sprites/Character/confuse");
                man.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            }
            else
            {
                man.SwitchState(CrowdState.IDLE);
            }

            return true;
        }
    }

    private class Idling : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            Sprite sprite = Resources.Load<Sprite>("Sprites/Character/idle");
            man.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            return true;
        }
    }
}
