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
    protected float breathLoop = 0;
    protected float fadeSpeed = 5f;

    protected float curOverlayFactor = 0;
    protected float curOutlineFactor = 0;

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void Init()
    {
        GetComponent<ActorControl>().feedbackController = this;
        foreach (Material mat in mats)
        {
            mat.SetFloat(OVERLAY_FACTOR_STRING, overlayFactor);
            mat.SetFloat(OUTLINE_FACTOR_STRING, outlineFactor);
        }
    }

    protected void UpdateFactors()
    {
        if (breathFactor == 0)
        {
            if (Mathf.Abs(curOverlayFactor - overlayFactor) >= 0.0001f)
            {
                curOverlayFactor += (overlayFactor - curOverlayFactor) * fadeSpeed * Time.deltaTime;
                foreach (Material mat in mats)
                {
                    mat.SetFloat(OVERLAY_FACTOR_STRING, curOverlayFactor);
                }
            }

            if (Mathf.Abs(curOutlineFactor - outlineFactor) >= 0.0001f)
            {
                curOutlineFactor += (outlineFactor - curOutlineFactor) * fadeSpeed * Time.deltaTime;
                foreach (Material mat in mats)
                {
                    mat.SetFloat(OUTLINE_FACTOR_STRING, curOutlineFactor);
                }                
            }
        }
        else
        {
            if (breathLoop > 0 || breathLoop == -1)
            {
                if (Mathf.Abs(curOverlayFactor - overlayFactor) >= 0.0001f)
                {
                    curOverlayFactor += (overlayFactor - curOverlayFactor) * fadeSpeed * Time.deltaTime;
                    foreach (Material mat in mats)
                    {
                        mat.SetFloat(OVERLAY_FACTOR_STRING, curOverlayFactor);
                    }
                }

                if (breathFactor > 0)
                {
                    if (curOutlineFactor < outlineWidth - 0.01f)
                    {
                        curOutlineFactor += (outlineWidth - curOutlineFactor) * fadeSpeed * Time.deltaTime;
                        foreach (Material mat in mats)
                        {
                            mat.SetFloat(OUTLINE_FACTOR_STRING, curOutlineFactor);
                        }
                    }
                    else
                    {
                        breathFactor = -1;
                    }
                }
                else
                {
                    if (curOutlineFactor > 0.0001f)
                    {
                        curOutlineFactor -= curOutlineFactor * fadeSpeed * Time.deltaTime;
                        foreach (Material mat in mats)
                        {
                            mat.SetFloat(OUTLINE_FACTOR_STRING, curOutlineFactor);
                        }

                        if (curOutlineFactor <= 0.0001f)
                        {
                            if (breathLoop != -1)
                            {
                                --breathLoop;
                            }
                        }
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
        Breathe(1);
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

    public void Breathe(int loop = -1)
    {
        if (breathFactor == 0)
        {
            breathFactor = 1;
        }

        if (loop == -1)
        {
            breathLoop = -1;
        }
        else
        if (breathLoop != -1)
        {
            breathLoop = loop;
            curOutlineFactor = 0;
        }
    }

    public void StopBreathing()
    {
        breathFactor = 0;
    }
}
