using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public float amplitude = 1f;

    private bool isOut = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Charge()
    {
        if (isOut)
        {
            isOut = false;
            Services.dotweenEvents.Move(gameObject.name + " x " + amplitude.ToString() + " 0.5");
        }
        else
        {
            isOut = true;
            Services.dotweenEvents.Move(gameObject.name + " x -" + amplitude.ToString() + " 0.5");
        }
    }
}
