using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 *  The objects with no slots and not directly related to the puzzles
 */
[RequireComponent(typeof(ObjectFeedbackBehavior))]

public abstract class ObjectControl : InteractableControl
{
    public ObjectFeedbackBehavior ObjectFeedbackController
    {
        get { return (ObjectFeedbackBehavior)feedbackController; }
        set { feedbackController = value; }
    }

    // only override mouse drag when it requires the interaction of dragging
    // so that it won't mess up with viewport rotation
    // eg. gears require dragging, while penguin mouth does not.
    public virtual bool IsDragOverride()
    {
        return true;
    }

    public void Interact()
    {
        if (feedbackController != null)
        {
            feedbackController.OnInteract();
        }

        Click();
    }
}
