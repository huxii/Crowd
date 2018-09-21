using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class DotweenEvents : MonoBehaviour
{
    private Dictionary<GameObject, Sequence> sequenceDict = new Dictionary<GameObject, Sequence>();

    char[] spliters = { ',', ' ' };

    // objName axis inc time isInfinite
    public void Rotate(string para)
    {        
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);
        bool isInfinite = (paras[4].ToLower() == "true");

        if (obj == null)
        {
            return;
        }

        Vector3 deltaRot = new Vector3(0, 0, 0);
        if (axis.ToLower() == "x")
        {
            deltaRot = new Vector3(inc, 0, 0);
        }
        else
        if (axis.ToLower() == "y")
        {
            deltaRot = new Vector3(0, inc, 0);
        }
        else
        if (axis.ToLower() == "z")
        {
            deltaRot = new Vector3(0, 0, inc);
        }

        if (isInfinite)
        {
            int incNumber = (int)(Mathf.Abs(360f / inc));
            Sequence seq = DOTween.Sequence();
            Vector3 targetRot = obj.transform.eulerAngles + deltaRot;
            for (int i = 0; i < incNumber; ++i)
            {
                seq.Append(obj.transform.DORotate(targetRot, time)
                    //.OnStart(()=> obj.GetComponent<ObjectControl>().UnreadyToDeactivate())
                    .OnComplete(() => { if (obj.GetComponent<ObjectControl>()) obj.GetComponent<ObjectControl>().Pause(); })
                    .SetEase(Ease.Linear).SetDelay(0.3f));
                targetRot += deltaRot;
            }
            seq.SetLoops(-1, LoopType.Restart);

            if (sequenceDict.ContainsKey(obj))
            {
                sequenceDict[obj] = seq;
            }
            else
            {
                sequenceDict.Add(obj, seq);
            }
        }
        else
        {
            Vector3 targetRot = deltaRot;
            obj.transform.DORotate(targetRot, time);
        }
    }

    public void Move(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);

        if (obj == null)
        {
            return;
        }

        Vector3 deltaPos = new Vector3(0, 0, 0);
        if (axis.ToLower() == "x")
        {
            deltaPos = new Vector3(inc, 0, 0);
        }
        else
        if (axis.ToLower() == "y")
        {
            deltaPos = new Vector3(0, inc, 0);
        }
        else
        if (axis.ToLower() == "z")
        {
            deltaPos = new Vector3(0, 0, inc);
        }

        obj.transform.DOMove(obj.transform.position + deltaPos, time);
    }

    public void Scale(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);

        if (obj == null)
        {
            return;
        }

        Vector3 newScale = obj.transform.localScale;
        if (axis.ToLower() == "x")
        {
            newScale  = new Vector3(inc, newScale.y, newScale.z);
        }
        else
        if (axis.ToLower() == "y")
        {
            newScale = new Vector3(newScale.x, inc, newScale.z);
        }
        else
        if (axis.ToLower() == "z")
        {
            newScale = new Vector3(newScale.x, newScale.y, inc);
        }

        obj.transform.DOScale(newScale, time);
    }

    public void Zigzag(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);
        int loop = int.Parse(paras[4]);

        Sequence seq = DOTween.Sequence();
        Vector3 deltaRot = new Vector3(0, 0, 0);
        if (axis.ToLower() == "x")
        {
            deltaRot = new Vector3(inc, 0, 0);
        }
        else
        if (axis.ToLower() == "y")
        {
            deltaRot = new Vector3(0, inc, 0);
        }
        else
        if (axis.ToLower() == "z")
        {
            deltaRot = new Vector3(0, 0, inc);
        }

        Vector3 origRot = transform.eulerAngles;
        Vector3 leftRot = origRot - deltaRot;
        Vector3 rightRot = origRot + deltaRot;

        seq.Append(obj.transform.DORotate(leftRot, 0.25f * time).SetEase(Ease.Linear));
        seq.Append(obj.transform.DORotate(origRot, 0.25f * time).SetEase(Ease.Linear));
        seq.Append(obj.transform.DORotate(rightRot, 0.25f * time).SetEase(Ease.Linear));
        seq.Append(obj.transform.DORotate(origRot, 0.25f * time).SetEase(Ease.Linear));
        seq.SetLoops(loop, LoopType.Restart);
    }

    public void KillSequence(GameObject obj)
    {
        //DOTween.Kill(obj);
        if (obj != null && sequenceDict.ContainsKey(obj))
        {
            sequenceDict[obj].Kill();
        }
    }

    public void KillTransform(Transform objTransform)
    {
        DOTween.Kill(objTransform);
    }
}
