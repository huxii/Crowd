using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class DotweenEvents : MonoBehaviour
{
    private Dictionary<GameObject, Sequence> sequenceDict = new Dictionary<GameObject, Sequence>();

    public void Rotate(string para)
    {
        string[] paras = para.Split(',');
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);

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

        int incNumber = (int)(Mathf.Abs(360f / inc));
        Sequence seq = DOTween.Sequence();
        Vector3 targetRot = obj.transform.eulerAngles + deltaRot;
        for (int i = 0; i < incNumber; ++i)
        {
            seq.Append(obj.transform.DORotate(targetRot, 1f)
                //.OnStart(()=> obj.GetComponent<ObjectControl>().UnreadyToDeactivate())
                .OnComplete(() => obj.GetComponent<ObjectControl>().Pause())
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

    public void Move(string para)
    {
        string[] paras = para.Split(',');
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);

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

        obj.transform.DOMove(obj.transform.position + deltaPos, 1f);
    }

    public void KillSequence(GameObject obj)
    {
        //DOTween.Kill(obj);
        if (sequenceDict.ContainsKey(obj))
        {
            sequenceDict[obj].Kill();
        }
    }

    public void KillTransform(Transform objTransform)
    {
        DOTween.Kill(objTransform);
    }
}
