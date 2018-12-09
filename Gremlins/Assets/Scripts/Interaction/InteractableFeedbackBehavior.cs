using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractableFeedbackBehavior : MonoBehaviour
{    
    // the reaction when player interacts with it
    // eg. model bounces a little bit
    public UnityEvent onInteractionFeedback;
    //public Vector3 progressBarPosOffset = new Vector3(0, 0, 0);

    public float outlineWidth = 0.4f;
    public GameObject targetObj;

    [SerializeField]
    protected List<Material> mats = new List<Material>();

    protected const string OVERLAY_FACTOR_STRING = "_OverlayFactor";
    protected const string OUTLINE_FACTOR_STRING = "_OutlineWidth";

    protected float overlayFactor = 0;
    protected float outlineFactor = 0;
    protected float breathFactor = 0;
    protected float fadeSpeed = 5f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void UpdateFactors()
    {
        if (breathFactor == 0)
        {
            foreach (Material mat in mats)
            {
                float o1 = mat.GetFloat(OVERLAY_FACTOR_STRING);
                if (Mathf.Abs(o1 - overlayFactor) >= 0.01f)
                {
                    o1 += (overlayFactor - o1) * fadeSpeed * Time.deltaTime;
                    mat.SetFloat(OVERLAY_FACTOR_STRING, o1);
                }

                float o2 = mat.GetFloat(OUTLINE_FACTOR_STRING);
                if (Mathf.Abs(o2 - outlineFactor) >= 0.01f)
                {
                    o2 += (outlineFactor - o2) * fadeSpeed * Time.deltaTime;
                    mat.SetFloat(OUTLINE_FACTOR_STRING, o2);
                }
            }
        }
        else
        {
            foreach (Material mat in mats)
            {
                float o1 = mat.GetFloat(OVERLAY_FACTOR_STRING);
                if (Mathf.Abs(o1 - overlayFactor) >= 0.01f)
                {
                    o1 += (overlayFactor - o1) * fadeSpeed * Time.deltaTime;
                    mat.SetFloat(OVERLAY_FACTOR_STRING, o1);
                }

                float b = mat.GetFloat(OUTLINE_FACTOR_STRING);
                //Debug.Log(b + " " + breathFactor + " " + outlineWidth);
                if (breathFactor > 0)
                {
                    if (b < outlineWidth - 0.01f)
                    {
                        b += (outlineWidth - b) * fadeSpeed * Time.deltaTime;
                        mat.SetFloat(OUTLINE_FACTOR_STRING, b);
                    }
                    else
                    {
                        breathFactor = -1;
                    }                  
                }
                else
                {
                    if (b > 0.01f)
                    {
                        b -= b * fadeSpeed * Time.deltaTime;
                        mat.SetFloat(OUTLINE_FACTOR_STRING, b);
                    }
                    else
                    {
                        breathFactor = 1;
                    }
                }
            }
        }
    }

    public void OnInteract()
    {
        onInteractionFeedback.Invoke();
    }

    public void OnStateChange(PropControl.PropState state)
    {
        switch (state)
        {
            case PropControl.PropState.EMPTY:
                overlayFactor = 0;
                outlineFactor = 0;
                break;
            case PropControl.PropState.NOTFULL:
                overlayFactor = 0;
                outlineFactor = outlineWidth;
                break;
            case PropControl.PropState.FULL:
                overlayFactor = 1;
                outlineFactor = outlineWidth;
                break;
            default:
                overlayFactor = 0;
                outlineFactor = 0;
                break;                                                                      
        }

        StopBreathing();
    }

    public void Breathe()
    {
        if (breathFactor == 0)
        {
            breathFactor = 1;
        }
    }

    public void StopBreathing()
    {
        breathFactor = 0;
    }
}
