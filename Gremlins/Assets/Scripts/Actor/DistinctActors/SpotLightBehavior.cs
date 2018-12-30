using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightBehavior : EmissionBehavior
{ 
    void Awake()
    {
        mat = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        mat.SetColor("_EmissionColor", new Color(0, 0, 0, 1));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEmission();
    }

    public void Transit()
    {
        if (GetComponentInChildren<SpotLightBeamBehavior>())
        {
            GetComponentInChildren<SpotLightBeamBehavior>().Transit();
        }
    }
}
