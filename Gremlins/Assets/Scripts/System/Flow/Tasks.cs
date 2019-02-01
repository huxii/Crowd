using System;
using UnityEngine;


public class ActionTask : Task
{
    public Action Action { get; private set; }
    public ActionTask(Action action)
    {
        Action = action;
    }

    protected override void Init()
    {
        Action();
        SetStatus(TaskStatus.SUCCESS);
    }
}


public class FeedbackTask : Task
{
    public Crowd.Event Feedback { get; private set; }

    public FeedbackTask(Crowd.Event e)
    {
        Debug.Log("feed back ");
        Feedback = e;
    }

    protected override void Init()
    {
        Services.eventManager.QueueEvent(Feedback);
        SetStatus(TaskStatus.SUCCESS);
    }
}


public abstract class TimedTask : Task
{
    public float Duration { get; private set; }
    public float StartTime { get; private set; }

    protected TimedTask(float duration)
    {
        Duration = duration;
    }

    protected override void Init()
    {
        StartTime = Time.time;
    }

    internal override void Update()
    {
        var now = Time.time;
        var elapsed = now - StartTime;
        var t = Mathf.Clamp01(elapsed / Duration);
        if (t >= 1)
        {
            OnElapsed();
        }
        else
        {
            OnTick(t);
        }
    }

    protected virtual void OnTick(float t) { }

    protected virtual void OnElapsed()
    {        
        SetStatus(TaskStatus.SUCCESS);
    }
}


public class Wait : TimedTask
{
    public Wait(float duration) : base(duration) { }
}


public class TimedMaterialTask : TimedTask
{
    protected GameObject obj;
    protected string attrName;
    protected float start;
    protected float end;
    protected Material mat;

    public TimedMaterialTask(GameObject o, string attr, float s, float e, float d) : base(d)
    {
        obj = o;
        attrName = attr;
        start = s;
        end = e;
    }

    protected override void Init()
    {
        base.Init();

        mat = obj.GetComponent<MeshRenderer>().material;
        mat.SetFloat(attrName, start);
        obj.SetActive(true);
    }

    protected override void OnTick(float t)
    {
        // temp fix for transition texture
        mat.SetFloat(attrName, Mathf.Lerp(start, end, t * 1.1f));
    }

    //protected override void OnSuccess()
    //{
    //    obj.SetActive(false);
    //}
}


public class TimedMaterialWithCameraTask : TimedMaterialTask
{
    protected Camera cam;
    protected bool disableWhenDone;

    public TimedMaterialWithCameraTask(GameObject o, Camera c, string attr, float s, float e, float d, bool bd) : base(o, attr, s, e, d)
    {
        cam = c;
        disableWhenDone = bd;
    }

    protected override void Init()
    {
        base.Init();

        cam.enabled = true;
    }

    protected override void OnElapsed()
    {
        base.OnElapsed();

        if (disableWhenDone)
        {
            obj.SetActive(false);
            cam.enabled = false;
        }
    }
}
