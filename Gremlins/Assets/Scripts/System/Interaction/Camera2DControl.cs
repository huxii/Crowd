using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera2DControl : CameraControl
{
    private CinemachineVirtualCamera camera2D;
    private float targetOrthoSize;

    private float zoomSpeed = 0.3f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        camera2D = GetComponentInChildren<CinemachineVirtualCamera>();
        targetOrthoSize = camera2D.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= zoomSpeed * Time.deltaTime;
            camera2D.m_Lens.OrthographicSize = Mathf.Lerp(targetOrthoSize, camera2D.m_Lens.OrthographicSize, timer);
        }
    }

    public override void Zoom(float value)
    {
        targetOrthoSize = value;
        timer = 1;
    }

    public void ZoomToLevel()
    {
        Zoom(4);
    }

    public override float OrthographicSize()
    {
        return camera2D.m_Lens.OrthographicSize;
    }
}
