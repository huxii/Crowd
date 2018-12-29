using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DayAndNightBehavior : MonoBehaviour
{
    public float time = 1;

    [SerializeField]
    private List<Material> mats;
    private float curFactor = 1;
    private bool isRunning = false;

    // Use this for initialization
    void Start()
    {
        mats = new List<Material>();
        // hack
        mats.Add(GameObject.Find("InnerBackground").GetComponentInChildren<MeshRenderer>().sharedMaterial);
        mats.Add(GameObject.Find("Nail").GetComponentInChildren<MeshRenderer>().sharedMaterial);
        foreach (MeshRenderer meshRenderer in GameObject.Find("Interactables").GetComponentsInChildren<MeshRenderer>())
        {
            mats.AddRange(meshRenderer.sharedMaterials);
        }
        mats = mats.ToArray().Distinct().ToList();

        foreach (Material mat in mats)
        {
            mat.SetFloat("_ReplaceFactor", curFactor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            curFactor -= 1.0f / time * Time.deltaTime;
            foreach (Material mat in mats)
            {
                mat.SetFloat("_ReplaceFactor", curFactor);
            }

            if (curFactor <= 0)
            {
                isRunning = false;
            }

        }
    }

    public void StartRunning()
    {
        isRunning = true;
    }
}
