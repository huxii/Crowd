using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PropFeedbackBehavior : InteractableFeedbackBehavior
{
    void Awake()
    {
        if (targetObj == null)
        {
            targetObj = gameObject;
        }

        // replace the shared material to a new intance 
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

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFactors();
    }
}
