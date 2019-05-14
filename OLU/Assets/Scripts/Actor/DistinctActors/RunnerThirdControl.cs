using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerThirdControl : CycleControl
{
    [Header("Third Floor Settings")]
    public List<GameObject> centerTiles;
    public List<GameObject> outerTiles;

    private PropAutoTimedDeactivateControl chest;
    private MirrorControl mirror;
    [SerializeField]
    private List<GameObject> runes;

    protected void Awake()
    {
        chest = GameObject.Find("Chest").GetComponent<PropAutoTimedDeactivateControl>();
        mirror = GameObject.Find("Mirror1").GetComponent<MirrorControl>();

        runes = new List<GameObject>();
        GameObject runesObj = GameObject.Find("BalanceRunes");
        if (runesObj != null)
        {
            for (int i = 0; i < runesObj.transform.childCount; ++i)
            {
                runes.Add(runesObj.transform.GetChild(i).gameObject);
                runes[i].SetActive(false);
            }
        }
        runes[curAbsCycle].SetActive(true);
    }

    protected void ResetPaths()
    {
        Services.gameEvents.DisconnectPath(centerTiles[0].name + " " + outerTiles[curAbsCycle].name);
        Services.gameEvents.DisconnectPath(centerTiles[1].name + " " + outerTiles[(curAbsCycle + 1) % cycle].name);
    }

    protected void ReconnectPaths()
    {
        Services.gameEvents.ConnectPath(centerTiles[0].name + " " + outerTiles[curAbsCycle].name);
        Services.gameEvents.ConnectPath(centerTiles[1].name + " " + outerTiles[(curAbsCycle + 1) % cycle].name);
    }

    protected override void CheckCycle()
    {
        base.CheckCycle();

        if (chest.IsLocked() && curAbsCycle == 0)
        {
            mirror.SetZeroOne(true);
        }
        else
        {
            mirror.SetZeroOne(false);
        }
    }

    public override void GoClockwise()
    {
        runes[curAbsCycle].SetActive(false);
        ResetPaths();

        base.GoClockwise();

        runes[curAbsCycle].SetActive(true);
        ReconnectPaths();
    }

    public override void GoCounterClockwise()
    {
        runes[curAbsCycle].SetActive(false);
        ResetPaths();

        base.GoCounterClockwise();

        runes[curAbsCycle].SetActive(true);
        ReconnectPaths();       
    }
}
