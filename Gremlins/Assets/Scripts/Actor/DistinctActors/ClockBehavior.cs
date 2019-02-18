using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBehavior : MonoBehaviour
{
    int tick = 0;

    // Update is called once per frame
    void Update()
    {

    }

    public void Tick()
    {
        ++tick;
        Services.mainController.GetComponent<DotweenEvents>().Rotate("SecondHand, z, 6, 0.1");

        int soundId = (int)Random.Range(0, 3);
        Services.soundController.Play("tick" + soundId.ToString());

        if (tick == 60)
        {
            tick = 0;
            Services.mainController.GetComponent<DotweenEvents>().Rotate("MinuteHand, z, 6, 0.1");
        }
    }

    public void TimeToGetUp()
    {
        Services.mainController.GetComponent<DotweenEvents>().RotateTo("SecondHand, z, 0, 1");
        Services.mainController.GetComponent<DotweenEvents>().RotateTo("MinuteHand, z, 30, 1");
        Services.mainController.GetComponent<DotweenEvents>().RotateTo("HourHand, z, 5, 1");
    }
}
