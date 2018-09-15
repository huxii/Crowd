using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GameEvents : MonoBehaviour
{
    // unity events only allow one or zero parameter.
    // so combine two game objects into one by names (eg. "gameobject0, gameobject1")
    public void ConnectPathPoints(string pointsName)
    {
        string[] pointsNames = pointsName.Split(',');
        if (pointsNames.Length != 2)
        {
            return;
        }

        GameObject p0 = GameObject.Find(pointsNames[0]);
        GameObject p1 = GameObject.Find(pointsNames[1]);
        if (p0 == null || p1 == null)
        {
            return;
        }
        Services.pathFindingManager.ConnectPathPoints(p0, p1);
    }

    public void DisconnectPathPoints(string pointsName)
    {
        string[] pointsNames = pointsName.Split(',');
        if (pointsNames.Length != 2)
        {
            return;
        }

        GameObject p0 = GameObject.Find(pointsNames[0]);
        GameObject p1 = GameObject.Find(pointsNames[1]);
        if (p0 == null || p1 == null)
        {
            return;
        }
        Services.pathFindingManager.DisconnectPathPoints(p0, p1);
    }

    public void PlayAnimation(string animParas)
    {
        string[] paras = animParas.Split(',');
        GameObject obj = GameObject.Find(paras[0]);
        string animName = paras[1];
        Animation ani = obj.GetComponent<Animation>();
        ani[animName].speed = 1;
        ani.Play();
    }

    public void RewindAnimation(string animParas)
    {
        string[] paras = animParas.Split(',');
        GameObject obj = GameObject.Find(paras[0]);
        string animName = paras[1];
        Animation ani = obj.GetComponent<Animation>();
        ani[animName].speed = -1;
        if (!ani.isPlaying)
        {
            ani[animName].time = ani[animName].length;
        }
        ani.Play();
    }

    public void DotweenRotate(string para)
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
        obj.GetComponent<ObjectControl>().SetSequence(seq);
    }

    public void DotweenKillSequence(GameObject obj)
    {
        //DOTween.Kill(obj);
        obj.GetComponent<ObjectControl>().GetSequence().Kill();
    }

    public void DotweenKillTransform(Transform objTransform)
    {
        DOTween.Kill(objTransform);
    }
}
