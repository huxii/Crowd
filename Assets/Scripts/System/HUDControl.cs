using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUDControl : MonoBehaviour
{
    public List<UnityEvent> levelUIEvents;

    private int curId = 0;

    public void PlayNextUIEvent()
    {
        if (curId < levelUIEvents.Count)
        {
            levelUIEvents[curId].Invoke();
            ++curId;
        }
    }
}
