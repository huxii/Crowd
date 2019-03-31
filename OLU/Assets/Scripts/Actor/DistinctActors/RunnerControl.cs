using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControl : ObjectControl
{
    [Header("Runner Settings")]
    private RunnerFirstControl floor1;
    private RunnerSecondControl floor2;
    private RunnerThirdControl floor3;
    private ElevatorControl teleA0A1;
    private ElevatorControl teleA0B1;
    private ElevatorControl teleA1A0;
    private ElevatorControl teleB0B1;
    private ElevatorControl teleB1B0A0;
    private ElevatorControl teleB1B2;
    private ElevatorControl teleB2B1;
    private GameObject teleB1_long;
    private GameObject teleB1_short;
    private GameObject teleA1_short;

    private int cycle;
    private int curAbsCycle = 0;

    protected void Awake()
    {
        floor1 = GameObject.Find("Floor1").GetComponent<RunnerFirstControl>();
        floor2 = GameObject.Find("Floor2").GetComponent<RunnerSecondControl>();
        floor3 = GameObject.Find("Floor3").GetComponent<RunnerThirdControl>();
        teleA0A1 = GameObject.Find("TeleA0A1").GetComponent<ElevatorControl>();
        teleA0B1 = GameObject.Find("TeleA0B1").GetComponent<ElevatorControl>();
        teleA1A0 = GameObject.Find("TeleA1A0").GetComponent<ElevatorControl>();
        teleB0B1 = GameObject.Find("TeleB0B1").GetComponent<ElevatorControl>();
        teleB1B0A0 = GameObject.Find("TeleB1B0A0").GetComponent<ElevatorControl>();
        teleB1B2 = GameObject.Find("TeleB1B2").GetComponent<ElevatorControl>();
        teleB2B1 = GameObject.Find("TeleB2B1").GetComponent<ElevatorControl>();
        teleB1_long = GameObject.Find("TeleLong");
        teleB1_short = GameObject.Find("TeleShort");
        teleA1_short = GameObject.Find("TeleMedium");        
    }

    protected override void Start()
    {
        base.Start();

        cycle = Services.utils.LCM(Services.utils.LCM(floor1.cycle, floor2.cycle), floor3.cycle);
        CheckCycle();
    }

    protected void ResetCycle()
    {
        teleA0A1.SetParentPermission(false);
        teleA0B1.SetParentPermission(false);
        teleA1A0.SetParentPermission(false);
        teleB0B1.SetParentPermission(false);
        teleB1B0A0.SetParentPermission(false);
        teleB1B2.SetParentPermission(false);
        teleB2B1.SetParentPermission(false);

        teleA0A1.gameObject.SetActive(true);
        teleA0B1.gameObject.SetActive(true);
        teleA1A0.gameObject.SetActive(true);
        teleB0B1.gameObject.SetActive(true);
        teleB1B0A0.gameObject.SetActive(true);
        teleB1B2.gameObject.SetActive(true);
        teleB2B1.gameObject.SetActive(true);

        teleB1_long.SetActive(false);
        teleB1_short.SetActive(false);
        teleA1_short.SetActive(false);
    }

    protected void ClearCycle()
    {
        teleA0A1.FreeAllMen();
        teleA0B1.FreeAllMen();
        teleA1A0.FreeAllMen();
        teleB0B1.FreeAllMen();
        teleB1B0A0.FreeAllMen();
        teleB1B2.FreeAllMen();
        teleB2B1.FreeAllMen();
    }

    protected void LockCycle()
    {
        teleA0A1.Lock ();
        teleA0B1.Lock();
        teleA1A0.Lock();
        teleB0B1.Lock();
        teleB1B0A0.Lock();
        teleB1B2.Lock();
        teleB2B1.Lock();
    }

    protected void UnlockCycle()
    {
        teleA0A1.Unlock();
        teleA0B1.Unlock();
        teleA1A0.Unlock();
        teleB0B1.Unlock();
        teleB1B0A0.Unlock();
        teleB1B2.Unlock();
        teleB2B1.Unlock();
    }

    public void CheckCycle()
    {
        ResetCycle();

        switch (curAbsCycle)
        {
            case 0:
                if (floor1.IsShort())
                {
                    teleA0A1.SetParentPermission(true);
                    teleA1A0.SetParentPermission(true);
                    teleA1_short.SetActive(true);
                }
                teleA0B1.gameObject.SetActive(false);
                teleB0B1.SetParentPermission(true);
                teleB1B0A0.SetParentPermission(true);
                teleB1B2.gameObject.SetActive(false);
                teleB1_long.SetActive(true);
                break;

            case 3:
                teleB1B0A0.gameObject.SetActive(false);
                teleB1B2.SetParentPermission(true);
                teleB2B1.SetParentPermission(true);
                teleB1_short.SetActive(true);
                break;

            case 4:
                if (floor1.IsShort())
                {
                    teleA0A1.SetParentPermission(true);
                    teleA1A0.SetParentPermission(true);
                    teleA1_short.SetActive(true);
                }
                teleA0B1.gameObject.SetActive(false);
                break;

            case 5:
                teleA0A1.gameObject.SetActive(false);
                teleA0B1.SetParentPermission(true);
                teleB1B0A0.SetParentPermission(true);
                teleB1B2.gameObject.SetActive(false);
                teleB1_long.SetActive(true);
                break;

            case 8:
                if (floor1.IsShort())
                {
                    teleA0A1.SetParentPermission(true);
                    teleA1A0.SetParentPermission(true);
                    teleA1_short.SetActive(true);
                }
                teleA0B1.gameObject.SetActive(false);
                break;

            case 1:
            case 2:
            case 6:
            case 7:
            case 9:
            case 10:
            case 11:
            default:
                break;
        }
    }

    public void GoClockwise()
    {
        ++curAbsCycle;
        if (curAbsCycle >= cycle)
        {
            curAbsCycle = 0;
        }

        Services.taskManager
            .Do(new ActionTask(ClearCycle))
            .Then(new Wait(0.1f))
            .Then(new ActionTask(LockCycle))
            .Then(new ActionTask(floor1.GoClockwise))
            .Then(new ActionTask(floor2.GoCounterClockwise))
            .Then(new ActionTask(floor3.GoClockwise))
            .Then(new ActionTask(CheckCycle))
            .Then(new ActionTask(UnlockCycle));
    }

    public void GoCounterClockwise()
    {
        --curAbsCycle;
        if (curAbsCycle < 0)
        {
            curAbsCycle = cycle - 1;
        }

        Services.taskManager
            .Do(new ActionTask(ClearCycle))
            .Then(new Wait(0.1f))
            .Then(new ActionTask(LockCycle))
            .Then(new ActionTask(floor1.GoCounterClockwise))
            .Then(new ActionTask(floor2.GoClockwise))
            .Then(new ActionTask(floor3.GoCounterClockwise))
            .Then(new ActionTask(CheckCycle))
            .Then(new ActionTask(UnlockCycle));
    }
}
