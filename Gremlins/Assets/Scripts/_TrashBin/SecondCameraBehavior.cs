using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraBehavior : MonoBehaviour
{
    private RenderTexture renderTex;

    // Use this for initialization
    void Start()
    {
        CreateRenderTexture();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.transform.hasChanged)
        {
            transform.parent.transform.hasChanged = false;

            transform.position = transform.parent.transform.position;
            transform.rotation = transform.parent.transform.rotation;

            // assume that resolution is fixed...
            //CreateRenderTexture();
        }
    }

    void CreateRenderTexture()
    {
        renderTex = new RenderTexture(Screen.width, Screen.height, 0);
        renderTex.depth = 32;
        GetComponent<Camera>().targetTexture = renderTex;
        //Camera.main.GetComponent<WaterColorFilterSystem.WaterColorFilter>().SetRenderTexture(renderTex);
    }
}
