using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropFeedbackBehavior : InteractableFeedbackBehavior
{    
    // Use this for initialization
    void Start()
    {
        if (targetObj == null)
        {
            targetObj = gameObject;
        }
        MeshRenderer[] meshRenderers = targetObj.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshRenderers)
        {
            mats.AddRange(mesh.materials);
        }

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFactors();
    }
}
