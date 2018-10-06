using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class ObjectControl : ActorControl
{
    public UnityEvent onActivated;
    public UnityEvent onDeactivated;

    [Header("Walkable Attribute")]
    public bool isWalkable = false;
    [SerializeField]
    protected List<GameObject> menOnThis = null;

    protected bool isActivated = false;

    //public enum ObjectControlScheme
    //{
    //    DRAG_TRANSFORMATION,
    //    DRAG_ROTATION,
    //    CLICK,
    //    // HOLD,
    //    // SMASH,
    //    // SWIPE,
    //    // OTHEROBJECT
    //};

    //public ObjectControlScheme controlScheme = ObjectControlScheme.DRAG_TRANSFORMATION;
    //public bool deltaLimited = false;

    // Use this for initialization
    void Start ()
    {       
    }
	
	// Update is called once per frame
	void Update ()
    {		
	}

    public virtual void Click()
    {
    }

    public virtual void Drag(Vector3 deltaPos)
    {
    }

    public virtual void Swipe()
    {
    }

    public bool IsActivated()
    {
        return isActivated;
    }

    public virtual void Activate()
    {
        isActivated = true;
        onActivated.Invoke();
    }

    public virtual void Deactivate()
    {
        isActivated = false;
        onDeactivated.Invoke();
    }

    public void ManAcrossBorder(GameObject man)
    {
        if (menOnThis == null)
        {
            menOnThis = new List<GameObject>();
        }

        if (menOnThis.Contains(man))
        {
            // this man has across the border once, he is now walking out
            Unlock();
            menOnThis.Remove(man);
        }
        else
        {
            // in
            Lock();
            menOnThis.Add(man);
        }
    }
}
