using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class ActorFeedbackBehavior : MonoBehaviour
{    
    // the reaction when player interacts with it
    // eg. model bounces a little bit
    public UnityEvent onInteractionFeedback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnInteract()
    {
    }
}
