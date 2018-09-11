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

    public void PlayAnimation(GameObject animationObject)
    {
        Animation ani = animationObject.GetComponent<Animation>();
        ani.Play();
    }

    public void Rotate(GameObject obj)
    {
        obj.transform.DORotate(new Vector3(0, 180, 0), 5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);        
    }

    public void DotweenKillTransform(Transform objTransform)
    {
        DOTween.Kill(objTransform);
    }
}
