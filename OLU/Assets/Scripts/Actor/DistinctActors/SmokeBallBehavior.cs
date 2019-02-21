using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBallBehavior : MonoBehaviour
{
    private Material mat;

    private float dissolveTimer = -1;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetFloat("_ReplaceFactor", 1);
        mat.SetFloat("_DissolveTimer", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (dissolveTimer >= 0 && dissolveTimer < 1)
        {
            dissolveTimer += Time.deltaTime * 0.2f;
            mat.SetFloat("_DissolveTimer", dissolveTimer);
        }
    }

    public void StartDissolve()
    {
        dissolveTimer = 0;
        mat.SetFloat("_DissolveTimer", 0);
        mat.SetFloat("_DissolveNoiseOffset", Random.Range(0f, 1f));
    }
}
