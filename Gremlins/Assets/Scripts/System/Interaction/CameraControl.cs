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

    [System.Serializable]
    public class CameraAttr
    {
        public Vector2 topRigOrbit;
        public Vector2 middleRigOrbit;
        public Vector2 bottomRigOrbit;
        public Vector2 angleRange;
        public Vector2 angleZero = new Vector2(0, 90f);
        public Vector2 sensitivity;
        public Vector3 translateZero;
        public Vector4 translateRange;
    }

    public GameObject pivots;

    public int maxZoomLevel = 0;
    public int defaultZoomLevel = 0;
    public List<CameraAttr> zoomLevelAttrs;
    protected int zoomLevel = 0;

    protected CameraAttr targetCameraAttr;
    [SerializeField]
    protected Vector2 targetAngle;
    protected Vector3 targetTranslate;
    protected Vector3 origTranslate;
    protected Vector2 cameraSpeed;

    protected Vector2 zoomCameraSpeed = new Vector2(8, 8);
    protected Vector2 clickCameraSpeed = new Vector2(1, 1);

    protected bool isEnabled = true;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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

    public void SetOrbit(float x, float y)
    {
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

    private void ZoomOut()
    {
        SetZoom(zoomLevel - 1);
    }

    protected void ZoomIn()
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
                //onEnterMaxZoomOut.Invoke();
            }
            else
            if (zoomLevel == 0)
            {
                //onExitMaxZoomOut.Invoke();
            }

            if (level != zoomLevel)
            {
                Services.eventManager.Fire(new ZoomEvent());
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

    public bool isZoomed()
    {
        return zoomLevel != defaultZoomLevel;
    }

    public void Focus(Vector3 pos)
    {
        float ratioX = Mathf.Clamp((pos.x - Services.navMeshMinBound.x) / (Services.navMeshMaxBound.x - Services.navMeshMinBound.x), 0, 1);
        float ratioY = Mathf.Clamp((pos.y - Services.navMeshMinBound.y) / (Services.navMeshMaxBound.y - Services.navMeshMinBound.y), 0.5f, 1);
        SetOrbit(-1, Mathf.Sin(ratioY * 90f / 180f * Mathf.PI));

        //Debug.Log(pos + " " + Mathf.Sin(ratioY * 90f) + " " + ratioY);
    }

    public void SetEnable(bool en)
    {
        isEnabled = en;
    }
}
