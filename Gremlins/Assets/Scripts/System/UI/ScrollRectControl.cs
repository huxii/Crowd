using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectControl : ScrollRect
{
    public bool enableDragging = true;
    public float effectScale = 1.0f;

    private UnityEngine.UI.Extensions.ScrollSnap scrollSnap;
    private List<Transform> contentList;
    private int contentIdx = 0;
    private float contentDistance;

    private void Update()
    {
        // not inited
        if (scrollSnap == null)
        {
            scrollSnap = GetComponent<UnityEngine.UI.Extensions.ScrollSnap>();

            contentList = new List<Transform>();
            foreach (Transform t in content)
            {
                contentList.Add(t);
                t.gameObject.SetActive(false);
            }
            contentList[contentIdx].gameObject.SetActive(true);
            ++contentIdx;
            contentDistance = 1.0f / (contentList.Count - 1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SetDragging(true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SetDragging(false);
        }
    }

    private void ScaleEffect(int page0, int page1, float value)
    {
        float mid = (page0 * contentDistance + page1 * contentDistance) * 0.5f;
        float scale = Mathf.Max(0.0f, Mathf.Min(1.0f, Mathf.Abs(value - mid) / (contentDistance / 2)));
        float minScale = effectScale;
        float newScale = minScale + (1 - minScale) * scale;

        if (page0 < contentList.Count)
        {
            contentList[page0].localScale = new Vector3(newScale, newScale, newScale);
        }

        if (page1 < contentList.Count)
        {
            contentList[page1].localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    // will disable both ScrollRect & ScrollSnap when dragging is disabled
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (enableDragging)
        {
            base.OnBeginDrag(eventData);
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (enableDragging)
        {
            base.OnDrag(eventData);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (enableDragging)
        {
            base.OnEndDrag(eventData);
        }
    }

    public void SetDragging(bool en)
    {
        enableDragging = en;
        scrollSnap.enableDragging = en;
    }

    public void OnValueChanged(Vector2 scroll)
    {
        float value = scroll.x;
        int page0 = 0;
        int page1 = 1;
        while (page1 < contentList.Count)
        {
            if (value >= page0 * contentDistance && value < page1 * contentDistance)
            {
                break;
            }

            ++page0;
            ++page1;
        }

        ScaleEffect(page0, page1, value);
    }

    public void NextScreen()
    {        
        scrollSnap.NextScreen();
    }

    public void UnlockNextScreen()
    {
        if (contentIdx >= contentList.Count)
        {
            return;
        }

        contentList[contentIdx].gameObject.SetActive(true);
        ++contentIdx;
    }
}
