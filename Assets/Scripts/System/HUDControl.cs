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

    public void DisplayImage(string anchorImage)
    {
        string[] info = anchorImage.Split(',');
        GameObject anchor = GameObject.Find(info[0]);
        Sprite outsideImage = Resources.Load<Sprite>("Sprites/" + info[1]);
        anchor.GetComponent<Image>().sprite = outsideImage;
    }

    private void Start()
    {
        Services.hudController.PlayNextUIEvent();
        Services.hudController.PlayNextUIEvent();
        Services.hudController.PlayNextUIEvent();
    }
}
