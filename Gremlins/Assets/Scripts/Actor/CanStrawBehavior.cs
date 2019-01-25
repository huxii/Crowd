using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanStrawBehavior : ObjectTimedDeactivateControl
{
    private GameObject man = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Man") && CanActivate())
        {
            man = other.gameObject;
            Services.gameEvents.AddAnchor(other.gameObject, transform.GetChild(0).gameObject);
            Services.dotweenEvents.ScaleTo(other.gameObject.name + " 1, 1, 1, 2.5");

            Activate();
        }
    }

    public override void Deactivate()
    {
        if (CanDeactivate())
        {
            Services.gameEvents.RemoveAnchor(man);
            Services.gameEvents.DisableMan(man);
            // dead :)
            Services.dotweenEvents.MoveTo(man.name + " 2.5, 1, -1.8, 1");
            man.transform.eulerAngles = new Vector3(0, 0, 90);

            man = null;

            isActivated = false;

            CoolDown();
            onDeactivated.Invoke();
        }
    }
}
