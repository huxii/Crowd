using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManObjEvent : Crowd.Event
{
    public readonly GameObject man;
    public readonly GameObject obj;
    public readonly int slotId;
    public ManObjEvent(GameObject m, GameObject o, int s)
    {
        man = m;
        obj = o;
        slotId = s;
    }
}

public class ManArrives : ManObjEvent
{
    public ManArrives(GameObject m, GameObject o, int s)
        : base(m, o, s)
    {
    }
}

public class ManLeavesForObj : ManObjEvent
{
    public ManLeavesForObj(GameObject m, GameObject o, int s)
        : base(m, o, s)
    {
    }
}

public class ManLeavesFromObj : ManObjEvent
{
    public ManLeavesFromObj(GameObject m)
    : base(m, null, -1)
    {
    }

    public ManLeavesFromObj(GameObject m, GameObject o, int s)
        : base(m, o, s)
    {
    }
}

public class InputEvent : Crowd.Event
{
    public InputEvent()
    {
    }
}

public class ClickEvent : InputEvent
{
    public readonly GameObject mouseClickObj;
    public readonly Vector3 mouseClickPos;
    public ClickEvent(GameObject obj, Vector3 pos)
        : base()
    {
        mouseClickObj = obj;
        mouseClickPos = pos;
    }
}

public class RotateEvent : InputEvent
{
    public readonly Vector3 mouseDelta;
    public RotateEvent(Vector3 delta)
        : base()
    {
        mouseDelta = delta;
    }
}