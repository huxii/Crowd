using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class DotweenEvents : MonoBehaviour
{
    private Dictionary<GameObject, Sequence> sequenceDict = new Dictionary<GameObject, Sequence>();

    char[] spliters = { ',', ' ' };

    public void Rotate(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);
        int loop = 1;
        if (paras.Length >= 5)
        {
            loop = int.Parse(paras[4]);
        }

        if (obj == null || DOTween.IsTweening(obj))
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

        //if (isInfinite)
        //{
        //    int incNumber = (int)(Mathf.Abs(360f / inc));
        //    Sequence seq = DOTween.Sequence();
        //    Vector3 targetRot = obj.transform.eulerAngles + deltaRot;
        //    for (int i = 0; i < incNumber; ++i)
        //    {
        //        seq.Append(obj.transform.DORotate(targetRot, time)
        //            //.OnStart(()=> obj.GetComponent<ObjectControl>().UnreadyToDeactivate())
        //            .OnComplete(() => { if (obj.GetComponent<ObjectControl>()) obj.GetComponent<ObjectControl>().Pause(); })
        //            .SetEase(Ease.Linear).SetDelay(0.3f));
        //        targetRot += deltaRot;
        //    }
        //    seq.SetLoops(-1, LoopType.Restart);

        //    if (sequenceDict.ContainsKey(obj))
        //    {
        //        sequenceDict[obj] = seq;
        //    }
        //    else
        //    {
        //        sequenceDict.Add(obj, seq);
        //    }
        //}
        //else
        {

            Vector3 targetRot = deltaRot + obj.transform.localEulerAngles;
            obj.transform.DOLocalRotate(targetRot, time).SetLoops(loop).SetEase(Ease.Linear);
        }
    }

    public void RotateTo(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float angle = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);

        if (obj == null)
        {
            return;
        }

        Vector3 targetRot = new Vector3(0, 0, 0);
        if (axis.ToLower() == "x")
        {
            targetRot = new Vector3(angle, 0, 0);
        }
        else
        if (axis.ToLower() == "y")
        {
            targetRot = new Vector3(0, angle, 0);
        }
        else
        if (axis.ToLower() == "z")
        {
            targetRot = new Vector3(0, 0, angle);
        }

        obj.transform.DOLocalRotate(targetRot, time);
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

        obj.transform.DOLocalMove(obj.transform.localPosition + deltaPos, time);
    }

    public void MoveTo(string para)
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

        Vector3 targetPos = obj.transform.localPosition;
        if (axis.ToLower() == "x")
        {
            targetPos = new Vector3(inc, targetPos.y, targetPos.z);
        }
        else
        if (axis.ToLower() == "y")
        {
            targetPos = new Vector3(targetPos.x, inc, targetPos.z);
        }
        else
        if (axis.ToLower() == "z")
        {
            targetPos = new Vector3(targetPos.x, targetPos.y, inc);
        }

        obj.transform.DOLocalMove(targetPos, time);
    }

    public void ScaleTo(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float scale = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);

        if (obj == null)
        {
            return;
        }

        Vector3 newScale = obj.transform.localScale;
        if (axis.ToLower() == "x")
        {
            newScale = new Vector3(scale, newScale.y, newScale.z);
        }
        else
        if (axis.ToLower() == "y")
        {
            newScale = new Vector3(newScale.x, scale, newScale.z);
        }
        else
        if (axis.ToLower() == "z")
        {
            newScale = new Vector3(newScale.x, newScale.y, scale);
        }

        obj.transform.DOScale(newScale, time);
    }

    public void Bounce(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        float inc = float.Parse(paras[1]);
        float time = float.Parse(paras[2]);

        if (obj == null)
        {
            return;
        }

        Vector3 origScale = new Vector3(1, 1, 1);
        Vector3 newScale = new Vector3(inc, inc, inc);
        //Vector3 origScale = obj.transform.localScale;
        //Vector3 newScale = obj.transform.localScale * inc;

        obj.transform.DOScale(newScale, time * 0.5f).OnComplete(
            () =>
            {
                obj.transform.DOScale(origScale, time * 0.5f);
            }
            );
    }

    public void Zig(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);
        int loop = int.Parse(paras[4]);
        bool isLocalAxis = false;
        if (paras.Length >= 6)
        {
            isLocalAxis = bool.Parse(paras[5]);
        }

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

        if (!isLocalAxis)
        {
            Vector3 origRot = new Vector3(0, 0, 0);
            Vector3 rightRot = origRot + deltaRot;

            seq.Append(obj.transform.DOLocalRotate(rightRot, 0.5f * time).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOLocalRotate(origRot, 0.5f * time).SetEase(Ease.Linear));
            seq.SetLoops(loop, LoopType.Restart);
        }
        else
        {
            seq.Append(obj.transform.DOLocalRotate(deltaRot, 0.5f * time, RotateMode.LocalAxisAdd).SetEase(Ease.InBack));
            seq.Append(obj.transform.DOLocalRotate(-deltaRot, 0.5f * time, RotateMode.LocalAxisAdd).SetEase(Ease.InBack));
            seq.SetLoops(loop, LoopType.Restart);
        }
    }

    public void Zigzag(string para)
    {
        string[] paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string axis = paras[1];
        float inc = float.Parse(paras[2]);
        float time = float.Parse(paras[3]);
        int loop = int.Parse(paras[4]);
        bool isLocalAxis = false;
        if (paras.Length >= 6)
        {
            isLocalAxis = bool.Parse(paras[5]);
        }

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

        // like bell
        if (!isLocalAxis)
        {
            Vector3 origRot = new Vector3(0, 0, 0);
            Vector3 leftRot = origRot - deltaRot;
            Vector3 rightRot = origRot + deltaRot;

            seq.Append(obj.transform.DOLocalRotate(leftRot, 0.25f * time).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOLocalRotate(origRot, 0.25f * time).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOLocalRotate(rightRot, 0.25f * time).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOLocalRotate(origRot, 0.25f * time).SetEase(Ease.Linear));
            seq.SetLoops(loop, LoopType.Restart);
        }
        // like flags
        else
        {
            seq.Append(obj.transform.DOLocalRotate(deltaRot, 0.25f * time, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCubic));
            seq.Append(obj.transform.DOLocalRotate(-2 * deltaRot, 0.5f * time, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCubic));
            seq.Append(obj.transform.DOLocalRotate(deltaRot, 0.25f * time, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCubic));
            seq.SetLoops(loop, LoopType.Restart);
        }
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
