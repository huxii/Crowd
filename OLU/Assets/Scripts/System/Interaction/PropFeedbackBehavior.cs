using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropFeedbackBehavior : OutlineFeedbackBehavior
{
    private bool inited = false;

    void Awake()
    {
        GetComponent<PropControl>().PropFeedbackController = this;
        if (targetObj == null)
        {
            targetObj = gameObject;
        }

        // replace the shared material to a new intance 
        if (targetObj.GetComponentInChildren<MeshRenderer>())
        {
            Material mat = targetObj.GetComponentInChildren<MeshRenderer>().sharedMaterial;
            Material newInstance = Instantiate(mat);
            MeshRenderer[] meshRenderers = targetObj.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshRenderers)
            {
                if (mesh.sharedMaterial.name.ToLower().Contains("interactable"))
                {
                    mesh.material = newInstance;
                }
            }

            mats.Add(newInstance);
        }

        foreach (Material mat in mats)
        {
            mat.SetFloat(OVERLAY_FACTOR_STRING, overlayFactor);
            mat.SetFloat(OUTLINE_FACTOR_STRING, outlineFactor);
        }
    }

    public override void OnInteract()
    {
        if (!inited)
        {
            inited = true;
            Services.utils.RecalculateNormals(targetObj);
        }

        onInteractionFeedback.Invoke();
        Breathe(1);
    }
}
