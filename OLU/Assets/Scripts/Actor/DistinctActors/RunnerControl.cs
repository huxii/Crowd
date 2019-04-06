using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControl : ObjectControl
{
    [Header("Runner Settings")]
    public int maxCycle = 6;

    private int cycle;
    private int curAbsCycle = 0;

    private RunnerFirstControl floor1;
    private RunnerSecondControl floor2;
    private RunnerThirdControl floor3;
    private ElevatorControl teleA0A1;
    private ElevatorControl teleA2A1;
    private ElevatorControl teleA0B1;
    private ElevatorControl teleB1A0;
    private ElevatorControl teleB2B1;
    private ElevatorControl teleB1B2;
    private ElevatorControl teleA1A0;
    private ElevatorControl teleA1A2;

    private GameObject telePathA0A1;
    private GameObject telePathA2A1;
    private GameObject telePathB1A0;
    private GameObject telePathB1B2;

    private GameObject runes;

    protected void Awake()
    {
        floor1 = GameObject.Find("Floor1").GetComponent<RunnerFirstControl>();
        floor2 = GameObject.Find("Floor2").GetComponent<RunnerSecondControl>();
        floor3 = GameObject.Find("Floor3").GetComponent<RunnerThirdControl>();
        teleA0A1 = GameObject.Find("TeleA0A1").GetComponent<ElevatorControl>();
        teleA2A1 = GameObject.Find("TeleA2A1").GetComponent<ElevatorControl>();
        teleA0B1 = GameObject.Find("TeleA0B1").GetComponent<ElevatorControl>();
        teleB1A0 = GameObject.Find("TeleB1A0").GetComponent<ElevatorControl>();
        teleB2B1 = GameObject.Find("TeleB2B1").GetComponent<ElevatorControl>();
        teleB1B2 = GameObject.Find("TeleB1B2").GetComponent<ElevatorControl>();
        teleA1A0 = GameObject.Find("TeleA1A0").GetComponent<ElevatorControl>();
        teleA1A2 = GameObject.Find("TeleA1A2").GetComponent<ElevatorControl>();

        telePathA0A1 = GameObject.Find("TelePathA0A1");
        telePathA2A1 = GameObject.Find("TelePathA2A1");
        telePathB1A0 = GameObject.Find("TelePathB1A0");
        telePathB1B2 = GameObject.Find("TelePathB1B2");

        runes = GameObject.Find("Runes");
    }

    protected override void Start()
    {
        base.Start();

        cycle = Services.utils.LCM(Services.utils.LCM(floor1.cycle, floor2.cycle), floor3.cycle);

        if (maxCycle > cycle)
        {
            maxCycle = cycle;
        }

        CheckCycle();
    }

    protected void ResetCycle()
    {
        teleA0A1.SetParentPermission(false);
        teleA2A1.SetParentPermission(false);
        teleA0B1.SetParentPermission(false);
        teleB1A0.SetParentPermission(false);
        teleB2B1.SetParentPermission(false);
        teleB1B2.SetParentPermission(false);
        teleA1A0.SetParentPermission(false);
        teleA1A2.SetParentPermission(false);

        teleA0A1.gameObject.SetActive(true);
        teleA2A1.gameObject.SetActive(true);
        teleA0B1.gameObject.SetActive(true);
        teleB1A0.gameObject.SetActive(true);
        teleB2B1.gameObject.SetActive(true);
        teleB1B2.gameObject.SetActive(true);
        teleA1A0.gameObject.SetActive(true);
        teleA1A2.gameObject.SetActive(true);

        telePathA0A1.SetActive(false);
        telePathA2A1.SetActive(false);
        telePathB1A0.SetActive(false);
        telePathB1B2.SetActive(false);

        foreach (Transform r in runes.transform)
        {
            r.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
        }
    }

    protected void ClearCycle()
    {
        teleA0A1.FreeAllMen();
        teleA2A1.FreeAllMen();
        teleA0B1.FreeAllMen();
        teleB1A0.FreeAllMen();
        teleB2B1.FreeAllMen();
        teleB1B2.FreeAllMen();
        teleA1A0.FreeAllMen();
        teleA1A2.FreeAllMen();
    }

    protected void LockCycle()
    {
        teleA0A1.Lock();
        teleA2A1.Lock();
        teleA0B1.Lock();
        teleB1A0.Lock();
        teleB2B1.Lock();
        teleB1B2.Lock();
        teleA1A0.Lock();
        teleA1A2.Lock();
    }

    protected void UnlockCycle()
    {
        teleA0A1.Unlock();
        teleA2A1.Unlock();
        teleA0B1.Unlock();
        teleB1A0.Unlock();
        teleB2B1.Unlock();
        teleB1B2.Unlock();
        teleA1A0.Unlock();
        teleA1A2.Unlock();
    }

    public void CheckCycle()
    {
        ResetCycle();

        switch (curAbsCycle)
        {
            case 0:
                if (floor1.IsActivated())
                {
                    teleA0A1.SetParentPermission(true);
                    teleA1A0.SetParentPermission(true);
                    telePathA0A1.SetActive(true);

                    teleA1A2.gameObject.SetActive(false);
                }
                else
                {
                    teleA2A1.SetParentPermission(true);
                    teleA1A2.SetParentPermission(true);
                    telePathA2A1.SetActive(true);

                    teleA1A0.gameObject.SetActive(false);
                }
                break;

            case 3:
                teleB1B2.SetParentPermission(true);
                teleB2B1.SetParentPermission(true);
                telePathB1B2.SetActive(true);
                break;

            case 4:
                if (floor1.IsActivated())
                {
                    teleA0A1.SetParentPermission(true);
                    teleA1A0.SetParentPermission(true);
                    telePathA0A1.SetActive(true);

                    teleA1A2.gameObject.SetActive(false);
                }
                else
                {
                    teleA2A1.SetParentPermission(true);
                    teleA1A2.SetParentPermission(true);
                    telePathA2A1.SetActive(true);

                    teleA1A0.gameObject.SetActive(false);
                }
                break;

            case 5:
                teleA0B1.SetParentPermission(true);
                telePathB1A0.SetActive(true);
                break;

            case 1:
            case 2:
            default:
                break;
        }

        runes.transform.GetChild(curAbsCycle).GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
    }

    public void GoClockwise()
    {
        if (curAbsCycle >= maxCycle - 1)
        {
            return;
        }

        ++curAbsCycle;

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
        if (curAbsCycle <= 0)
        {
            return;
        }

        --curAbsCycle;

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
