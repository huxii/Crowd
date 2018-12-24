using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : CustomEvents
{
    // unity events only allow one or zero parameter.
    // so combine two game objects into one by names (eg. "gameobject0, gameobject1")
    public void ConnectPath(string pointsName)
    {
        ParseNewPara(pointsName);

        GameObject p0 = ParseGameObject();
        GameObject p1 = ParseGameObject();
        if (p0 == null || p1 == null)
        {
            return;
        }
        Services.pathFindingManager.ConnectPath(p0, p1);
    }

    public void DisconnectPath(string pointsName)
    {
        ParseNewPara(pointsName);

        GameObject p0 = ParseGameObject();
        GameObject p1 = ParseGameObject();
        if (p0 == null || p1 == null)
        {
            return;
        }
        Services.pathFindingManager.DisconnectPath(p0, p1);
    }

    public void SetFollowPathPoint(string pointsName)
    {
        ParseNewPara(pointsName);

        GameObject p0 = ParseGameObject();
        GameObject p1 = ParseGameObject();

        p0.GetComponent<PathPoint>().followPoint = p1;
    }

    public void ClearFollowPathPoint(string pointsName)
    {
        ParseNewPara(pointsName);

        GameObject p0 = ParseGameObject();
        GameObject p1 = ParseGameObject();

        p0.GetComponent<PathPoint>().followPoint = null;
    }

    public void PlayAnimation(string animParas)
    {
        ParseNewPara(animParas);

        GameObject obj = ParseGameObject();
        string aniName = ParseAnimationName();

        Animation ani = obj.GetComponent<Animation>();
        if (aniName == null)
        {
            ani.Play();
        }
        else
        {
            ani.Play(aniName);
        }
    }

    public void StopAnimation(string animParas)
    {
        ParseNewPara(animParas);

        GameObject obj = ParseGameObject();
        string aniName = ParseAnimationName();

        Animation ani = obj.GetComponent<Animation>();
        if (aniName == null)
        {
            ani.Stop();
        }
        else
        {
            ani.Stop(aniName);
        }
    }

    public void RewindAnimation(string animParas)
    {
        ParseNewPara(animParas);

        GameObject obj = ParseGameObject();
        string aniName = ParseAnimationName();
        if (aniName == null)
        {
            return;
        }

        Animation ani = obj.GetComponent<Animation>();
        ani[aniName].speed = -1;
        if (!ani.isPlaying)
        {
            ani[aniName].time = ani[aniName].length;
        }
        ani.Play();
    }

    public void LoadScene(string scene)
    {
        Services.sceneManager.LoadScene(scene);
    }

    public void MoveActorTo(string para)
    {
        ParseNewPara(para);

        GameObject actor = ParseGameObject();
        if (actor == null)
        {
            return;
        }

        Vector3 pos = ParseIncrement();

        Services.gameController.SetManTargetPosition(actor, pos, 0.1f);
    }

    public void MakeFloatMan(GameObject man, float height = 2f)
    {
        if (man == null)
        {
            return;
        }

        man.GetComponent<CrowdControl>().Lock();
        man.AddComponent<FloatBehavior>();
    }
}
