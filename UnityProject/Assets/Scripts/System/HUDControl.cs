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

    [SerializeField]
    private List<GameObject> anchors = new List<GameObject>();
    [SerializeField]
    private GameObject anchorsObj;    
    [HideInInspector]
    [SerializeField]
    private int anchorCounter = 0;

    private char[] splitters = { ' ', ',' };

    void Start()
    {
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
                icon = Instantiate(Resources.Load("Prefabs/" + name), canvas.transform) as GameObject;
                icon.transform.position = pos;
                break;
        }

        return icon;
    }

    public void ShowIconInCameraSpace(string para)
    {
        string[] paras = para.Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject anchor = GameObject.Find(paras[1]);

        GameObject icon = ShowIcon(paras[0], anchor.transform.position, UISpace.CAMERA);
        icon.name = paras[2];
    }

    public void ShowIconInWorldpace(string para)
    {
        string[] paras = para.Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);
        float x, y, z;
        float.TryParse(paras[1], out x);
        float.TryParse(paras[2], out y);
        float.TryParse(paras[3], out z);
        Vector3 pos = new Vector3(x, y, z);

        GameObject icon = ShowIcon(paras[0], pos, UISpace.WORLD);
        icon.name = paras[4];
    }

    public void ShowIconInCanvaspace(string para)
    {
        string[] paras = para.Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);
        float x, y, z;
        float.TryParse(paras[1], out x);
        float.TryParse(paras[2], out y);
        float.TryParse(paras[3], out z);
        Vector3 pos = new Vector3(x, y, z);

        GameObject icon = ShowIcon(paras[0], pos, UISpace.CANVAS);
        icon.name = paras[4];
    }

    public void CloseIcon(string name)
    {
        GameObject icon = GameObject.Find(name);
        Destroy(icon);
    }
}
