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

    protected bool isEnabled = true;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RecordFrameToFile(string filename = null, float delayTime = 1f)
    {
        Services.mainController.gameObject.GetComponent<FPSDisplay>().enabled = false;
        Services.hudController.gameObject.SetActive(false);

        if (filename == null)
        {
            filename = "C:/Users/huxin/Desktop/" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "_cover";
        }

        string filename0 = filename + "_green";

        StartCoroutine(WaitForRecordFrameToFile(filename + ".png", delayTime));
        StartCoroutine(WaitForRecordFrameToFileGreen(filename0 + ".png", delayTime + 1f));
    }

    IEnumerator WaitForRecordFrameToFile(string filename, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot(filename);
    }

    IEnumerator WaitForRecordFrameToFileGreen(string filename, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GameObject.Find("Background").SetActive(false);
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot(filename);
    }

    public void SetEnable(bool en)
    {
        isEnabled = en;
    }

    public void Focus(Vector3 pos)
    {
        float ratioX = Mathf.Clamp((pos.x - Services.navMeshMinBound.x) / (Services.navMeshMaxBound.x - Services.navMeshMinBound.x), 0, 1);
        float ratioY = Mathf.Clamp((pos.y - Services.navMeshMinBound.y) / (Services.navMeshMaxBound.y - Services.navMeshMinBound.y), 0.5f, 1);
        SetOrbit(-1, Mathf.Sin(ratioY * 90f / 180f * Mathf.PI));

        //Debug.Log(pos + " " + Mathf.Sin(ratioY * 90f) + " " + ratioY);
    }

    public virtual void ResetAngle()
    {
    }

    public virtual void ResetTranslate()
    {
    }

    public virtual void SetTranslate(float x, float y)
    {
    }

    public virtual void Translate(float x, float y)
    {
    }

    public virtual Vector2 Orbit(float x, float y)
    {
        return new Vector2(0, 0);
    }

    public virtual void SetOrbit(float x, float y)
    {
    }

    public virtual Vector2 CurrentOrbit()
    {
        return new Vector2(0, 0);
    }

    public virtual void ResumeZoom()
    {
    }

    public virtual void FreeZoom(float rigDelta)
    {
    }

    public virtual void SetZoom(int level)
    {
    }

    // zoom on level
    public virtual void Zoom(float value)
    {
    }

    public virtual float OrthographicSize()
    {
        return 22;
    }
}
