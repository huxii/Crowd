﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class DotweenEvents : CustomEvents
{
    private Dictionary<GameObject, Sequence> sequenceDict = new Dictionary<GameObject, Sequence>();

    public void Rotate(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaRot = ParseIncrement();
        float time = ParseTime();
        int loop = ParseLoop();
        bool isLocalAxis = ParseIsLocalAxis(false);
        Ease easeType = ParseEaseType(Ease.InOutFlash);

        if (obj == null || DOTween.IsTweening(obj))
        {
            return;
        }

        Vector3 targetRot = deltaRot + obj.transform.localEulerAngles;
        if (isLocalAxis)
        {
            obj.transform.DOLocalRotate(targetRot, time, RotateMode.LocalAxisAdd).SetLoops(loop).SetEase(easeType);
        }
        else
        {
            obj.transform.DOLocalRotate(targetRot, time).SetLoops(loop).SetEase(easeType);
        }
    }

    public void RotateTo(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 targetRot = ParseIncrement(obj.transform.localEulerAngles.x, obj.transform.localEulerAngles.y, obj.transform.localEulerAngles.z);
        float time = ParseTime();
        Ease easeType = ParseEaseType(Ease.InOutQuad);

        if (obj == null)
        {
            return;
        }

        obj.transform.DOLocalRotate(targetRot, time).SetEase(easeType);

        Debug.Log(obj.name);
    }

    public void MoveRb(GameObject obj, string para)
    {
        ParseNewPara(para);

        Vector3 deltaPos = ParseIncrement();
        float time = ParseTime();
        bool isLocal = ParseIsLocalAxis();
        Ease easeType = ParseEaseType(Ease.Linear);

        if (obj.GetComponent<Rigidbody2D>())
        {
            obj.GetComponent<Rigidbody2D>().DOMove(obj.transform.position + deltaPos, time).SetEase(easeType);
        }
        else
        if (obj.GetComponent<Rigidbody>())
        {
            obj.GetComponent<Rigidbody>().DOMove(obj.transform.position + deltaPos, time).SetEase(easeType);
        }
    }

    public void MoveRbTo(GameObject obj, string para)
    {
        ParseNewPara(para);

        Vector3 targetPos = ParseIncrement(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
        float speed = ParseSpeed();
        Ease easeType = ParseEaseType(Ease.Linear);

        if (obj.GetComponent<Rigidbody2D>())
        {
            obj.GetComponent<Rigidbody2D>().DOMove(targetPos, Vector3.Distance(targetPos, obj.transform.position) / speed).SetEase(easeType);
        }
        else
        if (obj.GetComponent<Rigidbody>())
        {
            obj.GetComponent<Rigidbody>().DOMove(targetPos, Vector3.Distance(targetPos, obj.transform.position) / speed).SetEase(easeType);
        }
    }

    public void Move(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 deltaPos = ParseIncrement();
        float time = ParseTime();
        bool isLocal = ParseIsLocalAxis(true);
        Ease easeType = ParseEaseType(Ease.InOutFlash);

        if (obj == null)
        {
            return;
        }

        if (isLocal)
        {
            obj.transform.DOLocalMove(obj.transform.localPosition + deltaPos, time).SetEase(easeType);
        }
        else
        {
            obj.transform.DOMove(obj.transform.localPosition + deltaPos, time).SetEase(easeType);
        }
    }

    public void MoveTo(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 targetPos = ParseIncrement(obj.transform.localPosition.x, obj.transform.localPosition.y, obj.transform.localPosition.z);
        float time = ParseTime();
        bool isLocal = ParseIsLocalAxis(true);
        Ease easeType = ParseEaseType();

        if (obj == null)
        {
            return;
        }

        if (isLocal)
        {
            obj.transform.DOLocalMove(targetPos, time).SetEase(easeType);
        }
        else
        {
            obj.transform.DOMove(targetPos, time).SetEase(easeType);
        }
    }

    public void Ping(string para)
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
            Vector3 targetPos = obj.transform.localPosition + deltaPos;

            seq.Append(obj.transform.DOLocalMove(targetPos, time * 0.5f));
            seq.Append(obj.transform.DOLocalMove(origPos, time * 0.5f));
            seq.SetLoops(loop, LoopType.Restart);
        }
        else
        {
            Vector3 dir = obj.transform.right * deltaPos.x
                + obj.transform.up * deltaPos.y
                + obj.transform.forward * deltaPos.z;
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

    public void Scale(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        Vector3 newScale = ParseIncrement(1, 1, 1);
        newScale = new Vector3(
            obj.transform.localScale.x * newScale.x,
            obj.transform.localScale.y * newScale.y,
            obj.transform.localScale.z * newScale.z
            );
        float time = ParseTime();

        if (obj == null)
        {
            return;
        }

        obj.transform.DOScale(newScale, time);
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
        Ease easeType = ParseEaseType(Ease.InBack);

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
            seq.Append(obj.transform.DOLocalRotate(deltaRot, 0.5f * time, RotateMode.LocalAxisAdd).SetEase(easeType));
            seq.Append(obj.transform.DOLocalRotate(-deltaRot, 0.5f * time, RotateMode.LocalAxisAdd).SetEase(easeType));
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
        Ease easeType = ParseEaseType(Ease.Linear);

        Sequence seq = DOTween.Sequence();
        // like bell
        if (!isLocalAxis)
        {
            Vector3 origRot = new Vector3(0, 0, 0);
            Vector3 leftRot = origRot - deltaRot;
            Vector3 rightRot = origRot + deltaRot;

            seq.Append(obj.transform.DOLocalRotate(leftRot, 0.25f * time).SetEase(easeType));
            seq.Append(obj.transform.DOLocalRotate(rightRot, 0.5f * time).SetEase(easeType));
            seq.Append(obj.transform.DOLocalRotate(origRot, 0.25f * time).SetEase(easeType));
            seq.SetLoops(loop, LoopType.Restart);
        }
        // like flags
        else
        {
            seq.Append(obj.transform.DOLocalRotate(deltaRot, 0.25f * time, RotateMode.LocalAxisAdd).SetEase(easeType));
            seq.Append(obj.transform.DOLocalRotate(-2 * deltaRot, 0.5f * time, RotateMode.LocalAxisAdd).SetEase(easeType));
            seq.Append(obj.transform.DOLocalRotate(deltaRot, 0.25f * time, RotateMode.LocalAxisAdd).SetEase(easeType));
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
            seq.Append(obj.transform.DOLocalRotate(origRot + shockRots[0], time / loop / 2));
            for (int i = 1; i < loop; ++i)
            {
                seq.Append(obj.transform.DOLocalRotate(origRot + shockRots[i], time / loop));
            }
            seq.Append(obj.transform.DOLocalRotate(origRot, time / loop / 2).SetEase(Ease.Linear));
        }
        // like flags
        else
        {
            //Debug.Log(origRot);
            seq.Append(obj.transform.DOLocalRotate(shockRots[0], time / loop / 2, RotateMode.LocalAxisAdd));
            for (int i = 1; i < loop; ++i)
            {
                seq.Append(obj.transform.DOLocalRotate(shockRots[i] - shockRots[i - 1], time / loop, RotateMode.LocalAxisAdd));
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

    public void HideSprite(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    public void FadeSprite(string para)
    {
        ParseNewPara(para);

        GameObject obj = ParseGameObject();
        float targetAlpha = ParseAlpha();
        float time = ParseTime();
        obj.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, targetAlpha), time);
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
