using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class DotweenEvents : MonoBehaviour
{
    private string[] paras;
    private int curParaIdx = 0;
    private Dictionary<GameObject, Sequence> sequenceDict = new Dictionary<GameObject, Sequence>();

    char[] spliters = { ',', ' ' };

    void ParseNewPara(string para)
    {
        paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        curParaIdx = 0;
    }

    GameObject ParseGameObject()
    {
        return GameObject.Find(paras[curParaIdx++]);
    }

    Vector3 ParseIncrement(float x = 0, float y = 0, float z = 0)
    {
        Vector3 inc = new Vector3(x, y, z);
        if (paras[curParaIdx] == "x")
        {
            ++curParaIdx;
            inc = new Vector3(float.Parse(paras[curParaIdx++]), y, z);
        }
        else
        if (paras[curParaIdx] == "y")
        {
            ++curParaIdx;
            inc = new Vector3(x, float.Parse(paras[curParaIdx++]), z);
        }
        else
        if (paras[curParaIdx] == "z")
        {
            ++curParaIdx;
            inc = new Vector3(x, y, float.Parse(paras[curParaIdx++]));
        }
        else
        {
            float nx, ny, nz;
            nx = float.Parse(paras[curParaIdx++]);
            ny = float.Parse(paras[curParaIdx++]);
            nz = float.Parse(paras[curParaIdx++]);
            inc = new Vector3(nx, ny, nz);
        }

        return inc;
    }

    float ParseTime()
    {
        return float.Parse(paras[curParaIdx++]);
    }

    int ParseLoop()
    {
        if (curParaIdx < paras.Length)
        {
            return int.Parse(paras[curParaIdx++]);
        }
        else
        {
            return 1;
        }
    }

    bool ParseIsLocalAxis()
    {
        if (curParaIdx < paras.Length)
        {
            return bool.Parse(paras[curParaIdx++]);
        }
        else
        {
            return false;
        }
    }

    public void Rotate(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaRot = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();

        if (obj == null || DOTween.IsTweening(obj))
        {
            return;
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
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 targetRot = ParseIncrement(obj.transform.localEulerAngles.x, obj.transform.localEulerAngles.y, obj.transform.localEulerAngles.z);
        float time = ParseTime();

        if (obj == null)
        {
            return;
        }

        obj.transform.DOLocalRotate(targetRot, time);
    }

    public void Move(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaPos = ParseIncrement();
        float time = ParseTime();

        if (obj == null)
        {
            return;
        }

        obj.transform.DOLocalMove(obj.transform.localPosition + deltaPos, time);
    }

    //public void MoveTo(string para)
    //{
    //    ParseNewPara(para);

    //    GameObject obj = ParseGameObject();
    //    Vector3 targetPos = ParseIncrement();
    //    float time = ParseTime();

    //    if (obj == null)
    //    {
    //        return;
    //    }

    //    Vector3 targetPos = obj.transform.localPosition;
    //    if (axis.ToLower() == "x")
    //    {
    //        targetPos = new Vector3(inc, targetPos.y, targetPos.z);
    //    }
    //    else
    //    if (axis.ToLower() == "y")
    //    {
    //        targetPos = new Vector3(targetPos.x, inc, targetPos.z);
    //    }
    //    else
    //    if (axis.ToLower() == "z")
    //    {
    //        targetPos = new Vector3(targetPos.x, targetPos.y, inc);
    //    }

    //    obj.transform.DOLocalMove(targetPos, time);
    //}

    public void Ping(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaRot = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();
        bool isLocalAxis = ParseIsLocalAxis();

        if (obj == null)
        {
            return;
        }

        Sequence seq = DOTween.Sequence();
        if (!isLocalAxis)
        {
            Vector3 origPos = obj.transform.localPosition;
            Vector3 targetPos = obj.transform.localPosition + deltaRot;

            seq.Append(obj.transform.DOLocalMove(targetPos, time * 0.5f));
            seq.Append(obj.transform.DOLocalMove(origPos, time * 0.5f));
            seq.SetLoops(loop, LoopType.Restart);
        }
        else
        {
            Vector3 dir = obj.transform.right * deltaRot.x
                + obj.transform.up * deltaRot.y
                + obj.transform.forward * deltaRot.z;
            Vector3 origPos = obj.transform.position;
            Vector3 targetPos = obj.transform.position + dir;

            seq.Append(obj.transform.DOMove(targetPos, time * 0.5f));
            seq.Append(obj.transform.DOMove(origPos, time * 0.5f));
            seq.SetLoops(loop, LoopType.Restart);
        }
    }

    public void PingPong(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaPos = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();
        bool isLocalAxis = ParseIsLocalAxis();

        if (obj == null)
        {
            return;
        }

        Sequence seq = DOTween.Sequence();
        if (!isLocalAxis)
        {
            Vector3 origPos = obj.transform.localPosition;
            Vector3 leftPos = obj.transform.localPosition - deltaPos;
            Vector3 rightPos = obj.transform.localPosition + deltaPos;

            seq.Append(obj.transform.DOLocalMove(rightPos, time * 0.25f).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOLocalMove(leftPos, 0.5f * time).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOLocalMove(origPos, 0.25f * time).SetEase(Ease.Linear));
            seq.SetLoops(loop, LoopType.Restart);
        }
        else
        {
            Vector3 origPos = obj.transform.position;
            Vector3 dir = obj.transform.right * deltaPos.x
                + obj.transform.up * deltaPos.y
                + obj.transform.forward * deltaPos.z;

            Vector3 rightPos = obj.transform.position + dir;
            Vector3 leftPos = obj.transform.position - dir;

            seq.Append(obj.transform.DOMove(rightPos, time * 0.25f).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOMove(leftPos, 0.5f * time).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOMove(origPos, 0.25f * time).SetEase(Ease.Linear));
            seq.SetLoops(loop, LoopType.Restart);
        }
    }

    public void ScaleTo(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 newScale = ParseIncrement(obj.transform.localScale.x, obj.transform.localScale.y, obj.transform.localScale.z);
        float time = ParseTime();

        if (obj == null)
        {
            return;
        }

        obj.transform.DOScale(newScale, time);
    }

    public void Bounce(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 newScale = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();

        if (obj == null)
        {
            return;
        }

        Vector3 origScale = new Vector3(1, 1, 1);
        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DOScale(newScale, time * 0.5f));
        seq.Append(obj.transform.DOScale(origScale, time * 0.5f));
        seq.SetLoops(loop, LoopType.Restart);
    }

    public void Zig(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaRot = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();
        bool isLocalAxis = ParseIsLocalAxis();

        Sequence seq = DOTween.Sequence();

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
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaRot = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();
        bool isLocalAxis = ParseIsLocalAxis();

        Sequence seq = DOTween.Sequence();
        // like bell
        if (!isLocalAxis)
        {
            Vector3 origRot = new Vector3(0, 0, 0);
            Vector3 leftRot = origRot - deltaRot;
            Vector3 rightRot = origRot + deltaRot;

            seq.Append(obj.transform.DOLocalRotate(leftRot, 0.25f * time).SetEase(Ease.Linear));
            seq.Append(obj.transform.DOLocalRotate(rightRot, 0.5f * time).SetEase(Ease.Linear));
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

    public void Shock(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaRot = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();
        bool isLocalAxis = ParseIsLocalAxis();

        Sequence seq = DOTween.Sequence();

        // (x-1)^2 + (y-1)^2 = 1
        float deltaX = 1.0f / loop;
        float curX = 0;
        int sign = 1;
        Vector3[] shockRots = new Vector3[loop];
        for (int i = 0; i < loop; ++i)
        {
            shockRots[i] = sign * deltaRot * (1 - Mathf.Sqrt(2 * curX - curX * curX));
            curX += deltaX;
            sign *= -1;
        }

        Vector3 origRot = obj.transform.localEulerAngles;

        // like bell
        if (!isLocalAxis)
        {           
            seq.Append(obj.transform.DOLocalRotate(origRot + shockRots[0], time / loop / 2).SetEase(Ease.Linear));
            for (int i = 1; i < loop; ++i)
            {
                seq.Append(obj.transform.DOLocalRotate(origRot + shockRots[i], time / loop).SetEase(Ease.Linear));
            }
            seq.Append(obj.transform.DOLocalRotate(origRot, time / loop / 2).SetEase(Ease.Linear));
        }
        // like flags
        else
        {
            Debug.Log(origRot);
            seq.Append(obj.transform.DOLocalRotate(shockRots[0], time / loop / 2, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
            for (int i = 1; i < loop; ++i)
            {
                seq.Append(obj.transform.DOLocalRotate(shockRots[i] - shockRots[i - 1], time / loop, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
            }
            seq.Append(obj.transform.DOLocalRotate(origRot, time / loop / 2).SetEase(Ease.Linear));
        }
    }

    public void Spring(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaPos = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();
        bool isLocalAxis = ParseIsLocalAxis();

        Vector3 origPos = obj.transform.position;
        Vector3 dir = new Vector3(0, 0, 0);
        Sequence seq = DOTween.Sequence();
        float[] shockFactors = new float[loop];
        // (x-1)^2 + (y-1)^2 = 1
        float deltaX = 1.0f / loop;
        float curX = 0;
        int sign = 1;
        for (int i = 0; i < loop; ++i)
        {
            shockFactors[i] = sign * (1 - Mathf.Sqrt(2 * curX - curX * curX));
            curX += deltaX;
            sign *= -1;
        }

        // like bell
        if (!isLocalAxis)
        {
            dir = deltaPos;
        }
        // like flags
        else
        {
            dir = obj.transform.right * deltaPos.x
                + obj.transform.up * deltaPos.y
                + obj.transform.forward * deltaPos.z;
        }

        seq.Append(obj.transform.DOMove(origPos + dir * shockFactors[0], time / loop / 2).SetEase(Ease.Linear));
        for (int i = 1; i < loop; ++i)
        {
            seq.Append(obj.transform.DOMove(origPos + dir * shockFactors[i], time / loop).SetEase(Ease.Linear));
        }
        seq.Append(obj.transform.DOMove(origPos, time / loop / 2).SetEase(Ease.Linear));
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
