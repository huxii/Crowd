using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectFeedbackBehavior : ActorFeedbackBehavior
{
    void Awake()
    {
        GetComponent<ObjectControl>().ObjectFeedbackController = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void OnInteract()
    {
        onInteractionFeedback.Invoke();
    }
}
