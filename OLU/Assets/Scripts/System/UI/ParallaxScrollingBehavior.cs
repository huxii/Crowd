using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrollingBehavior : MonoBehaviour
{
    public bool isHorizontal;
    public bool isVertical;
    public Vector2 horizontalRange;
    public Vector2 verticalRange;
    public Vector2 horizontalOffset;
    public Vector2 verticalOffset;
    public float speed = 5f;

    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        //Services.eventManager.Register<RotateEvent>(OnRotate);
        //Services.eventManager.Register<ZoomEvent>(OnZoom);
        Services.eventManager.Register<ParallaxScrollingEvent>(OnUpdate);
    }

    private void OnApplicationQuit()
    {
        //Services.eventManager.Unregister<RotateEvent>(OnRotate);
        //Services.eventManager.Unregister<ZoomEvent>(OnZoom);
        Services.eventManager.Unregister<ParallaxScrollingEvent>(OnUpdate);
    }

    private void OnUpdate(Crowd.Event e)
    {
        ParallaxScrollingEvent pe = (ParallaxScrollingEvent)e;
        Vector2 value = pe.scrollValue;

        float newX = rect.anchoredPosition.x;
        if (isHorizontal && horizontalRange.x <= value.x && value.x <= horizontalRange.y)
        {
            //Debug.Log(gameObject.name + " " + (value.x - horizontalRange.x) / (horizontalRange.y - horizontalRange.x));
            newX = Mathf.Lerp(horizontalOffset.x, horizontalOffset.y, (value.x - horizontalRange.x) / (horizontalRange.y - horizontalRange.x));
        }

        float newY = rect.anchoredPosition.y;
        if (isVertical && verticalRange.x <= value.y && value.y <= verticalRange.y)
        {
            newY = Mathf.Lerp(verticalOffset.x, verticalOffset.y, (value.y - verticalRange.x) / (verticalRange.y - verticalRange.x));
        }

        rect.anchoredPosition = new Vector2(newX, newY);
    }

    //private void OnRotate(Crowd.Event e)
    //{
    //    RotateEvent re = (RotateEvent)e;
    //    deltaPos += Vector2.Scale(re.delta * 0.01f, new Vector2(isHorizontal ? 1.0f : 0.0f, isVertical ? 1.0f : 0.0f));
    //    deltaPos = new Vector2(
    //        Mathf.Clamp(deltaPos.x, -1, 1),
    //        Mathf.Clamp(deltaPos.y, -1, 1)
    //        );
    //}

    //private void OnZoom(Crowd.Event e)
    //{
    //    ZoomEvent ze = (ZoomEvent)e;
    //    deltaPos += Vector2.Scale(ze.delta, new Vector2(isHorizontal ? 1.0f : 0.0f, isVertical ? 1.0f : 0.0f));
    //    deltaPos = new Vector2(
    //        Mathf.Clamp(deltaPos.x, -1, 1),
    //        Mathf.Clamp(deltaPos.y, -1, 1)
    //        );
    //}
}
