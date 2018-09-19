using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRenderImage : MonoBehaviour
{
    public Material mat;
    public Matrix4x4 clipToWorld;

    Camera cam;

    // Use this for initialization
    void Start ()
    {
        cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.Depth;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {       
        
        // NOTE: VR doesn't seem to work. Why is unity's camera projection matrix so inconsistent?

        //var clipToWorld = (camera.projectionMatrix * camera.worldToCameraMatrix).inverse;// << Is there a way to make this method work indead?

        // NOTE: code was ported from: https://gamedev.stackexchange.com/questions/131978/shader-reconstructing-position-from-depth-in-vr-through-projection-matrix
        // More clerification of whats going on is needed!
        var p = GL.GetGPUProjectionMatrix(cam.projectionMatrix, false);// Unity flips its 'Y' vector depending on if its in VR, Editor view or game view etc... (facepalm)
        p[2, 3] = p[3, 2] = 0.0f;
        p[3, 3] = 1.0f;
        clipToWorld = Matrix4x4.Inverse(p * cam.worldToCameraMatrix) * Matrix4x4.TRS(new Vector3(0, 0, -p[2, 2]), Quaternion.identity, Vector3.one);
        mat.SetMatrix("_ClipToWorld", clipToWorld);
        
        Graphics.Blit(src, dest, mat);
    }
}
