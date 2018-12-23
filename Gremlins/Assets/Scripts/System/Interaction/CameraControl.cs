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
    public int defaultZoomLevel = 0;
    public List<CameraAttr> zoomLevelAttrs;
    private int zoomLevel = 0;

    private CinemachineFreeLook freeLookCam;
    private CameraAttr targetCameraAttr;
    [SerializeField]
    private Vector2 targetAngle;
    private Vector3 targetTranslate;
    private Vector3 origTranslate;
    private Vector2 cameraSpeed;

    private Vector2 zoomCameraSpeed = new Vector2(8, 8);
    private Vector2 clickCameraSpeed = new Vector2(1, 1);

    private bool enabled = true;

    private void Awake()
    {
        freeLookCam = GameObject.Find("FreeLookCamera").GetComponent<CinemachineFreeLook>();
    }

    // Use this for initialization
    void Start()
    {
        zoomLevel = defaultZoomLevel;
        origTranslate = pivots.transform.position;
        targetTranslate = origTranslate;

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

    public void ResetAngle()
    {
        targetAngle = targetCameraAttr.angleZero;
    }

    public void ResetTranslate()
    {
        targetTranslate = origTranslate;
    }

    public void SetTranslate(float x, float y)
    {
        float nx = x;
        float ny = y;
        nx = Mathf.Min(targetCameraAttr.translateRange[2] + origTranslate.x, Mathf.Max(targetCameraAttr.translateRange[0] + origTranslate.x, nx));
        ny = Mathf.Min(targetCameraAttr.translateRange[3] + origTranslate.y, Mathf.Max(targetCameraAttr.translateRange[1] + origTranslate.y, ny));
        targetTranslate = new Vector3(nx, ny, 0);
    }

    public void Translate(float x, float y)
    {
        float nx = targetTranslate.x - x;
        float ny = targetTranslate.y - y;
        nx = Mathf.Min(targetCameraAttr.translateRange[2] + origTranslate.x, Mathf.Max(targetCameraAttr.translateRange[0] + origTranslate.x, nx));
        ny = Mathf.Min(targetCameraAttr.translateRange[3] + origTranslate.y, Mathf.Max(targetCameraAttr.translateRange[1] + origTranslate.y, ny));
        targetTranslate = new Vector3(nx, ny, 0);
    }

    public Vector2 Orbit(float x, float y)
    {
        if (enabled)
        {
            float newAngleX = targetAngle.x + x / Screen.width * targetCameraAttr.sensitivity.x;
            //Debug.Log(targetAngle.x + "..." + newAngleX);
            if (Mathf.Abs(targetCameraAttr.angleRange.x) < 180)
            {
                newAngleX = Mathf.Max(Mathf.Min(newAngleX, targetCameraAttr.angleRange.y), targetCameraAttr.angleRange.x);
            }

            float newAngleY = targetAngle.y - y / Screen.height * targetCameraAttr.sensitivity.y;
            newAngleY = Mathf.Max(Mathf.Min(newAngleY, 180), 0);

            Vector2 newAngle = new Vector2(newAngleX, newAngleY);
            Vector2 delta = newAngle - targetAngle;
            targetAngle = newAngle;

            cameraSpeed = zoomCameraSpeed;

            return delta;
        }

        return new Vector2(0, 0);
    }

    public void SetOrbit(float x, float y)
    {
        if (enabled)
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

            if (level != zoomLevel)
            {
                Services.eventManager.Fire(new ZoomEvent());
            }

            zoomLevel = level;
            targetCameraAttr = zoomLevelAttrs[zoomLevel];
            targetAngle = targetCameraAttr.angleZero;           
        }
    }

    public bool isZoomed()
    {
        return zoomLevel != defaultZoomLevel;
    }

    public void SetEnable(bool en)
    {
        enabled = en;
    }
}
