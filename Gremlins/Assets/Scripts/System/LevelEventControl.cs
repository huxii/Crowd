using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class LevelEventControl : MonoBehaviour
{
    public UnityEvent beginEvent;
    public UnityEvent endEvent;

    public bool autoNext = true;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(0.3f, 0.3f, 0.3f));
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (autoNext)
        {
            Services.levelEventsManager.NextEvent();
        }

        Done();       
    }

    public void Do()
    {
        beginEvent.Invoke();
    }

    public void Done()
    {
        endEvent.Invoke();
        Destroy(gameObject);
    }
}
