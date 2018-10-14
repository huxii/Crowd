﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GameEvents : MonoBehaviour
{
    char[] spliters = { ',', ' ' };

    // unity events only allow one or zero parameter.
    // so combine two game objects into one by names (eg. "gameobject0, gameobject1")
    public void ConnectPathPoints(string pointsName)
    {
        string[] pointsNames = pointsName.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
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
        string[] pointsNames = pointsName.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
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

    public void SetFollowPathPoint(string pointsName)
    {
        string[] pointsNames = pointsName.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        if (pointsNames.Length != 2)
        {
            return;
        }

        GameObject p0 = GameObject.Find(pointsNames[0]);
        GameObject p1 = GameObject.Find(pointsNames[1]);

        p0.GetComponent<PathPoint>().followPoint = p1;
    }

    public void ClearFollowPathPoint(string pointsName)
    {
        string[] pointsNames = pointsName.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        if (pointsNames.Length != 1)
        {
            return;
        }

        GameObject p0 = GameObject.Find(pointsNames[0]);

        p0.GetComponent<PathPoint>().followPoint = null;
    }

    public void PlayAnimation(string animParas)
    {
        string[] paras = animParas.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        GameObject obj = GameObject.Find(paras[0]);
        string animName = paras[1];
        Animation ani = obj.GetComponent<Animation>();
        ani[animName].speed = 1;
        ani.Play();
    }

    public void RewindAnimation(string animParas)
    {
        string[] paras = animParas.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
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

    public void LoadScene(string scene)
    {
        Services.sceneManager.LoadScene(scene);
    }
}