using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
    }

    public void Init(float h)
    {
        Vector3 pos = transform.position;
        Services.dotweenEvents.MoveTo(gameObject.name + " " + pos.x + " " + (pos.y + h) + " " + pos.z + " 1 false");
    }
}