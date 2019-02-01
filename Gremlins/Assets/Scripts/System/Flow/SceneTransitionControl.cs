using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionControl : MonoBehaviour
{
    public Shader transitionShader;
    public Texture transitionTexture;
    public float transitionTextureScale = 1.0f;

    GameObject transitionScreen = null;
    Camera transitionCamera = null;
    int transitionLayer = 31;

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
    }

    public void GenerateTransitionScreen()
    {
        if (!transitionCamera)
        {
            transitionCamera = gameObject.AddComponent<Camera>();
        }

        transitionCamera.orthographic = true;
        transitionCamera.orthographicSize = Services.cameraController.OrthographicSize();
        transitionCamera.nearClipPlane = -1f;
        transitionCamera.farClipPlane = 1f;
        transitionCamera.depth = float.MaxValue;
        transitionCamera.cullingMask = 1 << transitionLayer;
        transitionCamera.clearFlags = CameraClearFlags.Nothing;
        transitionCamera.enabled = false;

        // transtion screen
        transitionScreen = new GameObject();
        transitionScreen.transform.SetParent(transform);
        transitionScreen.name = "TransitionScreen";
        transitionScreen.layer = transitionLayer;
        transitionScreen.AddComponent<MeshFilter>();
        transitionScreen.AddComponent<MeshRenderer>();
        transitionScreen.SetActive(false);

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

        Material mat = new Material(transitionShader);
        mat.color = Color.white;
        mat.SetTexture("_PatternTex", transitionTexture);
        mat.SetTextureScale("_PatternTex", new Vector2(transitionTextureScale, transitionTextureScale));
        transitionScreen.GetComponent<MeshRenderer>().material = mat;
    }

    public void RecordScreen()
    {
        GenerateTransitionScreen();
        StartCoroutine(RecordFrame());
    }

    IEnumerator RecordFrame()
    {
        yield return null;
        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();

        transitionScreen.GetComponent<MeshRenderer>().material.mainTexture = texture;
        transitionScreen.SetActive(true);
        transitionCamera.enabled = true;
    }

    public void FadeIntoLoadingScreen()
    {
        GenerateTransitionScreen();

        Services.taskManager.Do(new TimedMaterialWithCameraTask(transitionScreen, transitionCamera, "_Progress", 1, 0, 1, false));
    }

    public void FadeOutOfLoadingScreen()
    {
        //Debug.Log("Fade out");
        //GenerateTransitionScreen();

        Services.taskManager.Do(new TimedMaterialWithCameraTask(transitionScreen, transitionCamera, "_Progress", 0, 1, 1, true));
    }
}