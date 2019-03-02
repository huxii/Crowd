using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Hint
{
    public string state;
    public UnityEvent onActivated;
    public UnityEvent onDeactivated;
    private bool isActivated = false;

    public bool IsActivated()
    {
        return isActivated;
    }

    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;
            onActivated.Invoke();
        }
    }

    public void Deactivate()
    {
        if (isActivated)
        {
            isActivated = false;
            onDeactivated.Invoke();
        }
    }
}

public class HintsControl : MonoBehaviour
{
    public List<Hint> hints;
    public float hintDelay = 3f;

    private float hintTimer = 0;
    private int curIdx = 0;

    private void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (hintTimer > 0)
        {
            hintTimer -= Time.deltaTime;
            if (hintTimer <= 0)
            {
                if (curIdx < hints.Count)
                {
                    hints[curIdx].Activate();
                }
            }
        }
    }

    public void HintCompleted(string state)
    {
        int idx = -1;
        for (int i = curIdx; i < hints.Count; ++i)
        {
            if (hints[i].state == state)
            {
                idx = i;
                break;
            }
        }

        if (idx != -1)
        {
            for (int i = curIdx; i <= idx; ++i)
            {
                hints[i].Deactivate();
            }
         
            curIdx = idx + 1;

            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        hintTimer = hintDelay;
    }
}
