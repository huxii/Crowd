using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *                                      ActorControl
 *                        /                                 \
 *          CrowdControl                                InteractableControl
 *                                                     /                                        \
 *                                       ObjectControl                                      PropControl
 *                                         /        \                            /                       \                          \
 *                          MultiplePropControl          ...                PropAutoControl                 PropPassiveControl      PropHolderControl
 *                                                                  /                   |              \
 *                                                             PropAutoLoopControl   PropOneTimeControl  ...
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
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
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
