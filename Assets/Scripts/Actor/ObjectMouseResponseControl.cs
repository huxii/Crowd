using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectMouseResponseControl : ObjectControl
{
    [Header("Mouse Response")]
    public float range = 0f;
    public UnityEvent onClick;

    // Use this for initialization
    void Start()
    {
        Services.eventManager.Register<ClickEvent>(OnRespondClick);
    }

    // excute before OnDestroy
    private void OnApplicationQuit()
    {
        Services.eventManager.Unregister<ClickEvent>(OnRespondClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnRespondClick(Crowd.Event e)
    {
        if (IsCoolingDown())
        {
            return;
        }

        var clicke = e as ClickEvent;
        GameObject obj = clicke.mouseClickObj;
        Vector3 pos = clicke.mouseClickPos;
        if (Vector3.Distance(transform.position, pos) < range)
        {
            onClick.Invoke();
            CoolDown();
        }
    }
}
