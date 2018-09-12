using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    private CinemachineFreeLook freeLookCam = GameObject.Find("FreeLookCamera").GetComponent<CinemachineFreeLook>();

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Orbit(float x, float y)
    {
        //Debug.Log(x + " + " + y);
        freeLookCam.m_XAxis.Value += x;
        freeLookCam.m_YAxis.Value += y;
    }
}
