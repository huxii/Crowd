using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class LevelEventControl : MonoBehaviour
{
    public UnityEvent levelEvent;

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

    protected void OnTriggerEnter(Collider other)
    {
        Do();
    }

    protected void TriggerEvent()
    {
        if (!isFinished)
        {
            levelEvent.Invoke();

            Services.levelEventsManager.MoveToNext();
            if (autoNext)
            {
                Services.levelEventsManager.DoCurrentEvent();
            }

            Destroy(gameObject);

            isFinished = true;
        }
    }

    public virtual void Do()
    {
    }
}
