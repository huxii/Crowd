using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class LevelEventControl : MonoBehaviour
{
    public UnityEvent beginEvent;
    public UnityEvent endEvent;

    public bool autoNext = true;

    private bool isFinished = false;

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

    protected virtual void OnTriggerEnter(Collider other)
    {
    }

    public virtual void Do()
    {        
    }

    public void Done()
    {
        if (!isFinished)
        {
            endEvent.Invoke();

            Services.levelEventsManager.MoveToNext();
            if (autoNext)
            {
                Services.levelEventsManager.DoNextEvent();
            }

            Destroy(gameObject);

            isFinished = true;
        }
    }
}
