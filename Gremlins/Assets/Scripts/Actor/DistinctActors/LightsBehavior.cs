using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsBehavior : ObjectControl
{
    [System.Serializable]
    public struct LightAttr
    {
        public string onOff;
        public float interval;
    };

    [Header("Lights")]
    public List<GameObject> lightObjs;
    public List<LightAttr> lightOrder;

    [ColorUsageAttribute(true, true)]
    public Color emissionColor;

    private float timer = 0;
    private int curOrder = 0;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject lightObj in lightObjs)
        {
            lightObj.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", emissionColor);
        }

        LightsOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActivated())
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {               
                ++curOrder;
                if (curOrder >= lightOrder.Count)
                {
                    curOrder -= lightOrder.Count;
                }
                timer = lightOrder[curOrder].interval;

                LightsOn();
            }
        }
    }

    private void LightsOn()
    {
        string onOff = lightOrder[curOrder].onOff;
        for (int i = 0; i < lightObjs.Count; ++i)
        {
            if (onOff[i] == '1')
            {
                lightObjs[i].GetComponent<MeshRenderer>().material.SetFloat("_EmissionIntensity", 1);
            }
            else
            {
                lightObjs[i].GetComponent<MeshRenderer>().material.SetFloat("_EmissionIntensity", 0);
            }
        }
    }

    private void LightsOff()
    {
        foreach (GameObject lightObj in lightObjs)
        {
            lightObj.GetComponent<MeshRenderer>().material.SetFloat("_EmissionIntensity", 0);
        }
    }

    public override void Activate()
    {
        base.Activate();

        timer = lightOrder[curOrder].interval;
        LightsOn();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        LightsOff();
    }
}
