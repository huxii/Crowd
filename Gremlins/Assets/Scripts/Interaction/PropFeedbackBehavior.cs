using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropFeedbackBehavior : InteractableFeedbackBehavior
{    
    // Use this for initialization
    void Start()
    {
        GetComponent<ActorControl>().feedbackController = this;

        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshRenderers)
        {
            mats.AddRange(mesh.materials);
        }

        foreach (Material mat in mats)
        {
            mat.SetFloat(OVERLAY_FACTOR_STRING, overlayFactor);
            mat.SetFloat(OUTLINE_FACTOR_STRING, outlineFactor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFactors();
    }
}
