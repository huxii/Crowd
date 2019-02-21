using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *                                      ActorControl
 *                        /                                 \
 *          CrowdControl                                InteractableControl
 *                                                     /                                        \
 *                                       ObjectControl                                      PropControl
 *                                         /        \                            /                       \                      
 *                          MultiplePropControl          ...                PropAutoControl                 PropPassiveControl     
 *                                                                  /                   |              \
 *                                                             PropAutoLoopControl   PropOneTimeControl  PropZeroOneControl...
 *                                                          
*/

/*
 *  Base class for all the actors.
 *  
 *  Crowd: the men
 *  Prop: the objects with slots and are related to the puzzles
 *  Object: no slots, not related to (at least not directly) the puzzles
*/

public abstract class ActorControl : MonoBehaviour
{
    protected ActorFeedbackBehavior feedbackController = null;

    // 1. men can't move    2. props/objects can't activate
    [SerializeField]
    protected bool locked = false;

    // Use this for initialization
    protected virtual void Start()
    {
        RegisterEvents();
    }

    // excute before OnDestroy
    protected virtual void OnApplicationQuit()
    {
        UnregisterEvents();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    protected virtual void RegisterEvents()
    {
    }

    protected virtual void UnregisterEvents()
    {
    }

    public virtual void Lock()
    {
        locked = true;
    }

    public void Unlock()
    {
        locked = false;
    }

    public bool IsLocked()
    {
        return locked;
    }
}
