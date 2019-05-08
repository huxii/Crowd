using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenBehavior : MonoBehaviour
{
    public Vector3 posOffset;
    public Vector3 rotOffset;

    private Vector3 origPos;
    private Vector3 origRot;

    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.localPosition;
        origRot = transform.localEulerAngles;

        Services.eventManager.Register<ObjectDragEvent>(OnDragged);
    }

    private void OnApplicationQuit()
    {
        Services.eventManager.Unregister<ObjectDragEvent>(OnDragged);
    }

    private void OnDragged(Crowd.Event e)
    {
        ObjectDragEvent ode = (ObjectDragEvent)e;
        transform.localPosition = Vector3.Lerp(origPos, origPos + posOffset, ode.progress);
        transform.localEulerAngles = Vector3.Lerp(origRot, origRot + rotOffset, ode.progress);
    }
}
