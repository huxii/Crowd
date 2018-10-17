using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    // cinemachine : x - 0~360    y - 0~1.0
    // cameracontrol: x - 0~360    y - 0~180
    // should convert when applying angles to cinemachine

    public UnityEvent onEnterMaxZoomOut;
    public UnityEvent onExitMaxZoomOut;

    [System.Serializable]
    public class CameraAttr
    {
        public Vector2 topRigOrbit;
        public Vector2 middleRigOrbit;
        public Vector2 bottomRigOrbit;
        public Vector2 angleRange;
        public Vector2 angleZero = new Vector2(0, 90f);
        public Vector2 sensitivity;
        public Vector4 translateRange;
    }

    public GameObject pivots;

    public int maxZoomLevel = 0;
    public List<CameraAttr> zoomLevelAttrs;
    private int zoomLevel = 0;

    private CinemachineFreeLook freeLookCam;
    private CameraAttr targetCameraAttr;
    private Vector2 targetAngle;
    private Vector3 targetDeltaTranslate;
    private Vector3 origTranslate;
    private Vector2 cameraSpeed;

    private Vector2 zoomCameraSpeed = new Vector2(8, 8);
    private Vector2 clickCameraSpeed = new Vector2(1, 1);

    private void Awake()
    {
        freeLookCam = GameObject.Find("FreeLookCamera").GetComponent<CinemachineFreeLook>();
    }

    // Use this for initialization
    void Start()
    {
        origTranslate = pivots.transform.position;

        targetCameraAttr = zoomLevelAttrs[zoomLevel];
        freeLookCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(targetCameraAttr.topRigOrbit.x, targetCameraAttr.topRigOrbit.y);
        freeLookCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(targetCameraAttr.middleRigOrbit.x, targetCameraAttr.middleRigOrbit.y);
        freeLookCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(targetCameraAttr.bottomRigOrbit.x, targetCameraAttr.bottomRigOrbit.y);

        targetAngle = targetCameraAttr.angleZero;
        freeLookCam.m_XAxis.Value = targetAngle.x;
        freeLookCam.m_YAxis.Value = targetAngle.y / 180f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(freeLookCam.m_XAxis.Value + " " + targetAngle.x);
        float x = freeLookCam.m_XAxis.Value;
        float targetAngleX = Clamp360(targetAngle.x);

        if (Mathf.Abs(targetAngleX - x) < 0.001f)
        {
            freeLookCam.m_XAxis.Value = targetAngleX;
        }
        else
        if (Mathf.Abs(targetAngleX - x) > 180)
        {
            if (targetAngleX > x)
            {
                freeLookCam.m_XAxis.Value -= (x - targetAngleX + 360f) * Time.deltaTime * cameraSpeed.x;
                if (freeLookCam.m_XAxis.Value < 0.01f)
                {
                    freeLookCam.m_XAxis.Value = 360f;
                }
            }
            else
            {
                freeLookCam.m_XAxis.Value += (360 - x + targetAngleX) * Time.deltaTime * cameraSpeed.x;
                if (freeLookCam.m_XAxis.Value > 359.99f)
                {
                    freeLookCam.m_XAxis.Value = 0f;
                }
            }
        }
        else
        {
            freeLookCam.m_XAxis.Value = Mathf.Lerp(freeLookCam.m_XAxis.Value, targetAngleX, Time.deltaTime * cameraSpeed.x);
        }

        float y = freeLookCam.m_YAxis.Value * 180;
        if (Mathf.Abs(targetAngle.y - y) < 0.001f)
        {
            freeLookCam.m_YAxis.Value = targetAngle.y / 180;
        }
        else
        {
            freeLookCam.m_YAxis.Value = Mathf.Lerp(y, targetAngle.y, Time.deltaTime * cameraSpeed.y) / 180;
        }

        Vector2 topOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[0].m_Height, freeLookCam.m_Orbits[0].m_Radius), targetCameraAttr.topRigOrbit, Time.deltaTime * 8f);
        Vector2 middleOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[1].m_Height, freeLookCam.m_Orbits[1].m_Radius), targetCameraAttr.middleRigOrbit, Time.deltaTime * 8f);
        Vector2 bottomOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[2].m_Height, freeLookCam.m_Orbits[2].m_Radius), targetCameraAttr.bottomRigOrbit, Time.deltaTime * 8f);
        freeLookCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(topOrbit.x, topOrbit.y);
        freeLookCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(middleOrbit.x, middleOrbit.y);
        freeLookCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(bottomOrbit.x, bottomOrbit.y);

        pivots.transform.position = Vector3.Lerp(pivots.transform.position, origTranslate + targetDeltaTranslate, Time.deltaTime * 2f);
    }

    private float Clamp360(float angle)
    {
        int loop = (int)Mathf.Abs(angle / 360f);

        if (angle < 0)
        {
            angle += 360f * (loop + 1);
        }
        else
        {
            angle -= 360f * loop;
        }

        return angle;
    }

    public void ResetTranslate()
    {
        targetDeltaTranslate = new Vector3(0, 0, 0);
    }

    public void Translate(float x, float y)
    {
        float nx = targetDeltaTranslate.x - x;
        float ny = targetDeltaTranslate.y - y;
        nx = Mathf.Min(targetCameraAttr.translateRange[2], Mathf.Max(targetCameraAttr.translateRange[0], nx));
        ny = Mathf.Min(targetCameraAttr.translateRange[3], Mathf.Max(targetCameraAttr.translateRange[1], ny));
        targetDeltaTranslate = new Vector3(nx, ny, 0);
    }

    public void Orbit(float x, float y)
    {
        float newAngleX = targetAngle.x + x / Screen.width * targetCameraAttr.sensitivity.x;

        if (Mathf.Abs(targetCameraAttr.angleRange.x) < 180)
        {
            newAngleX = Mathf.Max(Mathf.Min(newAngleX, targetCameraAttr.angleRange.y), targetCameraAttr.angleRange.x);
        }
        targetAngle.x = newAngleX;

        float newAngleY = targetAngle.y - y / Screen.height * targetCameraAttr.sensitivity.y;
        newAngleY = Mathf.Max(Mathf.Min(newAngleY, 180), 0);
        targetAngle.y = newAngleY;

        cameraSpeed = zoomCameraSpeed;
    }

    public void SetOrbit(float x, float y)
    {
        if (x >= 0 && x <= 1)
        {
            targetAngle.x = targetCameraAttr.angleRange.x + x * (targetCameraAttr.angleRange.y - targetCameraAttr.angleRange.x);
        }

        if (y >= 0 && y <= 1)
        {
            targetAngle.y = y * 180f;
        }

        cameraSpeed = clickCameraSpeed;
    }

    private void ZoomOut()
    {
        SetZoom(zoomLevel - 1);
    }

    private void ZoomIn()
    {
        SetZoom(zoomLevel + 1);
    }

    public void Zoom(float delta)
    {
        // 0.1f is the scale of mouse wheel
        if (Mathf.Abs(delta) < 0.1f)
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

    public void SetZoom(int level)
    {
        if (level >= 0 && level < maxZoomLevel)
        {
            if (level == 0)
            {
                onEnterMaxZoomOut.Invoke();
            }
            else
            if (zoomLevel == 0)
            {
                onExitMaxZoomOut.Invoke();
            }

            ResetTranslate();
            cameraSpeed = zoomCameraSpeed;

            zoomLevel = level;
            targetCameraAttr = zoomLevelAttrs[zoomLevel];
            targetAngle = targetCameraAttr.angleZero;
        }
    }
}
