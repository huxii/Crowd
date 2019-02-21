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

        Material newOuterInstance = Instantiate(GameObject.Find("InnerBackground").GetComponentInChildren<MeshRenderer>().sharedMaterial);
        Material newInnerInstance = Instantiate(GameObject.Find("Nail").GetComponentInChildren<MeshRenderer>().sharedMaterial);
        Material newCutoutInstance = Instantiate(GameObject.Find("WindowKnot").GetComponentInChildren<MeshRenderer>().sharedMaterial);
        mats.Add(newOuterInstance);
        mats.Add(newInnerInstance);
        mats.Add(newCutoutInstance);

        foreach (MeshRenderer meshRenderer in GameObject.Find("Lock").GetComponentsInChildren<MeshRenderer>())
        {
            if (meshRenderer.sharedMaterial.name.ToLower().Contains("instance"))
            {
                mats.Add(meshRenderer.sharedMaterial);
            }
            else
            if (meshRenderer.sharedMaterial.name.ToLower().Contains("outer"))
            {
                meshRenderer.material = newOuterInstance;
            }
            else
            if (meshRenderer.sharedMaterial.name.ToLower().Contains("inner") &&
                !meshRenderer.sharedMaterial.name.ToLower().Contains("interactable"))
            {
                meshRenderer.material = newInnerInstance;
            }
            else
            if (meshRenderer.sharedMaterial.name.ToLower().Contains("cutout"))
            {
                meshRenderer.material = newCutoutInstance;
            }
        }

        foreach (MeshRenderer meshRenderer in GameObject.Find("Interactables").GetComponentsInChildren<MeshRenderer>())
        {
            mats.AddRange(meshRenderer.sharedMaterials);
        }

        Material newThickRopeInstance = null;
        Material newThinRopeInstance = null;

        foreach (SpriteRenderer spriteRenderer in GameObject.Find("Lock").GetComponentsInChildren<SpriteRenderer>())
        {
            if (spriteRenderer.sharedMaterial.name.ToLower().Contains("rope_thick"))
            {
                if (newThickRopeInstance == null)
                {
                    newThickRopeInstance = Instantiate(spriteRenderer.sharedMaterial);
                }
                spriteRenderer.material = newThickRopeInstance;
            }
            else
            if (spriteRenderer.sharedMaterial.name.ToLower().Contains("rope"))
            {
                if (newThinRopeInstance == null)
                {
                    newThinRopeInstance = Instantiate(spriteRenderer.sharedMaterial);
                }
                spriteRenderer.material = newThinRopeInstance;
            }
        }
        mats.Add(newThickRopeInstance);
        mats.Add(newThinRopeInstance);

        mats = mats.ToArray().Distinct().ToList();

        GameObject[] men = GameObject.FindGameObjectsWithTag("Man");
        foreach (GameObject man in men)
        {
            mats.Add(man.GetComponentInChildren<MeshRenderer>().material);
        }

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
