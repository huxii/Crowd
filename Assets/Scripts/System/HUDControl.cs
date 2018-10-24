using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class HUDControl : MonoBehaviour
{
    public enum UISpace
    {
        WORLD,
        CANVAS,
        CAMERA
    };

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

    private char[] splitters = { ' ', ',' };

    [SerializeField]
    private GameObject[] levelUIList = null;

    void Start()
    {
        levelUIList = new GameObject[levelUIEvents.Count];

        PlayNextUIEvent();
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
                Gizmos.DrawWireSphere(anchor.transform.position, 0.02f);
            }
        }
    }

    private Vector2 GetCanvasPos(Vector3 posWorld)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(gameObject.GetComponent<Canvas>().transform as RectTransform,
            Camera.main.WorldToScreenPoint(posWorld), gameObject.GetComponent<Canvas>().worldCamera, out pos);
        return pos;
    }

    public void PlayNextUIEvent()
    {
        if (curId < levelUIEvents.Count)
        {
            CloseLastIcon();
            levelUIEvents[curId].Invoke();          
            ++curId;
        }
    }

    public void PlayUIEvent(int id)
    {
        CloseLastIcon();
        curId = id;
        if (curId < levelUIEvents.Count)
        {
            levelUIEvents[curId].Invoke();
            ++curId;
        }
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

    public GameObject ShowIcon(string name, Vector3 pos, UISpace mode)
    {
        GameObject icon = null;
        switch (mode)
        {
            case UISpace.WORLD:
                icon = Instantiate(Resources.Load("Prefabs/" + name), pos, Quaternion.identity) as GameObject;
                break;
            case UISpace.CANVAS:
                Vector2 canvasPos = GetCanvasPos(pos);
                icon = Instantiate(Resources.Load("Prefabs/" + name), transform) as GameObject;
                RectTransform rect = icon.transform as RectTransform;
                rect.anchoredPosition = canvasPos;
                break;
            case UISpace.CAMERA:
                icon = new GameObject(name, typeof(RectTransform));
                icon.transform.position = pos;
                icon.transform.SetParent(canvas.transform);
                icon.AddComponent<Image>();
                Sprite outsideImage = Resources.Load<Sprite>("Sprites/" + name);
                icon.GetComponent<Image>().sprite = outsideImage;
                //image.transform.localScale = Vector3.zero;
                //image.transform.DOScale(Vector3.one, float.Parse(info[2]));
                //break;
                break;
        }

        return icon;
    }

    public void ShowIconInCameraSpace(string para)
    {
        string[] paras = para.Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject anchor = GameObject.Find(paras[1]);
        
        levelUIList[curId] = ShowIcon(paras[0], anchor.transform.position, UISpace.CAMERA);
    }

    public void ShowIconInWorldpace(string para)
    {
        string[] paras = para.Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);
        float x, y, z;
        float.TryParse(paras[1], out x);
        float.TryParse(paras[2], out y);
        float.TryParse(paras[3], out z);
        Vector3 pos = new Vector3(x, y, z);

        levelUIList[curId] = ShowIcon(paras[0], pos, UISpace.WORLD);
    }

    public void ShowIconInCanvaspace(string para)
    {
        string[] paras = para.Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);
        float x, y, z;
        float.TryParse(paras[1], out x);
        float.TryParse(paras[2], out y);
        float.TryParse(paras[3], out z);
        Vector3 pos = new Vector3(x, y, z);

        levelUIList[curId] = ShowIcon(paras[0], pos, UISpace.CANVAS);
    }

    public void CloseLastIcon()
    {
        if (curId > 0 && levelUIList[curId - 1] != null)
        {
            levelUIList[curId - 1].GetComponent<IconBehavior>().Close();
        }
    }

    //public void CloseImage(string targetImage)
    //{
    //    string[] info = targetImage.Split(',');
    //    GameObject image = GameObject.Find(info[0]);
    //    image.transform.DOScale(Vector3.zero, float.Parse(info[1])).OnComplete(() => { Destroy(image); });       
    //}
}
