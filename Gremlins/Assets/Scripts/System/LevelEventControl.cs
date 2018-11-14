using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class LevelEventControl : MonoBehaviour
{
    public UnityEvent levelEvent;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void TriggerEvent()
    {
        levelEvent.Invoke();

        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
    }
}
