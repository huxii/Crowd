using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManArrivesAtObj : Crowd.Event
{
    public readonly GameObject man;
    public readonly GameObject obj;
    public ManArrivesAtObj(GameObject m, GameObject o)
    {
        man = m;
        obj = o;
    }
}
