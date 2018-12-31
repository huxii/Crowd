using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameEvents : CustomEvents
{
    // unity events only allow one or zero parameter.
    // so combine two game objects into one by names (eg. "gameobject0, gameobject1")
    public void EnableUnit(string pointName)
    {
        ParseNewPara(pointName);

        GameObject p = ParseGameObject();
        if (p == null)
        {
            return;
        }
        Services.pathFindingManager.EnableUnit(p);
    }

    public void DisableUnit(string pointName)
    {
        ParseNewPara(pointName);

        GameObject p = ParseGameObject();
        if (p == null)
        {
            return;
        }
        Services.pathFindingManager.DisableUnit(p);
    }

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

    public void SelectMan(GameObject man)
    {
        if (man != null && man.GetComponent<CrowdControl>())
        {
            man.GetComponent<CrowdControl>().Selected();
        }
    }

    public void DeselectMan(GameObject man)
    {
        if (man != null && man.GetComponent<CrowdControl>())
        {
            man.GetComponent<CrowdControl>().Deselected();
        }
    }

    public void DeselectMan(List<GameObject> selectedMen)
    {
        foreach (GameObject man in selectedMen)
        {
            man.GetComponent<CrowdControl>().Deselected();
        }
    }

    public void LockMan(GameObject man)
    {
        if (man == null)
        {
            return;
        }
        man.GetComponent<CrowdControl>().Lock();
    }

    public void UnlockMan(GameObject man)
    {
        if (man == null)
        {
            return;
        }
        man.GetComponent<CrowdControl>().Unlock();
    }

    public void StopMan(GameObject man)
    {
        man.GetComponent<CrowdControl>().Stop();
    }

    public void DropMan(GameObject man)
    {
        //Services.eventManager.Fire(new ManDrop(man));

        StopMan(man);
        Services.pathFindingManager.StopActor(man);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(man.transform.position, Vector3.down, 100f);
        if (hits != null)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    Vector3 landPos = hit.point;
                    man.GetComponent<Rigidbody>().DOMove(landPos, 1f).SetEase(Ease.InCubic);
                    break;
                }
            }
        }
    }

    public void TurnMan(GameObject man, Vector3 pos)
    {
        Vector3 dir = (pos - man.transform.position).normalized;
        if (Vector3.Dot(dir, Vector3.right) > Vector3.Dot(dir, -Vector3.right))
        {
            man.GetComponent<CrowdControl>().Flip(-1);
        }
        else
        {
            man.GetComponent<CrowdControl>().Flip(1);
        }
    }

    public void TurnMen(Vector3 pos)
    {
        foreach (GameObject man in Services.men)
        {
            TurnMan(man, pos);
        }
    }

    public void ResetMan(GameObject man)
    {
        man.transform.SetParent(Services.menParentObj.transform);
    }

    public void EndLevelCelebration()
    {
        foreach (GameObject man in Services.men)
        {
            man.GetComponent<CrowdControl>().SwitchState(CrowdControl.CrowdState.CELEBRATE);
            man.GetComponent<CrowdControl>().Lock();
        }
        Services.soundController.Play("levelEnd");
    }
}
