using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class CameraFreeLookControl : CameraControl
{
    // cinemachine : x - 0~360    y - 0~1.0
    // cameracontrol: x - 0~360    y - 0~180
    // should convert when applying angles to cinemachine

    private CinemachineFreeLook freeLookCam;

    private void Awake()
    {
        freeLookCam = GetComponentInChildren<CinemachineFreeLook>();
    }

    // Use this for initialization
    void Start()
    {
        zoomLevel = defaultZoomLevel;

        targetCameraAttr = zoomLevelAttrs[zoomLevel];
        freeLookCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(targetCameraAttr.topRigOrbit.x, targetCameraAttr.topRigOrbit.y);
        freeLookCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(targetCameraAttr.middleRigOrbit.x, targetCameraAttr.middleRigOrbit.y);
        freeLookCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(targetCameraAttr.bottomRigOrbit.x, targetCameraAttr.bottomRigOrbit.y);

        targetAngle = targetCameraAttr.angleZero;
        freeLookCam.m_XAxis.Value = targetAngle.x;
        freeLookCam.m_YAxis.Value = targetAngle.y / 180f;

        origTranslate = targetCameraAttr.translateZero;
        pivots.transform.position = origTranslate;
        targetTranslate = origTranslate;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(freeLookCam.m_XAxis.Value + "---" + targetAngle.x);
        freeLookCam.m_XAxis.Value = Services.utils.LerpRotation(freeLookCam.m_XAxis.Value, targetAngle.x, cameraSpeed.x);
        freeLookCam.m_YAxis.Value = Services.utils.LerpRotation(freeLookCam.m_YAxis.Value * 180, targetAngle.y, cameraSpeed.y) / 180;

        Vector2 topOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[0].m_Height, freeLookCam.m_Orbits[0].m_Radius), targetCameraAttr.topRigOrbit, Time.deltaTime * 8f);
        Vector2 middleOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[1].m_Height, freeLookCam.m_Orbits[1].m_Radius), targetCameraAttr.middleRigOrbit, Time.deltaTime * 8f);
        Vector2 bottomOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[2].m_Height, freeLookCam.m_Orbits[2].m_Radius), targetCameraAttr.bottomRigOrbit, Time.deltaTime * 8f);
        freeLookCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(topOrbit.x, topOrbit.y);
        freeLookCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(middleOrbit.x, middleOrbit.y);
        freeLookCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(bottomOrbit.x, bottomOrbit.y);

        pivots.transform.position = Vector3.Lerp(pivots.transform.position, targetTranslate, Time.deltaTime * 10f);
    }
}
