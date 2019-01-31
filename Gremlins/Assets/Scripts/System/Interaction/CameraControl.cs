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

    public virtual void SetZoom(int level)
    {
    }

    public virtual void Zoom(float value)
    {
    }

    public virtual float OrthographicSize()
    {
        return 22;
    }
}
