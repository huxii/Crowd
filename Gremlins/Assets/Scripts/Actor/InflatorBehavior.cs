using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflatorBehavior : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Inflate()
    {
        PropControl prop = GetComponent<PropControl>();
        if (prop == null)
        {
            return;
        }

        GameObject man = prop.GetSlotMan(0);
        if (man != null)
        {
            Services.dotweenEvents.Scale(man.gameObject.name + " 1.1, 1.1, 1.1, 0.5");
        }
    }
}
