using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class HUDControl : MonoBehaviour
{
    public Texture gizmoTexture;
    public GameObject canvas;
    public List<UnityEvent> levelUIEvents;
    private int curId = 0;

    [SerializeField]
    private List<GameObject> anchors = new List<GameObject>();
    private GameObject anchorsObj;    
    [HideInInspector]
    [SerializeField]
    private int anchorCounter = 0;

    void Start()
    {
    }

    private void Update()
    {
        if (Time.time > 2f)
        {
            Services.hudController.PlayNextUIEvent();
        }
    }

    private void OnDrawGizmos()
    {
        foreach (GameObject anchor in anchors.ToArray())
        {
            if (anchor == null)
            {
                anchors.Remove(anchor);
            }
            else
            {
                Gizmos.DrawGUITexture(new Rect(anchor.GetComponent<RectTransform>().position.x, anchor.GetComponent<RectTransform>().position.y, 1, 1), gizmoTexture);
            }
        }
    }

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

    public void AddAnchor()
    {
        if (anchorsObj == null)
        {
            anchorsObj = new GameObject();
            anchorsObj.name = "Anchors";
            anchorsObj.transform.SetParent(canvas.transform);
        }

        GameObject anchor = new GameObject("Anchor" + anchorCounter, typeof(RectTransform));
        anchor.transform.SetParent(anchorsObj.transform);
        ++anchorCounter;

        anchors.Add(anchor);
    }
}
