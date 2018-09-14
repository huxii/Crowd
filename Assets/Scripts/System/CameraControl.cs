using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraControl : MonoBehaviour
{
    [System.Serializable]
    public class CameraAttr
    {
        public Vector2 topRigOrbit;
        public Vector2 middleRigOrbit;
        public Vector2 bottomRigOrbit;
        public Vector2 angleRange;
        public Vector2 sensitivity;
    }

    public CameraAttr zoomInAttr;
    public CameraAttr zoomOutAttr;

    private CinemachineFreeLook freeLookCam;
    private CameraAttr targetCameraAttr;
    private Vector2 targetAngle;

    private void Awake()
    {
        freeLookCam = GameObject.Find("FreeLookCamera").GetComponent<CinemachineFreeLook>();
    }

    // Use this for initialization
    void Start()
    {
        ZoomIn();
        targetAngle = new Vector2(freeLookCam.m_XAxis.Value, freeLookCam.m_YAxis.Value);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(freeLookCam.m_XAxis.Value + " " + targetAngle.x);
        float x = freeLookCam.m_XAxis.Value;
        if (x >= 180)
        {
            x -= 360;
        }
        freeLookCam.m_XAxis.Value = Mathf.Lerp(x, targetAngle.x, Time.deltaTime * 8f);
        freeLookCam.m_YAxis.Value = Mathf.Lerp(freeLookCam.m_YAxis.Value, targetAngle.y, Time.deltaTime * 2f);

        Vector2 topOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[0].m_Height, freeLookCam.m_Orbits[0].m_Radius), targetCameraAttr.topRigOrbit, Time.deltaTime * 8f);
        Vector2 middleOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[1].m_Height, freeLookCam.m_Orbits[1].m_Radius), targetCameraAttr.middleRigOrbit, Time.deltaTime * 8f);
        Vector2 bottomOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[2].m_Height, freeLookCam.m_Orbits[2].m_Radius), targetCameraAttr.bottomRigOrbit, Time.deltaTime * 8f);
        freeLookCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(topOrbit.x, topOrbit.y);
        freeLookCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(middleOrbit.x, middleOrbit.y);
        freeLookCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(bottomOrbit.x, bottomOrbit.y);
    }

    public void Orbit(float x, float y)
    {
        float newAngle = targetAngle.x + x / Screen.width * targetCameraAttr.sensitivity.x;
        //if (targetCameraAttr.angleRange.x < 360 && targetCameraAttr.angleRange.y < 360)
        {
            newAngle = Mathf.Max(Mathf.Min(newAngle, targetCameraAttr.angleRange.y), targetCameraAttr.angleRange.x);
        }
        targetAngle.x = newAngle;

        targetAngle.y -= y / Screen.width * targetCameraAttr.sensitivity.y;
    }

    private void ZoomOut()
    {
        targetCameraAttr = zoomOutAttr;

        targetAngle.x = Mathf.Max(Mathf.Min(targetAngle.x, targetCameraAttr.angleRange.y), targetCameraAttr.angleRange.x);
    }

    private void ZoomIn()
    {
        targetCameraAttr = zoomInAttr;

        targetAngle.x = Mathf.Max(Mathf.Min(targetAngle.x, targetCameraAttr.angleRange.y), targetCameraAttr.angleRange.x);
    }

    public void Zoom(float delta)
    {
        if (delta == 0)
        {
            return;
        }
        if (delta > 0)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }
}
