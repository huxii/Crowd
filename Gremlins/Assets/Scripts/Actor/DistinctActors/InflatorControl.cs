using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflatorControl : PropAutoLoopControl
{
    [Header("Inflator Settings")]
    public int inflatorCount;
    private int count;
    private ParticleSystem windPs;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        
        ResetCount();

        windPs = transform.Find("ShortWind").GetComponent<ParticleSystem>();
    }

    private void ResetCount()
    {
        count = 0;
    }

    protected override void OnSlotChange()
    {
        base.OnSlotChange();

        GameObject man0 = GetSlotMan(0);
        GameObject man1 = GetSlotMan(1);

        if (man0 == null && man1 != null)
        {
            Services.gameEvents.SwitchCrowdState(man1, CrowdControl.CrowdState.INFLATE_ING);
            GetComponent<Animation>().Stop();
            windPs.Pause();
        }
        else
        if (man0 != null && man1 == null)
        {
            Services.gameEvents.SwitchCrowdState(man0, CrowdControl.CrowdState.INFLATE_HANDLE);
            GetComponent<Animation>().Play();
            windPs.Play();
        }
        else
        if (man0 != null && man1 != null)
        {
            Services.gameEvents.SwitchCrowdState(man0, CrowdControl.CrowdState.INFLATE_HANDLE);
            Services.gameEvents.SwitchCrowdState(man1, CrowdControl.CrowdState.INFLATE_COMPLETE);
            GetComponent<Animation>().Stop();
            windPs.Pause();
        }
        else
        {
            GetComponent<Animation>().Stop();
            windPs.Pause();
        }
    }

    public void Inflate()
    {
        ++count;
        if (count >= inflatorCount)
        {
            GameObject man = GetSlotMan(1);
            Services.gameEvents.UnboundMan(man);
            //Services.gameEvents.SwitchCrowdState(man, CrowdControl.CrowdState.INFLATE_FLOAT);
            Services.gameEvents.MakeFloatMan(man);

            ResetCount();
        }
    }

    public void Deflate()
    {
        GameObject man = GetSlotMan(1);
        if (man != null)
        {
            Services.gameEvents.SwitchCrowdState(man, CrowdControl.CrowdState.IDLE);
            //Services.dotweenEvents.ScaleTo(man.gameObject.name + " 1, 1, 1, 0.9");
        }

        ResetCount();
    }


    public override void Deactivate()
    {
        if (count < inflatorCount)
        {
            Deflate();
        }

        base.Deactivate();
    }
}
