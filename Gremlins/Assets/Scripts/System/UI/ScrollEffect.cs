using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollEffect : MonoBehaviour
{
    private ScrollRect scrollRect;
    private Transform contentTransform;
    private List<Transform> contentList;

    private float contentDistance;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        contentTransform = scrollRect.content;

        contentList = new List<Transform>();
        foreach (Transform t in contentTransform)
        {
            contentList.Add(t);
        }

        contentDistance = 1.0f / (contentList.Count - 1);
    }

    private void ScaleEffect(int page0, int page1, float value)
    {
        float mid = (page0 * contentDistance + page1 * contentDistance) * 0.5f;
        float scale = Mathf.Max(0.0f, Mathf.Min(1.0f, Mathf.Abs(value - mid) / (contentDistance / 2)));
        float minScale = 0.8f;
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
}
