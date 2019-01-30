using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera2DControl : CameraControl
{
    private CinemachineVirtualCamera camera2D;
    private float targetOrthoSize;

    // Start is called before the first frame update
    void Start()
    {
        camera2D = GetComponentInChildren<CinemachineVirtualCamera>();
        targetOrthoSize = camera2D.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Zoom(float delta)
    {
        base.Zoom(delta);

        
    }
}
