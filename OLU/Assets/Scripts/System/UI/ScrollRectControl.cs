using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectControl : ScrollRect
{
    [Header("Custom Settings")]
    public bool unlockAllLevel = false;
    public float effectScale = 1.0f;

    private UnityEngine.UI.Extensions.ScrollSnap scrollSnap;
    private List<Transform> contentList;
    private float contentDistance;
    private float contentWidth = 2048f;

    private int targetPage = 0;

    public override void OnEndDrag(PointerEventData data)
    {
        base.OnEndDrag(data);

        UpdatePage();
    }

    //private void ScaleEffect(int page0, int page1, float value)
    //{
    //    float mid = (page0 * contentDistance + page1 * contentDistance) * 0.5f;
    //    float scale = Mathf.Max(0.0f, Mathf.Min(1.0f, Mathf.Abs(value - mid) / (contentDistance / 2)));
    //    float minScale = effectScale;
    //    float newScale = minScale + (1 - minScale) * scale;

    //    if (page0 < contentList.Count)
    //    {
    //        contentList[page0].localScale = new Vector3(newScale, newScale, newScale);
    //    }

    //    if (page1 < contentList.Count)
    //    {
    //        contentList[page1].localScale = new Vector3(newScale, newScale, newScale);
    //    }
    //}

    // update page on scrolling
    private void UpdatePage(int currentPage, int nextPage)
    {
        if (nextPage < content.childCount && nextPage >= 0)
        {
            targetPage = nextPage;
            if (currentPage != targetPage)
            {
                string currentName = content.GetChild(currentPage).name + "Title";
                Services.gameEvents.TriggerAnimation(currentName + " Hide");

                if (targetPage > DataSet.completedLevelIdx)
                {
                    string targetName = content.GetChild(targetPage).name + "Title";
                    Services.gameEvents.TriggerAnimation(targetName + " Appear");
                }
                else
                {
                    string targetName = content.GetChild(targetPage).name + "Title";
                    Services.gameEvents.TriggerAnimation(targetName + " Appear_full");
                }
            }
        }
    }

    // update page on scene change
    private void UpdatePage(int currentPage)
    {
        if (currentPage < content.childCount && currentPage >= 0)
        {
            string currentName = content.GetChild(currentPage).name + "Title";       
            if (DataSet.recentCompletedLevelIdx > DataSet.completedLevelIdx)
            {
                //need transition
                Services.taskManager
                    .Do(new ActionTask(() => Services.gameEvents.TriggerAnimation(currentName + " Appear")))
                    .Then(new Wait(1f))
                    .Then(new ActionTask(() => Services.gameEvents.TriggerAnimation(currentName + " Transition")));

                DataSet.completedLevelIdx = DataSet.recentCompletedLevelIdx;
            }
            else
            {
                if (currentPage > DataSet.completedLevelIdx)
                {
                    Services.gameEvents.TriggerAnimation(currentName + " Appear");
                }
                else
                {
                    Services.gameEvents.TriggerAnimation(currentName + " Appear_full");
                }
            }

        }
    }

    private void UpdatePage()
    {        
        UpdatePage(targetPage, (int)((Mathf.Abs(scrollSnap.GetLerpTarget().x) + 1f) / contentWidth));
    }

    public void RecordContentPosition()
    {
        DataSet.recentContentPos = content.anchoredPosition;
    }

    public void ResumeContentPosition()
    {
        content.anchoredPosition = DataSet.recentContentPos;
        targetPage = (int)((Mathf.Abs(content.anchoredPosition.x) + 1f) / contentWidth);

        Services.taskManager
            .Do(new Wait(3f))
            .Then(new ActionTask(() => UpdatePage(targetPage)));
    }

    public void OnValueChanged(Vector2 scroll)
    {
        Services.mainController.OnCameraAngleUpdated();

        //float value = scroll.x;
        //page0 = Mathf.Abs((int)((-content.anchoredPosition.x - contentWidth / 2 + 5f) / contentWidth));
        //page1 = page0 + 1;
        //page0 = 0;
        //page1 = 1;
        //while (page1 < contentList.Count)
        //{
        //    if (value >= page0 * contentDistance && value < page1 * contentDistance)
        //    {
        //        break;
        //    }

        //    ++page0;
        //    ++page1;
        //}

        //ScaleEffect(page0, page1, value);
    }

    public void Init()
    {
        if (DataSet.unlockedLevelIdx == -1)
        {
            // the first time enter the game, need to unlock title screen
            DataSet.unlockedLevelIdx = 0;
            DataSet.completedLevelIdx = 0;
            DataSet.recentCompletedLevelIdx = 0;
            targetPage = 0;
        }

        scrollSnap = GetComponent<UnityEngine.UI.Extensions.ScrollSnap>();
        contentList = new List<Transform>();
        foreach (Transform t in content)
        {
            contentList.Add(t);
        }
        contentDistance = 1.0f / (contentList.Count - 1);

        ResumeContentPosition();

        if (!unlockAllLevel)
        {
            if (DataSet.recentCompletedLevelIdx == DataSet.unlockedLevelIdx && DataSet.recentCompletedLevelIdx > DataSet.completedLevelIdx)
            {
                // the newest level is just completed & need to unlock next level
                if (DataSet.unlockedLevelIdx < contentList.Count - 1)
                {
                    // this is not the last level
                    ++DataSet.unlockedLevelIdx;
                }
            }

            for (int i = DataSet.unlockedLevelIdx + 1; i < contentList.Count; ++i)
            {
                contentList[i].gameObject.SetActive(false);
            }
        }
        else
        {
            DataSet.unlockedLevelIdx = contentList.Count - 1;
        }
    }

    public void NextScreen()
    {
        scrollSnap.NextScreen();
        UpdatePage();
    }

    public void MoveToLevelSelect()
    {
        if (DataSet.unlockedLevelIdx <= 0)
        {
            DataSet.unlockedLevelIdx = 1;
            contentList[1].gameObject.SetActive(true);
        }

        Services.taskManager
            .Do(new Wait(0.5f))
            .Then(new ActionTask(NextScreen));
    }
}
