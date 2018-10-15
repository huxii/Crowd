using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class HUDControl : MonoBehaviour
{
    public List<UnityEvent> levelUIEvents;
    public List<GameObject> anchors;
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
        foreach (GameObject anch in anchors){
            if(anch.name == info[0])
            {
                Sprite outsideImage = Resources.Load<Sprite>("Sprites/" + info[1]);
                anch.GetComponent<Image>().sprite = outsideImage;
                anch.transform.localScale = Vector3.zero;
                anch.SetActive(true);
                anch.transform.DOScale(Vector3.one, float.Parse(info[2]));
                break;
            }
        }
    }

    public void CloseImage(string targetImage)
    {
        string[] info = targetImage.Split(',');
        foreach (GameObject anch in anchors)
        {
            if (anch.name == info[0])
            {
                anch.transform.DOScale(Vector3.zero, float.Parse(info[1])).OnComplete(() => { anch.SetActive(false); });
                break;
            }
        }
    }

    void Start()
    {
        Services.hudController.PlayNextUIEvent();
        Services.hudController.PlayNextUIEvent();

    }
    private void Update()
    {
        if (Time.time > 2f)
        {
            Services.hudController.PlayNextUIEvent();
        }
    }
}
