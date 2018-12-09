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
                float o2 = mat.GetFloat(OUTLINE_FACTOR_STRING);
                o1 += (overlayFactor - o1) * fadeSpeed * Time.deltaTime;
                o2 += (outlineFactor - o2) * fadeSpeed * Time.deltaTime;
                mat.SetFloat(OVERLAY_FACTOR_STRING, o1);
                mat.SetFloat(OUTLINE_FACTOR_STRING, o2);
            }
        }
    }

    public void OnStateChange(PropControl.PropState state)
    {
        onInteractionFeedback.Invoke();

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
    }

    public void Breathe()
    {
    }
}
