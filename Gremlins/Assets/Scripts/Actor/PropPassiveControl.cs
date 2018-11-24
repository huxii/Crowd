using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// activate by other props when slots are filled
public abstract class PropPassiveControl : PropControl
{
    public enum PassiveScheme
    {
        ACTIVATE,
        DEACTIVATE,
        BOTH
    };

    [Header("Passive Control")]
    public PassiveScheme passiveScheme = PassiveScheme.BOTH;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public override PropState Interact()
    {
        if (IsLocked())
        {
            if (isWalkableAfterDeactivated)
            {
                return PropState.WALKABLE;
            }
            else
            {
                return PropState.STAY;
            }
        }
        else
        {
            if (IsActivated())
            {
                if (passiveScheme != PassiveScheme.DEACTIVATE && passiveScheme != PassiveScheme.BOTH)
                {
                    onInteractionFeedback.Invoke();
                    return PropState.DEACTIVATED;
                }
            }
            else
            {
                if (passiveScheme != PassiveScheme.ACTIVATE && passiveScheme != PassiveScheme.BOTH)
                {
                    onInteractionFeedback.Invoke();
                    return PropState.ACTIVATED;
                }
            }
        }

        return PropState.STAY;
    }
}
