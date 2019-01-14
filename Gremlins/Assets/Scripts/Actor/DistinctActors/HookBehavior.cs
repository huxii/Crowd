using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehavior : ObjectTimedDeactivateControl
{
    GameObject man = null;

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        TimeUpdate();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (man == null && other.CompareTag("Man") && other.GetComponent<FloatBehavior>())
        {
            Services.gameEvents.AddAnchor(other.gameObject, gameObject);
            man = other.gameObject;

            Deactivate();
        }
    }

    // Deactivate control panel through hook animations
    public void DeactivateControlPanel()
    {
        GameObject.Find("ControlPanel").GetComponent<PropControl>().FreeAllMen();
    }

    public override void Activate()
    {
        base.Activate();

        man = null;
        Services.gameEvents.PlayAnimation(gameObject.name + " HookExpand");
    }

    public override void Deactivate()
    {
        if (CanDeactivate())
        {
            isActivated = false;

            CoolDown();

            if (man != null)
            {
                Services.gameEvents.PlayAnimation(gameObject.name + " HookCatched");
            }
            else
            {
                Services.gameEvents.PlayAnimation(gameObject.name + " HookEmpty");
            }

            onDeactivated.Invoke();
        }
    }
}
