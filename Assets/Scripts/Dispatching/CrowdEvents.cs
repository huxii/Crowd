using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManObj : Crowd.Event
{
    public readonly GameObject man;
    public readonly GameObject obj;
    public readonly int slotId;
    public ManObj(GameObject m, GameObject o, int s)
    {
        man = m;
        obj = o;
        slotId = s;
    }
}

public class ManArrivesAtObj : ManObj
{
    public ManArrivesAtObj(GameObject m, GameObject o, int s)
        : base(m, o, s)
    {
    }
}

public class ManLeavesForObj : ManObj
{
    public ManLeavesForObj(GameObject m, GameObject o, int s)
        : base(m, o, s)
    {
    }
}

public class ManLeavesFromObj : ManObj
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

public class ManDrop : Crowd.Event
{
    public readonly GameObject man;
    public ManDrop(GameObject m)
    {
        man = m;
    }
}