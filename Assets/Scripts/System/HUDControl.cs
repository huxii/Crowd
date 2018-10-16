using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class HUDControl : MonoBehaviour
{
    public GameObject canvas;
    public List<UnityEvent> levelUIEvents;
    private int curId = 0;

    [SerializeField]
    private List<GameObject> anchors = new List<GameObject>();
    [SerializeField]
    private GameObject anchorsObj;    
    [HideInInspector]
    [SerializeField]
    private int anchorCounter = 0;

    void Start()
    {
        Services.hudController.PlayNextUIEvent();
        //Services.hudController.PlayNextUIEvent();
        //Services.hudController.PlayNextUIEvent();
    }

    private void Update()
    {
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
                //Gizmos.DrawGUITexture(new Rect(anchor.transform.position.x, anchor.transform.position.y, 1, 1), gizmoTexture);
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(anchor.transform.position, 0.2f);
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
                GameObject image = new GameObject(info[1], typeof(RectTransform));
                image.transform.position = anch.transform.position;
                image.transform.SetParent(canvas.transform);
                image.AddComponent<Image>();
                Sprite outsideImage = Resources.Load<Sprite>("Sprites/" + info[1]);
                image.GetComponent<Image>().sprite = outsideImage;
                image.transform.localScale = Vector3.zero;
                image.transform.DOScale(Vector3.one, float.Parse(info[2]));
                break;
            }
        }
    }

    public void CloseImage(string targetImage)
    {
        string[] info = targetImage.Split(',');
        GameObject image = GameObject.Find(info[0]);
        image.transform.DOScale(Vector3.zero, float.Parse(info[1])).OnComplete(() => { image.SetActive(false); });       
    }

    public void AddAnchor()
    {
        if (anchorsObj == null)
        {
            anchorsObj = new GameObject("Anchors", typeof(RectTransform));
            anchorsObj.transform.SetParent(canvas.transform);
            anchorsObj.transform.localPosition = Vector3.zero;
        }

        GameObject anchor = new GameObject("Anchor" + anchorCounter, typeof(RectTransform));
        anchor.transform.SetParent(anchorsObj.transform);
        anchor.transform.localPosition = Vector3.zero;
        ++anchorCounter;

        anchors.Add(anchor);
    }
}
