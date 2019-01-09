using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionControl : MonoBehaviour
{
    GameObject transitionScreen = null;
    Camera transitionCamera = null;
    int transitionLayer = 31;
    int orthoSize = 22;
    bool isFading = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Transition");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (isFading)
        {
            Color c = transitionScreen.GetComponent<MeshRenderer>().material.color;
            float alpha = c.a;
            alpha -= Time.deltaTime;
            transitionScreen.GetComponent<MeshRenderer>().material.color = new Color(
                c.r,
                c.g,
                c.b,
                alpha
                );

            if (alpha <= 0)
            {
                isFading = false;

                transitionScreen.SetActive(false);
                transitionCamera.enabled = false;
                Destroy(transitionScreen.GetComponent<MeshRenderer>().material.mainTexture);
            }
        }
    }

    public void GenerateTransitionScreen()
    {
        if (!transitionCamera)
        {
            transitionCamera = gameObject.AddComponent<Camera>();
        }

        transitionCamera.orthographic = true;
        transitionCamera.orthographicSize = orthoSize;
        transitionCamera.nearClipPlane = -1f;
        transitionCamera.farClipPlane = 1f;
        transitionCamera.depth = float.MaxValue;
        transitionCamera.cullingMask = 1 << transitionLayer;
        transitionCamera.clearFlags = CameraClearFlags.Nothing;
        transitionCamera.enabled = true;

        if (!transitionScreen)
        {
            // transtion screen
            transitionScreen = new GameObject();
            transitionScreen.transform.SetParent(transform);
            transitionScreen.name = "TransitionScreen";
            transitionScreen.layer = transitionLayer;
            transitionScreen.AddComponent<MeshFilter>();
            transitionScreen.AddComponent<MeshRenderer>();

            float halfHeight = transitionCamera.orthographicSize;
            float halfWidth = halfHeight * Screen.width / Screen.height;
            Mesh mesh = new Mesh();
            mesh.vertices = new Vector3[] {
                new Vector3( -halfWidth, -halfHeight, 0 ),
                new Vector3( -halfWidth, halfHeight, 0 ),
                new Vector3( halfWidth, -halfHeight, 0 ),
                new Vector3( halfWidth, halfHeight, 0 )
            };
            mesh.uv = new Vector2[]
            {
                new Vector2( 0, 0 ),
                new Vector2( 0, 1 ),
                new Vector2( 1, 0 ),
                new Vector2( 1, 1 )
            };
            mesh.triangles = new int[] { 0, 1, 2, 3, 2, 1 };
            mesh.name = "TransitionQuad";
            transitionScreen.GetComponent<MeshFilter>().mesh = mesh;

            Material mat = new Material(Shader.Find("Custom/Unlit_alpha"));
            transitionScreen.GetComponent<MeshRenderer>().material = mat;
        }

        StartCoroutine(RecordFrame());
    }

    IEnumerator RecordFrame()
    {
        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();

        transitionScreen.GetComponent<MeshRenderer>().material.mainTexture = texture;
        transitionScreen.SetActive(true);

        Services.sceneController.LoadNextScene();
        isFading = true;
    }
}