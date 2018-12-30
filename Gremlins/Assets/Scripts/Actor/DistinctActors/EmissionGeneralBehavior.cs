using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionGeneralBehavior : EmissionBehavior
{
    // Use this for initialization
    void Start ()
    {
        mat = null;
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            if (meshRenderer.sharedMaterial.name.ToLower().Contains("inner"))
            {
                if (mat == null)
                {
                    mat = Instantiate(meshRenderer.sharedMaterial);
                    mat.name += "(Instance)";
                }

                meshRenderer.material = mat;
            }
        }

        mat.SetColor("_EmissionColor", new Color(0, 0, 0, 1));
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateEmission();
	}
}
