using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using BehaviorTree;

/*
 *      Control the men
 */

public class CrowdControl : ActorControl
{
    public enum CrowdState
    {
        IDLE,
        WALK,
        CLIMB,
        PULL,
        PUSH,
        RIDE,
        DROP,
        CELEBRATE,
        CONFUSED,
    };

    // the events when the man is selected/deselected. (removed already)
    public UnityEvent onSelected;
    public UnityEvent onDeselected;

    // the moving speed
    public float speed = 5f;

    // behavior tree to control the animations and states
    // this part is not easy to understand by a couple of lines of comments, let me know if you are interested in it.
    private Tree<CrowdControl> btree;
    [SerializeField]
    private CrowdState state = CrowdState.IDLE;
    private CrowdState lastState = CrowdState.IDLE;
    private float stateCoolingDown = 0;
    private float stateMagicNumber = -373737;

    // spine animation
    private SpineAnimationControl spineAnimController = null;

    // the object and slot that the man is working on
    // when workingObject == null || workingSlot == -1, the man is not working on anything
    private GameObject workingObject = null;
    private int workingSlot = -1;

    // the man is constantly moving towards targetPos by its RigidBody
    private bool isMoving = false;
    private Vector3 targetPos;
    private float targetPosTol = 0f;
    private Rigidbody rb;

    // the voice of a man
    private float voiceCoolDown = 3f;
    private float[] voiceTimer = new float[3];

    // Use this for initialization
    void Start()
    {
        SwitchState(CrowdState.IDLE);

        rb = GetComponent<Rigidbody>();
        targetPos = transform.position;

        spineAnimController = GetComponent<SpineAnimationControl>();

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
        if (!IsLocked())
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
                new Sequence<CrowdControl>(
                    new IsCelebrating(),
                    new Celebrating()
                    ),

                new Sequence<CrowdControl>(
                    new IsClimbing(),
                    new Climbing()
                    ),

                new Sequence<CrowdControl>(
                    new IsMoving(),
                    new Moving()
                    ),

                new Sequence<CrowdControl>(
                    new IsPushing(),
                    new Pushing()
                    ),

                new Sequence<CrowdControl>(
                    new IsPulling(),
                    new Pulling()
                    ),

                new Sequence<CrowdControl>(
                    new IsRiding(),
                    new Riding()
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

    // voice cool down
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

    public bool IsThisMoving()
    {
        return isMoving;
    }

    // the man will be set to kinematic when it gets on an working slot 
    // so that it won't be affected by physics
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

    // set the targetPos so that the man will be moving towards it
    // mainly invoked by PathFinder
    public void MoveTo(Vector3 pos, float tol, CrowdState s)
    {
        isMoving = true;
        targetPos = pos;
        targetPosTol = tol;
        SwitchState(s);
    }

    public void Selected()
    {
        onSelected.Invoke();
    }

    public void Deselected()
    {
        onDeselected.Invoke();
    }

    // successfully get on a working slot
    public void LoadSucceeded()
    {
        if (voiceTimer[0] <= 0)
        {
            int id = Random.Range(0, 4) + 1;
            Services.soundController.Play("canDo" + id);
            voiceTimer[0] = voiceCoolDown;
        }
    }

    // successfully walk to a place
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

    // failed
    public void OrderFailed()
    {
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
        if (s == CrowdState.CONFUSED && state != CrowdState.CONFUSED)
        {
            lastState = state;
        }
        state = s;
        stateCoolingDown = stateMagicNumber;
    }

    public void Flip(float p)
    {
        transform.localScale = new Vector3(
            p,
            transform.localScale.y,
            transform.localScale.z
            );
    }

    ////////////////////
    // Conditions
    ////////////////////
    private class IsCelebrating : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.CELEBRATE;
        }
    }

    private class IsMoving : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            if (man.state == CrowdState.WALK)
            {
                if (man.isMoving)
                {
                    return true;
                }
                else
                {
                    man.SwitchState(CrowdState.IDLE);
                    return false;
                }
            }

            return false;
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

    private class IsPulling : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.PULL;
        }
    }

    private class IsRiding : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.RIDE;
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

    private abstract class TimedAction : Node<CrowdControl>
    {
        protected float interval;

        public override bool Update(CrowdControl man)
        {
            if (man.stateCoolingDown == man.stateMagicNumber)
            {
                OnStart(man);
            }
            else
            {
                if (man.stateCoolingDown > 0)
                {
                    man.stateCoolingDown -= Time.deltaTime;

                    //Sprite sprite = Resources.Load<Sprite>("Sprites/Character/confuse");
                    //man.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
                }
                else
                {
                    OnInterval(man);
                }
            }

            return true;
        }

        public virtual void OnStart(CrowdControl man)
        {
        }

        public virtual void OnInterval(CrowdControl man)
        {
            man.stateCoolingDown = interval;
        }
    }

    private class Moving : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            man.spineAnimController.SetAnimation("walk_normal", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);
            man.spineAnimController.SetRandomAnimation("arm");
            return true;
        }
    }

    private class Climbing : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            man.spineAnimController.SetAnimation("walk_normal", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);
            return true;
        }
    }

    private class Pushing : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            man.spineAnimController.SetAnimation("push", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);
            //if (man.transform.hasChanged)
            //{
            //    man.spineAnimController.SetAnimation("feet_push");
            //    man.transform.hasChanged = false;
            //}
            return true;
        }
    }

    private class Pulling : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            man.spineAnimController.SetAnimation("pull", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);
            //if (man.transform.hasChanged)
            //{
            //    man.spineAnimController.SetAnimation("feet_push");
            //    man.transform.hasChanged = false;
            //}
            return true;
        }
    }

    private class Riding : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            man.spineAnimController.SetAnimation("idle_wiggle", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);
            return true;
        }
    }

    private class Celebrating : TimedAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            interval = 10000000000;
            man.stateCoolingDown = interval;

            if (!man.IsBusy())
            {
                man.spineAnimController.SetAnimation("cheers_face", SpineAnimationControl.ClearPolicy.CLEARALL);
                man.spineAnimController.SetRandomAnimation("cheers", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL, "cheers_face");
            }
            else
            {
                man.spineAnimController.SetAnimation("cheers_face", SpineAnimationControl.ClearPolicy.CLEARFACIAL);
            }
        }

        public override void OnInterval(CrowdControl man)
        {
            base.OnInterval(man);
        }
    }

    private class Confused : TimedAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            interval = 2f;
            man.stateCoolingDown = interval;
            man.spineAnimController.SetRandomAnimation("confuse", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);
        }

        public override void OnInterval(CrowdControl man)
        {
            base.OnInterval(man);

            man.SwitchState(man.lastState);
        }
    }

    private class Idling : TimedAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            interval = Random.Range(3f, 8f);
            man.stateCoolingDown = interval;

            man.spineAnimController.SetAnimation("idle_wiggle", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);          
        }

        public override void OnInterval(CrowdControl man)
        {
            base.OnInterval(man);

            man.spineAnimController.SetRandomAnimation("idle", SpineAnimationControl.ClearPolicy.CLEARNOTFACIAL);
        }
    }
}
