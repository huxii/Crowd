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
[RequireComponent(typeof(CrowdFeedbackBehavior))]

public class CrowdControl : ActorControl
{
    public CrowdFeedbackBehavior CrowdFeedbackController
    {
        get { return (CrowdFeedbackBehavior)feedbackController; }
        set { feedbackController = value; }
    }

    public enum CrowdState
    {
        // set from editor
        IDLE,
        WALK,
        CLIMB_BACK,
        CLIMB_SIDE,
        PULL,
        PUSH,
        RIDE,
        SIT,
        RUN,
        FLOAT,
        DOWN,
        TICKLE,
        SWITCH,
        BOUNCE,
        LAND,

        // set from code
        DROP,
        INFLATE_HANDLE,
        INFLATE_ING,
        INFLATE_COMPLETE,
        INFLATE_FLOAT,
        CELEBRATE,
        CONFUSED,
        EMPTY
    };

    private Dictionary<CrowdState, string> simpleStateDict;

    //// the events when the man is selected/deselected. (removed already)
    //public UnityEvent onSelected;
    //public UnityEvent onDeselected;

    // the moving speed
    public float speed = 5f;

    // the walking progress when dragging (for syncing animation)
    [SerializeField]
    private float animationProgress = 0f;

    // behavior tree to control the animations and states
    // this part is not easy to understand by a couple of lines of comments, let me know if you are interested in it.
    private Tree<CrowdControl> btree;
    [SerializeField]
    private CrowdState state = CrowdState.EMPTY;
    private CrowdState lastState = CrowdState.EMPTY;
    private float stateCoolingDown = 0;

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
    protected override void Start()
    {
        base.Start();
        
        SwitchState(CrowdState.IDLE);

        simpleStateDict = new Dictionary<CrowdState, string>();
        simpleStateDict.Add(CrowdState.CLIMB_BACK, "climb_back");
        simpleStateDict.Add(CrowdState.CLIMB_SIDE, "climb_side");
        simpleStateDict.Add(CrowdState.RIDE, "ride_bike");
        simpleStateDict.Add(CrowdState.SIT, "sit");
        simpleStateDict.Add(CrowdState.RUN, "wheel_run");
        simpleStateDict.Add(CrowdState.FLOAT, "floating");
        simpleStateDict.Add(CrowdState.DOWN, "chain_drop");
        simpleStateDict.Add(CrowdState.SWITCH, "switchLever");
        simpleStateDict.Add(CrowdState.DROP, "drop");
        simpleStateDict.Add(CrowdState.BOUNCE, "bounce");

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

    protected override void RegisterEvents()
    {
        Services.eventManager.Register<DragEvent>(OnDragging);
    }

    protected override void UnregisterEvents()
    {
        Services.eventManager.Unregister<DragEvent>(OnDragging);
    }

    private void OnDragging(Crowd.Event e)
    {
        DragEvent de = (DragEvent)e;
        animationProgress = de.progress * 3;
    }

    private void InitBehaviorTree()
    {
        btree = new Tree<CrowdControl>(
            new Selector<CrowdControl>(

                new Sequence<CrowdControl>(
                    new IsMoving(),
                    new Walking()
                    ),

                new Sequence<CrowdControl>(
                    new IsPulling(),
                    new Pulling()
                    ),

                new Sequence<CrowdControl>(
                    new IsPushing(),
                    new Pushing()
                    ),

                new Sequence<CrowdControl>(
                    new IsDown(),
                    new Down()
                    ),

                new Sequence<CrowdControl>(
                    new IsTickling(),
                    new Tickling()
                    ),

                new Sequence<CrowdControl>(
                    new IsInflating(),
                    new Inflating()
                    ),

                new Sequence<CrowdControl>(
                    new IsLanding(),
                    new Landing()
                    ),

                new Sequence<CrowdControl>(
                    new IsCelebrating(),
                    new Celebrating()
                    ),

                new Sequence<CrowdControl>(
                    new IsConfused(),
                    new Confused()
                    ),

                new Sequence<CrowdControl>(
                    new IsSimpleAction(),
                    new SimpleAction()
                    ),

                new Sequence<CrowdControl>(
                    new IsIdling(),
                    new Idling()
                    ),  

                new Sequence<CrowdControl>(
                    new Empty()
                    )





                //new Sequence<CrowdControl>(
                //    new IsClimbing(),
                //    new Climbing()
                //    ),

                //new Sequence<CrowdControl>(
                //    new IsRiding(),
                //    new Riding()
                //    ),

                //new Sequence<CrowdControl>(
                //    new IsSitting(),
                //    new Sitting()
                //    ),

                //new Sequence<CrowdControl>(
                //    new IsRunning(),
                //    new Running()
                //    ),

                //new Sequence<CrowdControl>(
                //    new IsFloating(),
                //    new Floating()
                //    ),

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
        //onSelected.Invoke();
    }

    public void Deselected()
    {
        //onDeselected.Invoke();
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

    // busy
    public void OrderBusy()
    {
        if (voiceTimer[2] <= 0)
        {
            int id = Random.Range(0, 3) + 1;
            Services.soundController.Play("noWay" + id);
            voiceTimer[2] = voiceCoolDown;
        }
    }

    public void SwitchState(CrowdState s)
    {
        if (state != s)
        {
            if (state != CrowdState.CONFUSED)
            {
                lastState = state;
            }
            state = s;
            stateCoolingDown = DataSet.magicNumber;
        }
    }

    public void Flip(float p)
    {
        transform.localScale = new Vector3(
            p,
            transform.localScale.y,
            transform.localScale.z
            );
    }

    public void SetAnimationProgress(float value)
    {
        animationProgress = value;
    }

    ////////////////////
    // Conditions
    ////////////////////
    private class IsIdling : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.IDLE;
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

    private class IsPulling : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.PULL;
        }
    }

    private class IsPushing : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.PUSH;
        }
    }

