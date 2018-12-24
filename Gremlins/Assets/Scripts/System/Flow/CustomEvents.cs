using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomEvents : MonoBehaviour
{
    protected char[] spliters = { ',', ' ' };
    protected string[] paras;
    protected int curParaIdx = 0;

    protected void ParseNewPara(string para)
    {
        paras = para.Split(spliters, System.StringSplitOptions.RemoveEmptyEntries);
        curParaIdx = 0;
    }

    protected GameObject ParseGameObject()
    {
        if (curParaIdx < paras.Length)
        {
            return GameObject.Find(paras[curParaIdx++]);
        }

        return null;
    }

    protected Vector3 ParseIncrement(float x = 0, float y = 0, float z = 0)
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

    protected float ParseTime()
    {
        return float.Parse(paras[curParaIdx++]);
    }

    protected float ParseSpeed()
    {
        return float.Parse(paras[curParaIdx++]);
    }

    protected float ParseAlpha()
    {
        return float.Parse(paras[curParaIdx++]);
    }

    protected string ParseAnimationName()
    {
        if (curParaIdx < paras.Length)
        {
            return paras[curParaIdx++];
        }

        return null;
    }

    protected int ParseLoop()
    {
        if (curParaIdx < paras.Length)
        {
            int loop = 1;
            if (int.TryParse(paras[curParaIdx], out loop))
            {
                ++curParaIdx;
                return loop;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 1;
        }
    }

    protected bool ParseIsLocalAxis(bool defaultAxis = false)
    {
        if (curParaIdx < paras.Length)
        {
            bool isLocal = defaultAxis;
            if (bool.TryParse(paras[curParaIdx], out isLocal))
            {
                ++curParaIdx;
                return isLocal;
            }
            else
            {
                return defaultAxis;
            }
        }
        else
        {
            return defaultAxis;
        }
    }

    protected Ease ParseEaseType(Ease easeType = Ease.Unset)
    {
        if (curParaIdx < paras.Length)
        {
            Ease retEaseType = Ease.Unset;
            switch (paras[curParaIdx])
            {
                case "OutBounce":
                    retEaseType = Ease.OutBounce;
                    break;
                case "InSine":
                    retEaseType = Ease.InSine;
                    break;
                case "OutSine":
                    retEaseType = Ease.OutSine;
                    break;
                case "InOutSine":
                    retEaseType = Ease.InOutSine;
                    break;
                case "InCubic":
                    retEaseType = Ease.InCubic;
                    break;
                case "OutCubic":
                    retEaseType = Ease.OutCubic;
                    break;
                case "InOutCubic":
                    retEaseType = Ease.InOutCubic;
                    break;
                case "InOutQuad":
                    retEaseType = Ease.InOutQuad;
                    break;
                case "InQuad":
                    retEaseType = Ease.InQuad;
                    break;
                case "OutQuad":
                    retEaseType = Ease.OutQuad;
                    break;
                case "Linear":
                    retEaseType = Ease.Linear;
                    break;
                default:
                    break;
            }

            if (retEaseType != Ease.Unset)
            {
                ++curParaIdx;
                return retEaseType;
            }
            else
            {
                return easeType;
            }
        }
        else
        {
            return easeType;
        }
    }
}
