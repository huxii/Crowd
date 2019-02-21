using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBehavior : MonoBehaviour
{
    public bool isHorizontalPan;
    public bool isVerticalPan;
    public float panSpeed = 5f;
    public Vector2 panOffset;

    private Vector2 origPan;
    private Vector2 deltaPan;
    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        origPan = rect.anchoredPosition;

        Services.eventManager.Register<RotateEvent>(OnRotate);
        Services.eventManager.Register<ZoomEvent>(OnZoom);
    }

    private void OnApplicationQuit()
    {
        Services.eventManager.Unregister<RotateEvent>(OnRotate);
        Services.eventManager.Unregister<ZoomEvent>(OnZoom);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 curPan = rect.anchoredPosition;
        Vector2 targetPan = origPan + Vector2.Scale(deltaPan, panOffset);
        if (Vector2.Distance(targetPan, curPan) > 0.01f)
        {
            Vector2 newPos = Vector2.Lerp(curPan, targetPan, panSpeed * Time.deltaTime);
            rect.anchoredPosition = newPos;
        }
    }

    private void OnRotate(Crowd.Event e)
    {
        RotateEvent re = (RotateEvent)e;
        deltaPan += Vector2.Scale(re.delta * 0.01f, new Vector2(isHorizontalPan ? 1.0f : 0.0f, isVerticalPan ? 1.0f : 0.0f));
        deltaPan = new Vector2(
            Mathf.Clamp(deltaPan.x, -1, 1),
            Mathf.Clamp(deltaPan.y, -1, 1)
            );
    }

    private void OnZoom(Crowd.Event e)
    {
        ZoomEvent ze = (ZoomEvent)e;
        deltaPan += Vector2.Scale(ze.delta, new Vector2(isHorizontalPan ? 1.0f : 0.0f, isVerticalPan ? 1.0f : 0.0f));
        deltaPan = new Vector2(
            Mathf.Clamp(deltaPan.x, -1, 1),
            Mathf.Clamp(deltaPan.y, -1, 1)
            );
    }
}
