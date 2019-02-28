using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFreeLookControl : CameraControl
{
    // cinemachine : x - 0~360    y - 0~1.0
    // cameracontrol: x - 0~360    y - 0~180
    // should convert when applying angles to cinemachine
    [System.Serializable]
    public struct FreeLookCamAttr
    {
        public Vector2 topRigOrbit;
        public Vector2 middleRigOrbit;
        public Vector2 bottomRigOrbit;
        public Vector2 angleRange;
        public Vector2 angleZero;
        public Vector2 sensitivity;
        public Vector3 translateZero;
        public Vector4 translateRange;
    }

    public bool startWithZoom = false;
    public float startDelay = 0f;
    public GameObject pivots;

    public int maxZoomLevel = 0;
    public int defaultZoomLevel = 0;
    public List<FreeLookCamAttr> zoomLevelAttrs;

    protected int zoomLevel = 0;

    protected FreeLookCamAttr targetCameraAttr;
    [SerializeField]
    protected Vector2 targetAngle;
    [SerializeField]
    protected Vector3 targetTranslate;
    [SerializeField]
    protected Vector3 origTranslate;
    protected Vector2 cameraSpeed;

    protected Vector2 zoomCameraSpeed = new Vector2(8, 8);
    protected Vector2 clickCameraSpeed = new Vector2(1, 1);

    private CinemachineFreeLook freeLookCam;
    private bool inited;

    private void Awake()
    {
        freeLookCam = GetComponentInChildren<CinemachineFreeLook>();
    }

    private void Start()
    {
        StartCoroutine(InitDelay(startDelay));

        zoomLevel = defaultZoomLevel;

        targetCameraAttr = zoomLevelAttrs[zoomLevel];
        targetAngle = targetCameraAttr.angleZero;
        origTranslate = targetCameraAttr.translateZero;
        targetTranslate = origTranslate;

        if (!startWithZoom)
        {
            pivots.transform.position = origTranslate;
            freeLookCam.m_XAxis.Value = targetAngle.x;
            freeLookCam.m_YAxis.Value = targetAngle.y / 180f;
            freeLookCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(targetCameraAttr.topRigOrbit.x, targetCameraAttr.topRigOrbit.y);
            freeLookCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(targetCameraAttr.middleRigOrbit.x, targetCameraAttr.middleRigOrbit.y);
            freeLookCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(targetCameraAttr.bottomRigOrbit.x, targetCameraAttr.bottomRigOrbit.y);            
        }

        inited = false;
        freeLookCam.enabled = false;

        //RecordFrameToFile(null, 1f);
    }

    IEnumerator InitDelay(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);

        Init();
    }

    private void Init()
    {
        inited = true;
        freeLookCam.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // wait for cinemachine init to avoid unsync
        if (!inited)
        {
            //Init();
        }
        else
        {
            //Debug.Log(freeLookCam.m_XAxis.Value + "---" + targetAngle.x);
            freeLookCam.m_XAxis.Value = Services.utils.LerpRotation(freeLookCam.m_XAxis.Value, targetAngle.x, cameraSpeed.x);
            freeLookCam.m_YAxis.Value = Services.utils.LerpRotation(freeLookCam.m_YAxis.Value * 180, targetAngle.y, cameraSpeed.y) / 180;

            Vector2 topOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[0].m_Height, freeLookCam.m_Orbits[0].m_Radius), targetCameraAttr.topRigOrbit, Time.deltaTime * 5f);
            Vector2 middleOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[1].m_Height, freeLookCam.m_Orbits[1].m_Radius), targetCameraAttr.middleRigOrbit, Time.deltaTime * 5f);
            Vector2 bottomOrbit = Vector2.Lerp(new Vector2(freeLookCam.m_Orbits[2].m_Height, freeLookCam.m_Orbits[2].m_Radius), targetCameraAttr.bottomRigOrbit, Time.deltaTime * 5f);
            freeLookCam.m_Orbits[0] = new CinemachineFreeLook.Orbit(topOrbit.x, topOrbit.y);
            freeLookCam.m_Orbits[1] = new CinemachineFreeLook.Orbit(middleOrbit.x, middleOrbit.y);
            freeLookCam.m_Orbits[2] = new CinemachineFreeLook.Orbit(bottomOrbit.x, bottomOrbit.y);

            pivots.transform.position = Vector3.Lerp(pivots.transform.position, targetTranslate, Time.deltaTime * 10f);

            Services.mainController.UpdateParallaxScrolling();
        }
    }

    protected void ZoomOut()
    {
        SetZoom(zoomLevel - 1);
    }

    protected void ZoomIn()
    {
        SetZoom(zoomLevel + 1);
    }

    public bool isZoomed()
    {
        return zoomLevel != defaultZoomLevel;
    }

    public override void ResetAngle()
    {
        base.ResetAngle();

        targetAngle = targetCameraAttr.angleZero;
    }

    public override void ResetTranslate()
    {
        base.ResetTranslate();

        targetTranslate = origTranslate;
    }

    public override void SetTranslate(float x, float y)
    {
        base.SetTranslate(x, y);

        float nx = x;
        float ny = y;
        nx = Mathf.Min(targetCameraAttr.translateRange[2] + origTranslate.x, Mathf.Max(targetCameraAttr.translateRange[0] + origTranslate.x, nx));
        ny = Mathf.Min(targetCameraAttr.translateRange[3] + origTranslate.y, Mathf.Max(targetCameraAttr.translateRange[1] + origTranslate.y, ny));
        targetTranslate = new Vector3(nx, ny, 0);
    }

    public override void Translate(float x, float y)
    {
        base.Translate(x, y);

        float nx = targetTranslate.x - x;
        float ny = targetTranslate.y - y;
        nx = Mathf.Min(targetCameraAttr.translateRange[2] + origTranslate.x, Mathf.Max(targetCameraAttr.translateRange[0] + origTranslate.x, nx));
        ny = Mathf.Min(targetCameraAttr.translateRange[3] + origTranslate.y, Mathf.Max(targetCameraAttr.translateRange[1] + origTranslate.y, ny));
        targetTranslate = new Vector3(nx, ny, 0);
    }

    public override Vector2 Orbit(float x, float y)
    {
        if (isEnabled)
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

    public override void SetOrbit(float x, float y)
    {
        base.SetOrbit(x, y);

        if (isEnabled)
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

    public override void ResumeZoom()
    {
        base.ResumeZoom();

        FreeLookCamAttr attr = zoomLevelAttrs[zoomLevel];
        targetCameraAttr.middleRigOrbit = attr.middleRigOrbit;
        targetCameraAttr.topRigOrbit = attr.topRigOrbit;
        targetCameraAttr.bottomRigOrbit = attr.bottomRigOrbit;
    }

    public override void FreeZoom(float rigDelta)
    {
        base.FreeZoom(rigDelta);

        targetCameraAttr.middleRigOrbit += new Vector2(0, rigDelta);
        targetCameraAttr.topRigOrbit += new Vector2(0, rigDelta);
        targetCameraAttr.bottomRigOrbit += new Vector2(0, rigDelta);
    }

    public override void SetZoom(int level)
    {
        base.SetZoom(level);

        if (level >= 0 && level < maxZoomLevel)
        {
            if (level == 0)
            {
                //onEnterMaxZoomOut.Invoke();
            }
            else
            if (zoomLevel == 0)
            {
                //onExitMaxZoomOut.Invoke();
            }

            if (level != zoomLevel)
            {
                Services.eventManager.Fire(new ZoomEvent((zoomLevelAttrs[level].angleZero - targetAngle)));
            }

            zoomLevel = level;
            targetCameraAttr = zoomLevelAttrs[zoomLevel];
            targetAngle = targetCameraAttr.angleZero;

            origTranslate = targetCameraAttr.translateZero;
            pivots.transform.position = origTranslate;
            ResetTranslate();

            cameraSpeed = zoomCameraSpeed;
        }
    }

    public override void Zoom(float value)
    {
        base.Zoom(value);

        // 0.1f is the scale of mouse wheel
        if (Mathf.Abs(value) < 0.1f)
        {
            return;
        }
        if (value > 0)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    public override Vector2 CurrentOrbit()
    {
        return new Vector2(freeLookCam.m_XAxis.Value, freeLookCam.m_YAxis.Value * 180f);
    }
}
