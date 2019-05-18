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

public class TimedCanvasGroupTask : TimedTask
{
    protected CanvasGroup canvasGroup;
    protected float start;
    protected float end;

    public TimedCanvasGroupTask(CanvasGroup c, float s, float e, float d) : base(d)
    {
        canvasGroup = c;
        start = s;
        end = e;
    }

    protected override void OnTick(float t)
    {
        canvasGroup.alpha = Mathf.Lerp(start, end, t);
    }

    protected override void OnElapsed()
    {
        base.OnElapsed();
        canvasGroup.alpha = end;
    }
}

public class TimedMaterialTask : TimedTask
{
    protected GameObject obj;
    protected string attrName;
    protected float start;
    protected float end;
    protected Material mat;

    public TimedMaterialTask(Material m, string attr, float e, float d) : base(d)
    {
        mat = m;
        attrName = attr;
        start = mat.GetFloat(attr);
        end = e;

        obj = null;
    }

    public TimedMaterialTask(Material m, string attr, float s, float e, float d) : base(d)
    {
        mat = m;
        attrName = attr;
        start = s;
        end = e;

        obj = null;
    }

    public TimedMaterialTask(GameObject o, string attr, float e, float d) : base(d)
    {
        obj = o;
        attrName = attr;
        end = e;

        mat = obj.GetComponent<MeshRenderer>().material;
        start = mat.GetFloat(attr);
    }

    public TimedMaterialTask(GameObject o, string attr, float s, float e, float d) : base(d)
    {
        obj = o;
        attrName = attr;
        start = s;
        end = e;

        mat = obj.GetComponent<MeshRenderer>().material;
    }

    protected override void Init()
    {
        base.Init();
      
        mat.SetFloat(attrName, start);
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }

    protected override void OnTick(float t)
    {
        // temp fix for transition texture
        mat.SetFloat(attrName, Mathf.Lerp(start, end, t * 1.1f));
    }
}

public class TimedTransitionTask : TimedTask
{
    protected GameObject obj;
    protected Camera cam;
    protected float start;
    protected float end;
    protected bool disableWhenDone;

    public TimedTransitionTask(GameObject o, Camera c, float s, float e, float d, bool dd) : base(d)
    {
        obj = o;
        cam = c;
        start = s;
        end = e;
        disableWhenDone = dd;
    }

    protected override void Init()
    {
        base.Init();

        obj.SetActive(true);
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

public class TimedTransitionMaterialTask : TimedTransitionTask
{
    protected string attrName;
    protected Material mat;

    public TimedTransitionMaterialTask(GameObject o, Camera c, string attr, float s, float e, float d, bool dd) : base(o, c, s, e, d, dd)
    {
        attrName = attr;
    }

    protected override void Init()
    {
        base.Init();

        mat = obj.GetComponent<MeshRenderer>().material;

        if (start == DataSet.magicNumber)
        {
            start = mat.GetFloat(attrName);
        }
        else
        {
            mat.SetFloat(attrName, start);
        }
    }

    protected override void OnTick(float t)
    {
        // temp fix for transition texture
        mat.SetFloat(attrName, Mathf.Lerp(start, end, t * 1.05f) + 0.05f);
    }
}

public class TimedTransitionZoomTask : TimedTransitionTask
{
    protected float orthoSize;

    public TimedTransitionZoomTask(GameObject o, Camera c, float orth, float s, float e, float d, bool dd) : base(o, c, s, e, d, dd)
    {
        orthoSize = orth;
    }

    protected override void OnTick(float t)
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, orthoSize, Mathf.Lerp(start, end, t));
    }
}

public class FmodInstanceTask : TimedTask
{
    FMOD.Studio.EventInstance instance;
    protected string paraName;
    protected float start;
    protected float end;

    public FmodInstanceTask(FMOD.Studio.EventInstance i, string para, float s, float e, float d) : base(d)
    {
        instance = i;
        paraName = para;
        start = s;
        end = e;
    }

    protected override void OnTick(float t)
    {
        instance.setParameterValue(paraName, Mathf.Lerp(start, end, t));
    }
}