    private class IsDown : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.DOWN;
        }
    }

    private class IsTickling : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.TICKLE;
        }
    }

    private class IsInflating : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state >= CrowdState.INFLATE_HANDLE && man.state <= CrowdState.INFLATE_FLOAT;
        }
    }

    private class IsLanding : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.LAND;
        }
    }

    private class IsCelebrating : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.CELEBRATE;
        }
    }

    private class IsConfused : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.CONFUSED;
        }
    }

    private class IsSimpleAction : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            return man.state == CrowdState.CLIMB_BACK
                || man.state == CrowdState.CLIMB_SIDE
                || man.state == CrowdState.RIDE
                || man.state == CrowdState.SIT
                || man.state == CrowdState.RUN
                || man.state == CrowdState.FLOAT
                || man.state == CrowdState.DOWN
                || man.state == CrowdState.SWITCH
                || man.state == CrowdState.DROP
                || man.state == CrowdState.BOUNCE;
                ;
        }
    }

    //private class IsClimbing : Node<CrowdControl>
    //{
    //    public override bool Update(CrowdControl man)
    //    {
    //        return man.state == CrowdState.CLIMB_BACK || man.state == CrowdState.CLIMB_SIDE;
    //    }
    //}

    //private class IsRiding : Node<CrowdControl>
    //{
    //    public override bool Update(CrowdControl man)
    //    {
    //        return man.state == CrowdState.RIDE;
    //    }
    //}

    //private class IsSitting : Node<CrowdControl>
    //{
    //    public override bool Update(CrowdControl man)
    //    {
    //        return man.state == CrowdState.SIT;
    //    }
    //}

    //private class IsRunning : Node<CrowdControl>
    //{
    //    public override bool Update(CrowdControl man)
    //    {
    //        return man.state == CrowdState.RUN;
    //    }
    //}

    //private class IsFloating : Node<CrowdControl>
    //{
    //    public override bool Update(CrowdControl man)
    //    {
    //        return man.state == CrowdState.FLOAT;
    //    }
    //}

    ///////////////////
    /// Actions
    ///////////////////
    private abstract class CrowdAction : Node<CrowdControl>
    {
        public override bool Update(CrowdControl man)
        {
            if (man.stateCoolingDown == DataSet.magicNumber)
            {
                OnStart(man);
            }
            else
            {
                OnUpdate(man);
            }

            return true;
        }

        public virtual void OnStart(CrowdControl man)
        {
            // to make it not on start anymore
            --man.stateCoolingDown;
        }

        public virtual void OnUpdate(CrowdControl man)
        {
        }
    }

    private abstract class TimedAction : CrowdAction
    {
        protected float interval;

        public override void OnUpdate(CrowdControl man)
        {
            if (man.stateCoolingDown > 0)
            {
                man.stateCoolingDown -= Time.deltaTime;
            }
            else
            {
                OnInterval(man);
            }
        }

        public virtual void OnInterval(CrowdControl man)
        {
            man.stateCoolingDown = interval;
        }
    }

    private class SimpleAction : CrowdAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            if (man.simpleStateDict.ContainsKey(man.state))
            {
                man.spineAnimController.SetAnimation(man.simpleStateDict[man.state], SpineAnimationControl.CLEAR_NOT_FACIAL);
            }
        }
    }

    private class Idling : TimedAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            interval = Random.Range(3f, 8f);
            man.stateCoolingDown = interval;

            man.spineAnimController.SetAnimation("idle_wiggle", SpineAnimationControl.CLEAR_NOT_FACIAL);
        }

        public override void OnInterval(CrowdControl man)
        {
            base.OnInterval(man);

            man.spineAnimController.SetRandomAnimation("idle", SpineAnimationControl.CLEAR_NOT_FACIAL);
        }
    }

    private class Walking : CrowdAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            man.spineAnimController.SetAnimation("walk_normal", SpineAnimationControl.CLEAR_NOT_FACIAL);
            man.spineAnimController.SetRandomAnimation("arm");
        }
    }

    private class Pulling : CrowdAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            man.spineAnimController.SetAnimation("feet_pull", SpineAnimationControl.CLEAR_NOT_FACIAL);
            man.spineAnimController.SetAnimation("pull");
        }

        public override void OnUpdate(CrowdControl man)
        {
            man.spineAnimController.SetProgress("feet_pull", man.animationProgress);
        }
    }

    private class Pushing : CrowdAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            man.spineAnimController.SetAnimation("feet_push", SpineAnimationControl.CLEAR_NOT_FACIAL);
            man.spineAnimController.SetAnimation("push");
        }

        public override void OnUpdate(CrowdControl man)
        {
            man.spineAnimController.SetProgress("feet_push", man.animationProgress);
        }
    }

    private class Inflating : CrowdAction
    {
        public override void OnStart(CrowdControl man)
        {
            switch (man.state)
            {
                case CrowdState.INFLATE_HANDLE:
                    man.spineAnimController.SetAnimation("inflate_pump", SpineAnimationControl.CLEAR_NOT_FACIAL);
                    break;
                case CrowdState.INFLATE_ING:
                    man.spineAnimController.SetAnimation("inflate_mouth_prepare", SpineAnimationControl.CLEAR_NOT_FACIAL);
                    break;
                case CrowdState.INFLATE_COMPLETE:
                    man.spineAnimController.SetAnimation("inflate_mouth_finish", SpineAnimationControl.CLEAR_NOT_FACIAL);
                    break;
                case CrowdState.INFLATE_FLOAT:
                    man.spineAnimController.SetAnimation("inflate_mouth_drift", SpineAnimationControl.CLEAR_NOT_FACIAL);
                    break;
                default:
                    break;
            }        
        }
    }

    private class Landing : TimedAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            interval = 1f;
            man.stateCoolingDown = interval;

            man.spineAnimController.SetAnimation("land", SpineAnimationControl.CLEAR_NOT_FACIAL);
        }

        public override void OnInterval(CrowdControl man)
        {
            base.OnInterval(man);

            man.SwitchState(CrowdState.IDLE);
        }
    }

    private class Tickling : CrowdAction
    {
        public override void OnStart(CrowdControl man)
        {
            man.spineAnimController.SetAnimation("tickle", SpineAnimationControl.CLEAR_NOT_FACIAL);
            man.spineAnimController.SetAnimation("mouth_openonce", SpineAnimationControl.CLEAR_FACIAL);
        }
    }

    private class Celebrating : CrowdAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            if (!man.IsBusy())
            {
                man.spineAnimController.SetAnimation("cheers_face", SpineAnimationControl.CLEAR_ALL);
                man.spineAnimController.SetRandomAnimation("cheers", SpineAnimationControl.CLEAR_NOT_FACIAL, "cheers_face");
            }
            else
            {
                man.spineAnimController.SetAnimation("cheers_face", SpineAnimationControl.CLEAR_FACIAL);
            }
        }
    }

    private class Confused : TimedAction
    {
        public override void OnStart(CrowdControl man)
        {
            base.OnStart(man);

            interval = 2f;
            man.stateCoolingDown = interval;

            if (man.gameObject.transform.localScale.x == -1)
            {
                man.spineAnimController.SetRandomAnimation("confuse_right", SpineAnimationControl.CLEAR_NOT_FACIAL);
            }
            else
            {
                man.spineAnimController.SetRandomAnimation("confuse_left", SpineAnimationControl.CLEAR_NOT_FACIAL);
            }
        }

        public override void OnInterval(CrowdControl man)
        {
            base.OnInterval(man);

            man.SwitchState(man.lastState);
        }
    }

    private class Down : CrowdAction
    {
        public override void OnStart(CrowdControl man)
        {
            man.spineAnimController.SetAnimation("chain_drop", SpineAnimationControl.CLEAR_NOT_FACIAL);
        }
    }

    private class Empty : CrowdAction
    {
        public override void OnUpdate(CrowdControl man)
        {
        }
    }

    //private class Working : CrowdAction
    //{
    //    public override void OnStart(CrowdControl man)
    //    {
    //        man.spineAnimController.SetAnimation("busy_forever", SpineAnimationControl.CLEAR_FACIAL);
    //    }
    //}

    //private class Climbing : CrowdAction
    //{
    //    public override void OnStart(CrowdControl man)
    //    {
    //        base.OnStart(man);

    //        if (man.state == CrowdState.CLIMB_BACK)
    //        {
    //            man.spineAnimController.SetAnimation("climb_back", SpineAnimationControl.CLEAR_NOT_FACIAL);
    //        }
    //        else
    //        {
    //            man.spineAnimController.SetAnimation("climb_side", SpineAnimationControl.CLEAR_NOT_FACIAL);
    //        }
    //    }
    //}

    //private class Riding : CrowdAction
    //{
    //    public override void OnStart(CrowdControl man)
    //    {
    //        man.spineAnimController.SetAnimation("ride_bike", SpineAnimationControl.CLEAR_NOT_FACIAL);
    //    }
    //}

    //private class Sitting : CrowdAction
    //{
    //    public override void OnStart(CrowdControl man)
    //    {
    //        man.spineAnimController.SetAnimation("sit", SpineAnimationControl.CLEAR_NOT_FACIAL);
    //    }
    //}

    //private class Running : CrowdAction
    //{
    //    public override void OnStart(CrowdControl man)
    //    {
    //        man.spineAnimController.SetAnimation("wheel_run", SpineAnimationControl.CLEAR_NOT_FACIAL);
    //    }
    //}

    //private class Floating : CrowdAction
    //{
    //    public override void OnStart(CrowdControl man)
    //    {
    //        man.spineAnimController.SetAnimation("floating", SpineAnimationControl.CLEAR_NOT_FACIAL);
    //    }
    //}
}
